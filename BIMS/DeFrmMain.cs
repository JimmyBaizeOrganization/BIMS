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
using DevExpress.XtraEditors;
using Tools;
using System.Runtime.InteropServices;
using System.Collections;
using System .IO ;

namespace BIMS
{
    public partial class DeFrmMain : DevExpress.XtraEditors.XtraForm
    {

        private Point mouse_offset;
        private int fullmode;
        private Hashtable beans = new Hashtable();

        public DeFrmMain()
        {
            InitializeComponent();
           
        }

        private void DeFrmMain_Load(object sender, EventArgs e)
        {
            pictureBox4.Parent = pictureBox3;
            pictureBox5.Parent = pictureBox4;
            pictureBox5.Location = new Point(pictureBox5.Location.X, pictureBox5.Location.Y-pictureBox1 .Height -pictureBox2 .Height+10  );
            DrawPicture_2();

            VScroll_self.Parent = pictureBox3;
            VScroll_self.Location = new Point(2530, 30);
            VScroll_main.Parent = VScroll_self;
            VScroll_main.Location = new Point(0, 0);
            VScroll_main .BringToFront();
            this.MouseWheel += new MouseEventHandler(Common_Mousewheel);
            VScroll_main.MouseWheel += new MouseEventHandler(Common_Mousewheel);
            VScroll_self.MouseWheel += new MouseEventHandler(Common_Mousewheel);

            mpanel .GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(mpanel,
                true, null);
            VScroll_main .GetType().GetProperty("DoubleBuffered",
               System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(VScroll_main,
               true, null);

            SetScrollBar(mpanel.Handle, 3, 0);

            mpanel.Parent = pictureBox3;
            mpanel.Location = new Point(mpanel.Location.X, pictureBox5 .Location .Y   );

            for (int i = 0; i < 7; i++)
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

                //pan.GetType().GetProperty("DoubleBuffered",
                //System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(pan,
                //true, null);

                //pic.GetType().GetProperty("DoubleBuffered",
                //System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(pic,
                //true, null);

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
            FindFile(FileURL.ResourceDirRoot+@"/../bean/");
            getLittleDevice();
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
                BaseDevice pic = (BaseDevice)rt.MObj;
                pic.Image = ImageTools.getImage((string)rt.getPropertyInfo("ImageURL"));

                mpanel.Controls[0].Controls.Add(pic);
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
            label1.Text = fullmode.ToString ();

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

            bigpic.MouseDoubleClick += new MouseEventHandler(BigPicDoubleClick);
            //FindFile(FileURL.ResourceDirRoot + @"/../bean/");

        }

        private void BigPicDoubleClick(object sender, MouseEventArgs e)
        {
            mpanel.Controls.Clear();
            fullmode = 0;
            label1.Text = fullmode.ToString();

            for (int i = 0; i < 7; i++)
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
            }
           // FindFile(FileURL.ResourceDirRoot + @"/../bean/");
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
            mouse_offset = e.Location;
        }

