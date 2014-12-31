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
using System.Reflection;
using System.Collections;
using System.Xml;
using System.IO;


namespace EditorOfBIMS
{
    public partial class DFrmMain : Form 
    {

        String[][] listItems = { new String[3] { "电量仪", "ElectricityGauge.png","DED194E_9S1YK2K2" }
                               , new String[3] { "电量仪", "ElectricityGauge.png","DED194E_9S1YK2K2"}
                               , new String[3] { "电量仪", "ElectricityGauge.png","DED194E_9S1YK2K2" }
                               , new String[3] { "电量仪", "ElectricityGauge.png","DED194E_9S1YK2K2" }
                               , new String[3] { "电量仪", "ElectricityGauge.png","DED194E_9S1YK2K2" }
                               , new String[3] { "电量仪", "ElectricityGauge.png","DED194E_9S1YK2K2" }};
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
            PanRight.BackColor = Color.LightBlue;

            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load("config.xml");

            XmlNode root = xmlDoc.SelectSingleNode("config");
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("config").ChildNodes;

            foreach (XmlNode xn in nodeList)
            {
                XmlElement xe = (XmlElement)xn; //将子节点类型转换为XmlElement类型 

                if (xe.Name == "Background")
                {
                    this.PanRight .BackgroundImage = Image.FromFile(xe.InnerText);
                }
                break;
            }
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
            if(e.Index % 2 == 0)
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
            Rectangle rec = e.Bounds;
            rec.Width = iLBC_Left.ItemHeight;
            rec.Height = iLBC_Left.ItemHeight;
            e.Graphics.DrawImage(ImageTools.getImage(itme[1]), rec);
            // PointF pointf = new PointF(iLBC_Left.ItemHeight * 2 + 10, iLBC_Left.ItemHeight / 2);
            rec.X = iLBC_Left.ItemHeight + 10;
            rec.Width = iLBC_Left.Size.Width - iLBC_Left.ItemHeight;
            rec.Y += iLBC_Left.ItemHeight / 3;
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
                this.iLBC_Left.DoDragDrop(this.iLBC_Left.SelectedIndex, DragDropEffects.Copy);
            }
        }
        private void PanRight_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void PanRight_DragDrop(object sender, DragEventArgs e)
        {
            //图片的大小
            int size = 60;
            Point contextMenuPoint = this.PanRight.PointToClient(Control.MousePosition);
            Rectangle rect = new Rectangle(contextMenuPoint.X - size / 2, contextMenuPoint.Y - size / 2, size, size);           
            int index = (int)e.Data.GetData(typeof(Int32));
            ReflectTools rt = new ReflectTools("EditorOfBIMS", "EditorOfBIMS", listItems[index][2]);
            rt.setPropertyInfo("Location", contextMenuPoint);
            rt.setPropertyInfo("MPanel", this.PanRight);
            //rt.setPropertyInfo("Image", ImageTools.getImage(listItems[index][1]));
           // rt.setPropertyInfo("Size", new System.Drawing.Size(100, 100));
            this.PanRight.Controls.Add((Control)rt.MObj);

        }

        private void PanRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void PanRight_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (PictureBox c in this.PanRight.Controls)
            { c.BorderStyle = BorderStyle.None; }
        }

        private void DFrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ArrayList a =new ArrayList() ;
                    foreach (PictureBox c in this.PanRight.Controls)
                    {

                        if (c.BorderStyle == BorderStyle.FixedSingle)
                        {
                            a.Add (PanRight.Controls.IndexOf(c));
                            //c.Dispose();
                        }       
                    }
                    for (int i = a.Count-1; i >=0; i--)
                    {
                        PanRight.Controls.RemoveAt((int)a[i]);
                    }

            }
        }

        private void BackgroundButton_Click(object sender, EventArgs e)
        {

            DialogResult a =this.mopenFileDialog.ShowDialog();
            if (a == DialogResult.OK)
            {
                if (this.mopenFileDialog.SafeFileName.EndsWith("jpg"))
                {
                    PanRight.BackgroundImage = Image.FromFile(this.mopenFileDialog.FileName);

                    bool Is_Exest= !Tools.xmlHelper.CreateXmlDocument("config.xml", "config", "1.0", "utf-8",null);

                    XmlDocument xmlDoc = new XmlDocument();

                    xmlDoc.Load("config.xml");

                    XmlNode root = xmlDoc.SelectSingleNode("config");
                    XmlNodeList nodeList = xmlDoc.SelectSingleNode("config").ChildNodes;

                    bool Is_Background = false;

                    foreach (XmlNode xn in nodeList)
                    {
                        XmlElement xe = (XmlElement)xn; //将子节点类型转换为XmlElement类型 

                        if(xe.Name == "Background")
                        {
                            xe.InnerText = this.mopenFileDialog.FileName;
                            Is_Background = true;
                        }
                        break;
                    }

                    if (!Is_Background)
                    {
                        XmlElement xe1 = xmlDoc.CreateElement("Background");
                        xe1.InnerText = this.mopenFileDialog.FileName;
                        root.AppendChild(xe1);
                    }

                    xmlDoc.Save("config.xml");
                }     
            } 
        }

        private void DFrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void b_sumbit_Click(object sender, EventArgs e)
        {
            if (tb_path.Text == "")
            {
                MessageBox.Show("请选择生成路径");
                return;
            }
            if (tb_buildingname.Text == "" )
            {
                MessageBox.Show("请输入建筑物名称");               
                return;
            }
            if (tb_floornum.Text == "")
            {
                MessageBox.Show("请输入楼层号");
                return;
            }
            int floornum;
            if(!int.TryParse(tb_floornum.Text,out floornum))
            {
                MessageBox.Show("楼层号必须是整数");
                return;
            }
           // bean.BuildingName = tb_buildingname.Text;

            string newPath = tb_path.Text+ tb_buildingname.Text + "_" + tb_floornum.Text;
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            foreach(BaseDevice bd in this.PanRight.Controls)
            {
                bd.saveToXML(tb_buildingname.Text, floornum, newPath);
            }
        }

        private void bt_selectPath_Click(object sender, EventArgs e)
        {
            if (mfolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tb_path.Text= mfolderBrowserDialog.SelectedPath;
            }
        }

        private void tb_Open_Click(object sender, EventArgs e)
        {
            mopenFileDialog.Filter = "配置文件(*.xml)|*.xml";
            mopenFileDialog.Multiselect = true;

            if (mopenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] files = mopenFileDialog.FileNames;
                foreach (string file in files)
                {
                    string[] filename = file.Split('.');
                    string typename = filename[filename.Length - 2];
                    BaseBean b = (BaseBean)XMLSerializerHelper.XmlDeserialize(ReflectTools.getType("Tools", "Tools", typename)
                        , file);
                    ReflectTools rt = new ReflectTools("EditorOfBIMS", "EditorOfBIMS", b.ClassName);
                    rt.setPropertyInfo("Bean", b);
                    rt.setPropertyInfo("Location", b.MPoint);
                    rt.setPropertyInfo("MPanel", this.PanRight);                  
                   
                    this.PanRight.Controls.Add((Control)rt.MObj);
                }
            }
        }


    }
}