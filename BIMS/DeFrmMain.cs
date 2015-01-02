using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Tools;
using System.Runtime.InteropServices;

namespace BIMS
{
    public partial class DeFrmMain : DevExpress.XtraEditors.XtraForm
    {

        public DeFrmMain()
        {
            InitializeComponent();
        }

        private void DeFrmMain_Load(object sender, EventArgs e)
        {
            pictureBox4.Parent = pictureBox3;
            pictureBox5.Parent = pictureBox4;
            pictureBox5.Location = new Point(25,20);

            mtableLayoutPanel.Parent = mpanel;
            mtableLayoutPanel.Location = new Point(0, 0);
            //mtableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            //cLBC_left.Dock = DockStyle.Left;

            mpanel.Parent = pictureBox3;
            mpanel.Location = new Point(200, 20);

            for (int i = 0; i < 7; i++)
            {
                Panel pan = new Panel();
                pan.Name = "Panel" + i.ToString();
                pan.Size = new Size(800, 600);
                pan.Location = new Point(0, 0);
                pan.BackColor = Color.Transparent;
                //pan.BorderStyle = BorderStyle.FixedSingle;
                pan.AutoScroll = true;
                mtableLayoutPanel.Controls.Add(pan, (i % 3), (i / 3));

                PictureBox pic = new PictureBox();
                pic.Name = "PictureBox" + i.ToString();
                pic.Size = new Size(724, 542);
                pic.Location = new Point(38, 29);
                pic.BackColor = Color.Transparent;
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.Parent = pan;
            }

            Button_Close.Parent = pictureBox1;
            Button_Maintenance .Parent = pictureBox1;
            Button_Help .Parent = pictureBox1;
            Button_Home .Parent = pictureBox1;
            Button_Locked .Parent = pictureBox1;
            Button_Setting .Parent = pictureBox1;
            Button_Sum .Parent = pictureBox1;

            //ReflectTools rt = new ReflectTools("BIMS", "BIMS", "DED194E_9S1YK2K2");
            //DED194E_9S1YK2K2 aa = (DED194E_9S1YK2K2)rt.MObj;

            //aa.Location = new Point(200, 200);
            //aa.BackColor = Color.Black;
            //aa.Size = new Size(10, 10);
            //this.Controls.Add(aa);
            //aa.Parent = this.Controls.Find("PictureBox0",true)[0];

            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            mtableLayoutPanel.BackColor = Color.Transparent;
            mpanel.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void mpanel_Paint(object sender, PaintEventArgs e)
        {

        }

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

    }
}