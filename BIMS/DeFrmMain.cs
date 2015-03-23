using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tools;
using System.Runtime.InteropServices;
using System.Collections;
using System .IO ;

namespace BIMS
{
    public partial class DeFrmMain : Form
    {
        private int fullmode;
        private int maxfloor;
        private int floorview;
        private bool wheelnum=false;
        private Hashtable beans = new Hashtable();
        private ArrayList sortlist = new ArrayList(); 

        public DeFrmMain()
        {
            InitializeComponent();
           
        }

        private void DeFrmMain_Load(object sender, EventArgs e)
        {

            FindFile(FileURL.ResourceDirRoot + @"/../bean/Client/");
                       
            pictureBox4.Parent = pictureBox3;
            pictureBox5.Parent = pictureBox4;
            pictureBox5.Location = new Point(pictureBox5.Location.X, pictureBox5.Location.Y-pictureBox1 .Height -pictureBox2 .Height  );
            DrawPicture_1();

            VScroll_self.Parent = pictureBox3;
            VScroll_self.Location = new Point(2530, 30);
            VScroll_main.Parent = VScroll_self;
            VScroll_main.Location = new Point(0, 0);
            VScroll_main .BringToFront();
            this.MouseWheel += new MouseEventHandler(Common_Mousewheel);

            mpanel .GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(mpanel,
                true, null);
            //VScroll_main .GetType().GetProperty("DoubleBuffered",
            //   System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(VScroll_main,
            //   true, null);

            SetScrollBar(mpanel.Handle, 3, 0);

            mpanel.Parent = pictureBox3;
            mpanel.Location = new Point(mpanel.Location.X, pictureBox5 .Location .Y   );

            for (int i = 0; i < maxfloor; i++)
            {
                Panel pan = new Panel();
                pan.Name = "Panel" + i.ToString();
                pan.Size = new Size((int)mpanel.Size.Width /3, (int)mpanel.Size.Height/2);
                mpanel.Controls.Add(pan);
                pan.Location = new Point((int)mpanel.Size.Width * (i % 3) / 3, (int)mpanel.Size.Height * (i / 3) / 2);
                pan.BackColor = Color.Transparent;
                //pan.AutoScroll = true;
                          
                PictureBox pic = new PictureBox();
                pic.Name = "PictureBox" + i.ToString();
                pic.Size = new Size((int)mpanel.Size.Width * 1064 / 3494, (int)mpanel.Size.Height * 800 / 1944);
                pic.Location = new Point(38, 29);
                pic.BackgroundImage = BIMS.Properties.Resources.moudle;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BackColor = Color.Transparent;
                pic.Parent = pan;

                pic.MouseDoubleClick += new MouseEventHandler(PicDoubleClick);

                Label labelfloor = new Label();
                labelfloor.AutoSize = true;
                labelfloor.Text = ChangeNum(i+1)+"层";
                labelfloor.ForeColor = Color.FromArgb(0, 96, 170);
                labelfloor.Font = new Font("微软雅黑", 44, FontStyle.Bold);
                labelfloor.Location = new Point(pic.Location.X + pic.Size.Width / 2 - labelfloor.Size.Width / 2, pic.Location.Y + pic.Size.Height);
                pan.Controls.Add(labelfloor);
            }

            Button_Close.Parent = pictureBox1;
            Button_Maintenance .Parent = pictureBox1;
            Button_Help .Parent = pictureBox1;
            Button_Home .Parent = pictureBox1;
            Button_Locked .Parent = pictureBox1;
            Button_Setting .Parent = pictureBox1;
            Button_Sum .Parent = pictureBox1;                    

            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            mpanel.BackColor = Color.FromArgb(236,236,236);
            VScroll_self.BackColor = Color.Transparent;
            VScroll_main.BackColor = Color.Transparent;

            fullmode = 0;
            floorview = 1;
            getLittleDevice();
        }

        private string ChangeNum(int n)
        {
            string a = "零一二三四五六七八九十";
            string s="";
            if (n > 0)
            {
                if (n <= 10)
                {
                    s = a[n].ToString();
                }
                else if (n < 20)
                {
                    s = "十" + a[n % 10].ToString();
                }
            }
            return s;
        }

