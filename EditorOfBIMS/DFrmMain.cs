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

namespace EditorOfBIMS
{
    public partial class DFrmMain : DevExpress.XtraEditors.XtraForm
    {
        private Bitmap mImage ;
        String[][] listItems = { new String[2] { "电量仪", "ElectricityGauge.png" }
                               , new String[2] { "电量仪", "ElectricityGauge.png" }
                               , new String[2] { "电量仪", "ElectricityGauge.png" }
                               , new String[2] { "电量仪", "ElectricityGauge.png" }
                               , new String[2] { "电量仪", "ElectricityGauge.png" }
                               , new String[2] { "电量仪", "ElectricityGauge.png" }};
        public DFrmMain()
        {
            InitializeComponent();
        }

        private void DFrmMain_Load(object sender, EventArgs e)
        {
            //初始化左边栏
            initToolsBox();
            //初始化右侧图片编辑区域
            initImageEditor();
        }

        private void initImageEditor()
        {
            this.pE_Rigth.AllowDrop = true;
            Size size = this.pE_Rigth.Size;
            mImage = new Bitmap(size.Width, size.Height);
        }

        private void initToolsBox()
        {
            iLBC_Left.ItemHeight = 40;
            for (int i = 0; i < listItems.Length; i++)
            {
                iLBC_Left.Items.Add(i);
              
            }                
        }

        private void iLBC_Left_DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {
            Brush myBrush = Brushes.Black;
            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
            {
                myBrush = new SolidBrush(Color.BlueViolet);
            }
            else if (e.Index % 2 == 0)
            {
                myBrush = new SolidBrush(Color.Azure);
            }
            else
            {
                myBrush = new SolidBrush(Color.White);
            }
            e.Graphics.FillRectangle(myBrush, e.Bounds);
           

            String[] itme = listItems[e.Index];
            Font font = new Font("微软雅黑", 10);
            Brush brush = Brushes.Black;    
            Rectangle rec= e.Bounds;
            rec.Width = iLBC_Left.ItemHeight;
            rec.Height = iLBC_Left.ItemHeight;
            e.Graphics.DrawImage(FileTools.ImageTools.getImage(itme[1]),rec );
           // PointF pointf = new PointF(iLBC_Left.ItemHeight * 2 + 10, iLBC_Left.ItemHeight / 2);
            rec.X = iLBC_Left.ItemHeight +10;
            rec.Width = iLBC_Left.Size.Width - iLBC_Left.ItemHeight;
            rec.Y +=  iLBC_Left.ItemHeight/3;
            e.Graphics.DrawString(itme[0], font, brush, rec);
            e.Handled = true;
        }

        private void iLBC_Left_MouseHover(object sender, EventArgs e)
        {
           // iLBC_Left.Invalidate();
        }

        private void iLBC_Left_MouseDown(object sender, MouseEventArgs e)
        {
            //调用DoDragDrop方法
            if (this.iLBC_Left.SelectedItem != null)
            {
                this.iLBC_Left.DoDragDrop(this.iLBC_Left.SelectedItem, DragDropEffects.Copy);
            }
        }

        private void pE_Rigth_DragDrop(object sender, DragEventArgs e)
        {
            int size = 60;
            Point contextMenuPoint = this.pE_Rigth.PointToClient(Control.MousePosition);
            Rectangle rect = new Rectangle(contextMenuPoint.X - size / 2, contextMenuPoint.Y - size / 2, size, size);
            Graphics g = Graphics.FromImage(mImage);
            g.DrawImage(FileTools.ImageTools.getImage("ElectricityGauge.png"), rect);
                 
        }

        private void pE_Rigth_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pE_Rigth_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(mImage, 0, 0);
        }


    }
}