        private void VScroll_main_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button ==MouseButtons .Left )
            {
                if (VScroll_main.Top + e.Y - mouse_offset.Y < 0)
                { VScroll_main.Top = 0; }
                else if(VScroll_main.Top + e.Y - mouse_offset.Y > VScroll_self.Size.Height - VScroll_main.Size.Height)
                { VScroll_main.Top = VScroll_self.Size.Height - VScroll_main.Size.Height; }
                else
                { VScroll_main.Top += e.Y - mouse_offset.Y; }

                mpanel.SuspendLayout();
                mpanel.VerticalScroll.Value = (mpanel.VerticalScroll.Maximum - mpanel.VerticalScroll.Minimum - mpanel.VerticalScroll.LargeChange + 1) * VScroll_main.Top / (VScroll_self.Size.Height - VScroll_main.Size.Height);
                mpanel.ResumeLayout();    
            }
        }

        private void Common_Mousewheel(object sender, MouseEventArgs e)
        {
            if (VScroll_main.Top - e.Delta / 10 < 0)
            { VScroll_main.Top = 0; }
            else if (VScroll_main.Top - e.Delta / 10 > VScroll_self.Size.Height - VScroll_main.Size.Height)
            { VScroll_main.Top = VScroll_self.Size.Height - VScroll_main.Size.Height; }
            else
            { VScroll_main.Top -= e.Delta / 10; }
            mpanel.SuspendLayout();
            mpanel.VerticalScroll.Value = (mpanel.VerticalScroll.Maximum - mpanel.VerticalScroll.Minimum - mpanel.VerticalScroll.LargeChange + 1) * VScroll_main.Top / (VScroll_self.Size.Height - VScroll_main.Size.Height);
            mpanel.ResumeLayout(); 
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    if (VScroll_main.Top - 10 < 0)
                    { VScroll_main.Top = 0; }
                    else
                    { VScroll_main.Top -= 10; }
                    mpanel.SuspendLayout();
                    mpanel.VerticalScroll.Value = (mpanel.VerticalScroll.Maximum - mpanel.VerticalScroll.Minimum - mpanel.VerticalScroll.LargeChange + 1) * VScroll_main.Top / (VScroll_self.Size.Height - VScroll_main.Size.Height);
                    mpanel.ResumeLayout();
                    break;
                case Keys.Down:
                    if (VScroll_main.Top + 10 > VScroll_self.Size.Height - VScroll_main.Size.Height)
                    { VScroll_main.Top = VScroll_self.Size.Height - VScroll_main.Size.Height; }
                    else
                    { VScroll_main.Top += 10; }
                    mpanel.SuspendLayout();
                    mpanel.VerticalScroll.Value = (mpanel.VerticalScroll.Maximum - mpanel.VerticalScroll.Minimum - mpanel.VerticalScroll.LargeChange + 1) * VScroll_main.Top / (VScroll_self.Size.Height - VScroll_main.Size.Height);
                    mpanel.ResumeLayout();
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
            DrawPicture_1();
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            DrawPicture_2();
        }

        private void DrawPicture_1()
        {
            Bitmap bit = new Bitmap(218, 1910, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int iheight = 0;

            int imouse;
            if ((Cursor.Position.Y - 200) < 0)
            { imouse = 0; }
            else
            { imouse = ((Cursor.Position.Y - 200) / 33) + 3; }

            for (int i = 1; i < 10; i++)
            {
                Image iimage;
                if (i != imouse)
                { iimage = ImageTools.getImage(@"\导航按钮\导航图标_0" + i + ".png"); }
                else
                { iimage = ImageTools.getImage(@"\导航按钮\导航图标x_0" + i + ".png"); }

                Graphics g = Graphics.FromImage(bit);

                g.DrawImage(iimage, 0, iheight);
                iheight += iimage.Height;
            }
            for (int i = 10; i < 40; i++)
            {
                Image iimage;
                if (i != imouse)
                { iimage = ImageTools.getImage(@"\导航按钮\导航图标_" + i + ".png"); }
                else
                { iimage = ImageTools.getImage(@"\导航按钮\导航图标x_" + i + ".png"); }

                Graphics g = Graphics.FromImage(bit);

                g.DrawImage(iimage, 0, iheight);
                iheight += iimage.Height;
            }

            pictureBox5.BackgroundImage = bit;
        }

        private void DrawPicture_2()
        {
            Bitmap bit = new Bitmap(218, 1910, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            int iheight = 0;

            for (int i = 1; i < 10; i++)
            {
                Image iimage = ImageTools.getImage(@"\导航按钮\导航图标_0" + i + ".png");
                Graphics g = Graphics.FromImage(bit);
                g.DrawImage(iimage, 0, iheight);
                iheight += iimage.Height;
            }
            for (int i = 10; i < 40; i++)
            {
                Image iimage = ImageTools.getImage(@"\导航按钮\导航图标_" + i + ".png");
                Graphics g = Graphics.FromImage(bit);
                g.DrawImage(iimage, 0, iheight);
                iheight += iimage.Height;
            }
            pictureBox5.BackgroundImage = bit;
        }
        #endregion

    }
}