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

namespace BIMS
{
    public partial class DeFrmMain : DevExpress.XtraEditors.XtraForm
    {
        public DeFrmMain()
        {
            InitializeComponent();
            cLBC_left.Items.Add("电量仪", false);
        }

        private void DeFrmMain_Load(object sender, EventArgs e)
        {
            mtableLayoutPanel.Parent = mpanel;
            mtableLayoutPanel.Location = new Point(0, 0);
            mtableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            for (int i = 0; i < 7; i++) 
            {
                Panel pan = new Panel();
                pan.Name = "Panel" + i.ToString();
                pan.Size=new Size(800,600);
                pan.Location = new Point(0, 0);
                pan.BackColor = Color.WhiteSmoke;
                pan.BorderStyle = BorderStyle.FixedSingle;
                pan.AutoScroll = true;
                mtableLayoutPanel .Controls .Add(pan,(i%3),(i/3));

                PictureBox pic = new PictureBox();
                pic.Name = "PictureBox" + i.ToString();
                pic.Size = new Size(724, 542);
                pic.Location = new Point(38, 29);
                pic.BackColor = Color.LightBlue;
                pic.Parent =pan;
            }

            Button_Close.Parent = pictureBox1;
            Button_Document .Parent = pictureBox1;
            Button_Help .Parent = pictureBox1;
            Button_Home .Parent = pictureBox1;
            Button_Locked .Parent = pictureBox1;
            Button_Setting .Parent = pictureBox1;
            Button_Sum .Parent = pictureBox1;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void mpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cLBC_left_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}