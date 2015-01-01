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

            for (int i = 0; i < 16; i++) 
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

            //mpanel.Location = new Point(cLBC_left.Width, pictureBox1.Height);
            //Console.WriteLine (this .Size);
            //mpanel.Size = new Size(this.Size.Width - cLBC_left.Width-18,this.Size.Height - pictureBox1 .Size.Height-48);
            //Console.WriteLine(mpanel.Size);
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

        private void DeFrmMain_Resize(object sender, EventArgs e)
        {
            //mpanel.Size = new Size(this.Size.Width - cLBC_left.Width - 18, this.Size.Height - pictureBox1.Size.Height - 48);
        }
    }
}