        public void FindFile(string dirPath) //参数dirPath为指定的目录 
        {
            //在指定目录及子目录下查找文件,在listBox1中列出子目录及文件 
            DirectoryInfo Dir = new DirectoryInfo(dirPath);
            try
            {
                foreach (DirectoryInfo d in Dir.GetDirectories())//查找子目录 
                {
                    FindFile(Dir + d.ToString() + @"\");
                }
                foreach (FileInfo f in Dir.GetFiles("*.xml")) //查找文件 
                {
                    string[] filename = f.ToString().Split('.');
                    string typename = filename[filename.Length - 2];
                    BaseBean b = BeanTools.getBeanFromXML(typename, Dir + f.ToString());
                    if (!beans.ContainsKey(b.getBeanKey()))
                    {
                        beans.Add(b.getBeanKey(),b);

                        if (!sortlist.Contains(b.Sort))
                        { 
                            sortlist.Add(b.Sort);
                        }
                        if (b.FloorNum > maxfloor)
                        {
                            maxfloor = b.FloorNum;
                        }
                    }
                                                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }

        public void getLittleDevice()
        {
            foreach(DictionaryEntry de in beans)
            {
                BaseBean b= (BaseBean)de.Value;
                ReflectTools rt = new ReflectTools("BIMS", "BIMS", b.ClassName, new object[] { b });
                InterfaceDevice dev = (InterfaceDevice)rt.MObj;
                Control[] devices = dev.getAllDevice();
                foreach (Control pic in devices)
                {                  
                    mpanel.Controls[b.FloorNum - 1].Controls[0].Controls.Add(pic);                  
                }               
            }
        }

        public void getBigDevice()
        {
            foreach (DictionaryEntry de in beans)
            {
                BaseBean b = (BaseBean)de.Value;
                if (b.FloorNum == fullmode)
                {
                    
                    ReflectTools rt = new ReflectTools("BIMS", "BIMS", b.ClassName, new object[] { b });
                    InterfaceDevice dev = (InterfaceDevice)rt.MObj;
                    Control[] devices = dev.getAllDevice();
                    foreach (Control pic in devices)
                    {
                        //pic.Location = new Point(b.MPoint.X * (mpanel.Size.Width * 2 / 3 + mpanel.Size.Width * 1064 / 3494) / (mpanel.Size.Width * 1064 / 3494),
                        //                     b.MPoint.Y * (mpanel.Size.Height / 2 + mpanel.Size.Height * 800 / 1944) / (mpanel.Size.Height * 800 / 1944));
                        //pic.Size = new Size(pic.Size.Width * 2, pic.Size.Height * 2);

                        mpanel.Controls[0].Controls[0].Controls.Add(pic);
                    }  
        
                   
                   

                    //Bitmap bitmap = new Bitmap(iimage.Size.Width * 2, iimage.Size.Height * 2);
                    //Graphics g = Graphics.FromImage(bitmap);

                    //g.DrawImage(ImageTools.getImage((string)rt.getPropertyInfo("ImageURL")), 0, 0, iimage.Size.Width * 2, iimage.Size.Height * 2);

                    //pic.BackgroundImage = bitmap;

                    //mpanel.Size.Width * 1064 / 3494
                    //mpanel.Size.Width * 2 / 3 + mpanel.Size.Width * 1064 / 3494
                }
            }
        }

        /// <summary>
        /// 双击显示方式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region
        private void PicDoubleClick(object sender, MouseEventArgs  e) 
        {
            PictureBox pic = (PictureBox)sender;
            fullmode = mpanel.Controls.IndexOf(pic.Parent)+1;

            mpanel.Controls.Clear();

            Panel bigpan = new Panel();
            bigpan.Size = new Size((int)mpanel.Size.Width, (int)mpanel.Size.Height);
            mpanel.Controls.Add(bigpan);
            bigpan.Location = new Point(0, 0);
            bigpan.BackColor = Color.Transparent;

            PictureBox bigpic = new PictureBox();
            bigpic.Size = new Size(mpanel.Size.Width * 2 / 3 + mpanel.Size.Width * 1064 / 3494, mpanel.Size.Height / 2 + mpanel.Size.Height * 800 / 1944);
            bigpic.Location = new Point(38, 29);
            bigpic.BackgroundImage = BIMS.Properties.Resources.moudle;
            bigpic.BackgroundImageLayout = ImageLayout.Stretch;
            bigpic.BackColor = Color.Transparent;
            bigpic.Parent = bigpan;

            Label labelfloor = new Label();
            labelfloor.AutoSize = true;
            labelfloor.Text = ChangeNum(fullmode) + "层";
            labelfloor.ForeColor = Color.FromArgb(0, 96, 170);
            labelfloor.Font = new Font("微软雅黑", 50, FontStyle.Bold);
            labelfloor.Location = new Point(bigpic.Location.X + bigpic.Size.Width / 2 - labelfloor.Size.Width / 2, bigpic.Location.Y + bigpic.Size.Height);
            bigpan.Controls.Add(labelfloor);

            bigpic.MouseDoubleClick += new MouseEventHandler(BigPicDoubleClick);
            getBigDevice();
        }

        private void BigPicDoubleClick(object sender, MouseEventArgs e)
        {
            mpanel.Controls.Clear();
            fullmode = 0;

            for (int i = 0; i < maxfloor ; i++)
            {
                Panel pan = new Panel();
                pan.Name = "Panel" + i.ToString();
                pan.Size = new Size((int)mpanel.Size.Width / 3, (int)mpanel.Size.Height / 2);
                mpanel.Controls.Add(pan);
                pan.Location = new Point((int)mpanel.Size.Width * (i % 3) / 3, (int)mpanel.Size.Height * (i / 3) / 2);
                pan.BackColor = Color.Transparent;
                //pan.AutoScroll = true;

                PictureBox pic = new PictureBox();
                pic.Name = "PictureBox" + i.ToString();
                pic.Size = new Size((int)mpanel.Size.Width * 1064 / 3494, (int)mpanel.Size.Height * 800 / 1944);
                pic.Location = new Point(38, 29);
                pic.BackgroundImage = BIMS.Properties.Resources.moudle;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BackColor = Color.Transparent;
                pic.Parent = pan;

                pic.MouseDoubleClick += new MouseEventHandler(PicDoubleClick);

                Label labelfloor = new Label();
                labelfloor.AutoSize = true;
                labelfloor.Text = ChangeNum(i + 1) + "层";
                labelfloor.ForeColor = Color.FromArgb(0, 96, 170);
                labelfloor.Font = new Font("微软雅黑", 44, FontStyle.Bold);
                labelfloor.Location = new Point(pic.Location.X + pic.Size.Width / 2 - labelfloor.Size.Width / 2, pic.Location.Y + pic.Size.Height);
                pan.Controls.Add(labelfloor);
            }

            mpanel.SuspendLayout();
            mpanel.VerticalScroll.Value = (mpanel.VerticalScroll.Maximum - mpanel.VerticalScroll.Minimum - mpanel.VerticalScroll.LargeChange + 1) * VScroll_main.Top / (VScroll_self.Size.Height - VScroll_main.Size.Height);
            mpanel.ResumeLayout(); 

            getLittleDevice();
        }
        #endregion

        /// <summary>
        /// Button_Close  关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region
        private void Button_Close_Click(object sender, EventArgs e)
        {
            DialogResult  a =MessageBox.Show("确定退出监控程序？", "退出程序",MessageBoxButtons.YesNo );
            if (a == DialogResult.Yes)
            {
                this.Close();
            }

        }
        private void Button_Close_MouseEnter(object sender, EventArgs e)
        {
            Button_Close.BackgroundImage = BIMS.Properties .Resources .button7x_ ;
        }

        private void Button_Close_MouseLeave(object sender, EventArgs e)
        {
            Button_Close.BackgroundImage = BIMS.Properties.Resources.button7_;
        }

        private void Button_Close_MouseDown(object sender, MouseEventArgs e)
        {
            Button_Close.BackgroundImage = BIMS.Properties.Resources.button7xx_;
        }
        private void Button_Close_MouseUp(object sender, MouseEventArgs e)
        {
            Button_Close.BackgroundImage = BIMS.Properties.Resources.button7x_;
        }
        #endregion

        /// <summary>
        /// Button_Locked 锁定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region
        private void Button_Locked_Click(object sender, EventArgs e)
        {

        }

        private void Button_Locked_MouseEnter(object sender, EventArgs e)
        {
            Button_Locked.BackgroundImage = BIMS.Properties.Resources.button6x_;
        }

        private void Button_Locked_MouseLeave(object sender, EventArgs e)
        {
            Button_Locked.BackgroundImage = BIMS.Properties.Resources.button6_ ;
        }

        private void Button_Locked_MouseDown(object sender, MouseEventArgs e)
        {
            Button_Locked.BackgroundImage = BIMS.Properties.Resources.button6xx_ ;
        }
        private void Button_Locked_MouseUp(object sender, MouseEventArgs e)
        {
            Button_Locked .BackgroundImage = BIMS.Properties.Resources.button6x_;
        }
  
        #endregion

        /// <summary>
        /// Button_Help 帮助按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region
        private void Button_Help_Click(object sender, EventArgs e)
        {

        }

        private void Button_Help_MouseDown(object sender, MouseEventArgs e)
        {
            Button_Help.BackgroundImage = BIMS.Properties.Resources.button5xx_;
        }

        private void Button_Help_MouseEnter(object sender, EventArgs e)
        {
            Button_Help.BackgroundImage = BIMS.Properties.Resources.button5x_ ;
        }

        private void Button_Help_MouseLeave(object sender, EventArgs e)
        {
            Button_Help.BackgroundImage = BIMS.Properties.Resources.button5_ ;
        }

        private void Button_Help_MouseUp(object sender, MouseEventArgs e)
        {
            Button_Help.BackgroundImage = BIMS.Properties.Resources.button5x_ ;
        }
        #endregion

        /// <summary>
        /// Button_Sum 统计按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region
        private void Button_Sum_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Button_Sum_MouseDown(object sender, MouseEventArgs e)
        {
            Button_Sum.BackgroundImage = BIMS.Properties.Resources.button4xx_ ;
        }

        private void Button_Sum_MouseEnter(object sender, EventArgs e)
        {
            Button_Sum .BackgroundImage = BIMS.Properties.Resources.button4x_ ;
        }

        private void Button_Sum_MouseLeave(object sender, EventArgs e)
        {
            Button_Sum.BackgroundImage = BIMS.Properties.Resources.button4_ ;
        }

        private void Button_Sum_MouseUp(object sender, MouseEventArgs e)
        {
            Button_Sum.BackgroundImage = BIMS.Properties.Resources.button4x_ ;
        }
        #endregion

        /// <summary>
        /// Button_Maintenance 维护按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region
        private void Button_Maintenance_Click(object sender, EventArgs e)
        {
            
        }

        private void Button_Maintenance_MouseDown(object sender, MouseEventArgs e)
        {
            Button_Maintenance.BackgroundImage = BIMS.Properties.Resources.button3xx_ ;
        }

        private void Button_Maintenance_MouseEnter(object sender, EventArgs e)
        {
            Button_Maintenance.BackgroundImage = BIMS.Properties.Resources.button3x_;
        }

        private void Button_Maintenance_MouseLeave(object sender, EventArgs e)
        {
            Button_Maintenance.BackgroundImage = BIMS.Properties.Resources.button3_  ;
        }

        private void Button_Maintenance_MouseUp(object sender, MouseEventArgs e)
        {
            Button_Maintenance.BackgroundImage = BIMS.Properties.Resources.button3x_;
        }
        #endregion

        /// <summary>
        /// Button_Setting 设置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region
        private void Button_Setting_Click(object sender, EventArgs e)
        {

        }

        private void Button_Setting_MouseDown(object sender, MouseEventArgs e)
        {
            Button_Setting.BackgroundImage = BIMS.Properties.Resources.button2xx_;
        }

        private void Button_Setting_MouseEnter(object sender, EventArgs e)
        {
            Button_Setting.BackgroundImage = BIMS.Properties.Resources.button2x_;
        }

        private void Button_Setting_MouseLeave(object sender, EventArgs e)
        {
            Button_Setting.BackgroundImage = BIMS.Properties.Resources.button2_;
        }

        private void Button_Setting_MouseUp(object sender, MouseEventArgs e)
        {
            Button_Setting.BackgroundImage = BIMS.Properties.Resources.button2x_;
        }
        #endregion

        /// <summary>
        /// Button_Home 主页按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region
        private void Button_Home_Click(object sender, EventArgs e)
        {
            
        }

        private void Button_Home_MouseDown(object sender, MouseEventArgs e)
        {
            Button_Home.BackgroundImage = BIMS.Properties.Resources.button1xx_ ;
        }

        private void Button_Home_MouseEnter(object sender, EventArgs e)
        {
            Button_Home.BackgroundImage = BIMS.Properties.Resources.button1x_;
        }

        private void Button_Home_MouseLeave(object sender, EventArgs e)
        {
            Button_Home.BackgroundImage = BIMS.Properties.Resources.button1_ ;
        }

        private void Button_Home_MouseUp(object sender, MouseEventArgs e)
        {
            Button_Home.BackgroundImage = BIMS.Properties.Resources.button1x_;
        }
        #endregion

        /// <summary>
        /// VScroll 滚动条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region
        private void VScroll_main_MouseEnter(object sender, EventArgs e)
        {
            VScroll_main.BackgroundImage = BIMS.Properties.Resources.scroll_bar_mainx ;
        }

        private void VScroll_main_MouseLeave(object sender, EventArgs e)
        {
            VScroll_main.BackgroundImage = BIMS.Properties.Resources.scroll_bar_main_;
        }

        private void VScroll_main_MouseDown(object sender, MouseEventArgs e)
        {
            //mouse_offset = e.Location;
        }

        private void VScroll_main_MouseMove(object sender, MouseEventArgs e)
        {
            //if(e.Button ==MouseButtons .Left )
            //{
            //    if (VScroll_main.Top + e.Y - mouse_offset.Y < 0)
            //    { VScroll_main.Top = 0; }
            //    else if(VScroll_main.Top + e.Y - mouse_offset.Y > VScroll_self.Size.Height - VScroll_main.Size.Height)
            //    { VScroll_main.Top = VScroll_self.Size.Height - VScroll_main.Size.Height; }
            //    else
            //    { VScroll_main.Top += e.Y - mouse_offset.Y; }

            //    mpanel.SuspendLayout();
            //    mpanel.VerticalScroll.Value = (mpanel.VerticalScroll.Maximum - mpanel.VerticalScroll.Minimum - mpanel.VerticalScroll.LargeChange + 1) * VScroll_main.Top / (VScroll_self.Size.Height - VScroll_main.Size.Height);
            //    mpanel.ResumeLayout();    
            //}
        }

        private void Common_Mousewheel(object sender, MouseEventArgs e)
        {
             if (fullmode == 0)
             {
                wheelnum =! wheelnum ;
             if (wheelnum)
             {
                 int max = (maxfloor % 3) == 0 ? maxfloor / 3 - 1 : maxfloor / 3;
                 if (floorview - e.Delta / 120 < 1)
                 {
                     floorview = 1;
                 }
                 else if (floorview - e.Delta / 120 > max)
                 {
                     floorview = max;
                 }
                 else
                 {
                     floorview -= e.Delta / 120;
                 }

                 mpanel.SuspendLayout();
                 if (e.Delta < 0)
                 {
                     mpanel.ScrollControlIntoView(mpanel.Controls[floorview * 3]);
                     VScroll_main.Top = (VScroll_self.Size.Height - VScroll_main.Size.Height) / (max - 1) * (floorview - 1);
                 }
                 else
                 {
                     mpanel.ScrollControlIntoView(mpanel.Controls[(floorview - 1) * 3]);
                     VScroll_main.Top = (VScroll_self.Size.Height - VScroll_main.Size.Height) / (((maxfloor % 3) == 0 ? maxfloor / 3 - 1 : maxfloor / 3) - 1) * (floorview - 1);
                 }

                 mpanel.ResumeLayout();
              }
        }
            
            //if (VScroll_main.Top - e.Delta / 10 < 0)
            //{ VScroll_main.Top = 0; }
            //else if (VScroll_main.Top - e.Delta / 10 > VScroll_self.Size.Height - VScroll_main.Size.Height)
            //{ VScroll_main.Top = VScroll_self.Size.Height - VScroll_main.Size.Height; }
            //else
            //{ VScroll_main.Top -= e.Delta / 10; }

            //mpanel.SuspendLayout();
            //mpanel.VerticalScroll.Value = (mpanel.VerticalScroll.Maximum - mpanel.VerticalScroll.Minimum - mpanel.VerticalScroll.LargeChange + 1) * VScroll_main.Top / (VScroll_self.Size.Height - VScroll_main.Size.Height);
            //mpanel.ResumeLayout(); 
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    if (fullmode == 0)
                    {
                        if (floorview - 1 >= 1)
                        {
                            floorview -= 1;
                            mpanel.SuspendLayout();
                            mpanel.ScrollControlIntoView(mpanel.Controls[(floorview - 1) * 3]);
                            VScroll_main.Top = (VScroll_self.Size.Height - VScroll_main.Size.Height) / (((maxfloor % 3) == 0 ? maxfloor / 3 - 1 : maxfloor / 3) - 1) * (floorview - 1);
                            mpanel.ResumeLayout();
                        }
                    }
                    break;
                case Keys.Down:
                    if (fullmode == 0)
                    {
                        int max = (maxfloor % 3) == 0 ? maxfloor / 3 - 1 : maxfloor / 3;
                        if (floorview + 1 <= max)
                        {
                            floorview += 1;
                            mpanel.SuspendLayout();
                            mpanel.ScrollControlIntoView(mpanel.Controls[floorview * 3]);
                            VScroll_main.Top = (VScroll_self.Size.Height - VScroll_main.Size.Height) / (max - 1) * (floorview - 1);
                            mpanel.ResumeLayout();
                        }
                    }
                    break;
            }
            return true;
        }

        /// <summary>
        /// 隐藏滚动条
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="bar"></param>
        /// <param name="show"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ShowScrollBar(IntPtr hWnd, int bar, int show);


        private class SubWindow : NativeWindow
        {
            private int m_Horz = 0;
            private int m_Show = 0;

            public SubWindow(int p_Horz, int p_Show)
            {
                m_Horz = p_Horz;
                m_Show = p_Show;
            }
            protected override void WndProc(ref Message m_Msg)
            {
                ShowScrollBar(m_Msg.HWnd, m_Horz, m_Show);
                base.WndProc(ref m_Msg);
            }
        }

        /// <summary>
        /// 设置滚动条是否显示  zgke@sina.com qq:116149
        /// </summary>
        /// <param name="p_ControlHandle">句柄</param>
        /// <param name="p_Horz">0横 1列 3全部</param>
        /// <param name="p_Show">0隐 1显</param>
        public static void SetScrollBar(IntPtr p_ControlHandle, int p_Horz, int p_Show)
        {
            SubWindow _SubWindow = new SubWindow(p_Horz, p_Show);
            _SubWindow.AssignHandle(p_ControlHandle);
        }

        #endregion

        /// <summary>
        /// 导航条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region
        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
           // DrawPicture_1();
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
           // DrawPicture_2();
        }

        private void leftlabel_MouseEnter(object sender, MouseEventArgs e)
        {
            Label a = (Label)sender;
            a.Image = ImageTools.getImage(@"\导航按钮\导航图标x.png");
        }

        private void leftlabel_MouseClick(object sender, MouseEventArgs e)
        {
            Label a = (Label)sender;
            if (a.ForeColor == Color.White)
            { a.ForeColor = Color.Black; }
            else { a.ForeColor = Color.White; }
        }

        private void leftlabel_MouseLeave(object sender, EventArgs e)
        {
            Label a = (Label)sender;
            a.Image = null;
        }
        private void leftall_MouseEnter(object sender, MouseEventArgs e)
        {
            Label a = (Label)sender;
            a.Image = ImageTools.getImage(@"\导航按钮\导航图标x.png");
        }

        private void leftall_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 1; i < sortlist.Count+1; i++)
            {
                pictureBox5.Controls[i].ForeColor = Color.White;
            }
        }

        private void leftall_MouseLeave(object sender, EventArgs e)
        {
            Label a = (Label)sender;
            a.Image = null;
        }

        private void searchDevices()
        {
            foreach (Panel a in mpanel.Controls)
            {
                foreach (BaseDevice b in a.Controls[0].Controls)
                { 
                   // b.get
                }
            }
        }

        private void DrawPicture_1()
        {
            //foreach()
            //{
            
            //}
            Label leftall = new Label();
            leftall.Text = "ALL";
            leftall.Size = new Size(141, 38);
            leftall.TextAlign = ContentAlignment.MiddleCenter;
            leftall.Location = new Point(2, 50);
            leftall.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftall_MouseEnter);
            leftall.MouseLeave += new System.EventHandler(this.leftall_MouseLeave);
            leftall.MouseClick += new System.Windows.Forms.MouseEventHandler(this.leftall_MouseClick);
            pictureBox5.Controls.Add(leftall);

            for (int i = 0; i < sortlist.Count; i++)
            {
                Label leftlabel = new Label();
                leftlabel.Text = sortlist[i].ToString();
                leftlabel.ForeColor = Color.White;
                leftlabel.Size = new Size(141, 38);
                leftlabel.TextAlign = ContentAlignment.MiddleCenter;
                leftlabel.Location = new Point(2, 100 +50 * i);
                leftlabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.leftlabel_MouseEnter);
                leftlabel.MouseLeave += new System.EventHandler(this.leftlabel_MouseLeave);
                leftlabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.leftlabel_MouseClick);
                Console.WriteLine( pictureBox5.Controls.Count.ToString());
                pictureBox5.Controls.Add(leftlabel);
            }

            //PictureBox backimg = new PictureBox();
            //backimg.Size = new Size(141, 38);
            //backimg.Top = 100;
            //backimg.Left = 2;
            //backimg.BackgroundImageLayout = ImageLayout.Stretch;
            //backimg.BackgroundImage = ImageTools.getImage(@"\导航按钮\导航图标x.png");
            //pictureBox5.Controls.Add(backimg);

            //Bitmap bit = new Bitmap(218, 49, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            //int iheight = 0;

            //int imouse;
            //if ((Cursor.Position.Y - 129) < 0)
            //{ imouse = 0; }
            //else
            //{ imouse = (int)((Cursor.Position.Y - 129) / 33.4) + 1; }

            //for (int i = 1; i < 10; i++)
            //{
            //    Image iimage;
            //    if (i != imouse)
            //    { iimage = ImageTools.getImage(@"\导航按钮\导航图标_0" + i + ".png"); }
            //    else
            //    { iimage = ImageTools.getImage(@"\导航按钮\导航图标x_0" + i + ".png"); }

            //    Graphics g = Graphics.FromImage(bit);

            //    g.DrawImage(iimage, 0, iheight);
            //    iheight += iimage.Height;
            //}
            //for (int i = 10; i < 40; i++)
            //{
            //    Image iimage;
            //    if (i != imouse)
            //    { iimage = ImageTools.getImage(@"\导航按钮\导航图标_" + i + ".png"); }
            //    else
            //    { iimage = ImageTools.getImage(@"\导航按钮\导航图标x_" + i + ".png"); }

            //    Graphics g = Graphics.FromImage(bit);

            //    g.DrawImage(iimage, 0, iheight);
            //    iheight += iimage.Height;
            //}

            //pictureBox5.BackgroundImage = bit;
        }

        //private void DrawPicture_2()
        //{
        //    Bitmap bit = new Bitmap(218, 1945, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //    int iheight = 0;

        //    for (int i = 1; i < 10; i++)
        //    {
        //        Image iimage = ImageTools.getImage(@"\导航按钮\导航图标_0" + i + ".png");
        //        Graphics g = Graphics.FromImage(bit);
        //        g.DrawImage(iimage, 0, iheight);
        //        iheight += iimage.Height;
        //    }
        //    for (int i = 10; i < 40; i++)
        //    {
        //        Image iimage = ImageTools.getImage(@"\导航按钮\导航图标_" + i + ".png");
        //        Graphics g = Graphics.FromImage(bit);
        //        g.DrawImage(iimage, 0, iheight);
        //        iheight += iimage.Height;
        //    }
        //    pictureBox5.BackgroundImage = bit;
        //}
        #endregion

    }
}