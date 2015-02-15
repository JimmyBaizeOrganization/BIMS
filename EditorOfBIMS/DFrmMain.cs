using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tools;
using System.Reflection;
using System.Collections;
using System.Xml;
using System.IO;


namespace EditorOfBIMS
{
    public partial class DFrmMain : Form 
    {

        String[][] listItems = { new String[4] { "电量仪", "DED194E_9S1YK2K2.png","DED194E_9S1YK2K2","Left" }
                               , new String[4] { "三相电量仪", "DED194E_9S1YK4K4.png","DED194E_9S1YK4K4","Left" }
                               , new String[4] { "C2000MDxA", "C2000MDxA.jpg","C2000MDxA","Right"}
                               , new String[4] { "C2000MD82", "C2000MDxA.png","C2000MD82","Right" }
                               , new String[4] { "C2000M281", "ElectricityGauge.png","C2000M281","Right" }
                               , new String[4] { "C2000MH08(交流电开关量)", "C2000MH08.jpg","C2000MH08","Left"}
                               , new String[4] { "HIKVISION(海康威视数字摄像头)", "HIKVISION.jpg","HIKVISION","Left"}

};
        public DFrmMain()
        {
            InitializeComponent();
            treeViewRight.ContextMenuStrip = treeViewContext1;
        }

        private void DFrmMain_Load(object sender, EventArgs e)
        {
            //初始化  保存路径默认设置\
            DirectoryInfo dirinfo = new DirectoryInfo(Environment.CurrentDirectory);
            tb_path.Text = dirinfo.Parent.Parent.Parent.Parent.FullName+@"\bean";
            // = System.Environment.CurrentDirectory;
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
            for (int i = 0; i < listItems.Length; i++)
            {
                listBox1.Items.Add(listItems[i][0]);

              
            }
        }




        private void iLBC_Left_MouseDown(object sender, MouseEventArgs e)
        {
            ////调用DoDragDrop方法
            ////iLBC_Left .SelectedIndexChanged += new EventHandler (object sender,EventArgs e);
            //if (this.iLBC_Left.SelectedItem != null)
            //{
            //    Console.WriteLine ( iLBC_Left.Items .Count );
            //    this.iLBC_Left.DoDragDrop(this.iLBC_Left.SelectedIndex, DragDropEffects.Copy);
            //}
        }
        private void PanRight_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void PanRight_DragDrop(object sender, DragEventArgs e)
        {
            //图片的大小
            //int size = 60;
            Point contextMenuPoint = this.PanRight.PointToClient(Control.MousePosition);
            //Rectangle rect = new Rectangle(contextMenuPoint.X - size / 2, contextMenuPoint.Y - size / 2, size, size);           
            int index = (int)e.Data.GetData(typeof(Int32));
            ReflectTools rt = new ReflectTools("EditorOfBIMS", "EditorOfBIMS", listItems[index][2]);
            rt.setPropertyInfo("Location", contextMenuPoint);
            rt.setPropertyInfo("MPanel", this.PanRight);
            //rt.setPropertyInfo("Image", ImageTools.getImage(listItems[index][1]));
            rt.setPropertyInfo("Size", new System.Drawing.Size(100, 100));
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

            string []  newPath  = new string[2];
            newPath [0]= tb_path.Text + @"\Client\" + tb_buildingname.Text + "_" + tb_floornum.Text;
            if (!Directory.Exists(newPath[0]))
            {
                Directory.CreateDirectory(newPath[0]);
            }
            newPath[1] = tb_path.Text + @"\Service\" + tb_buildingname.Text + "_" + tb_floornum.Text;
             if (!Directory.Exists(newPath[1]))
            {
                Directory.CreateDirectory(newPath[1]);
            }
            foreach(BaseDevice bd in this.PanRight.Controls)
            {
                bd.saveToXML(tb_buildingname.Text, floornum, newPath);
            }
            MessageBox.Show("保存成功 生成路径为" + newPath);
        }

        private void bt_selectPath_Click(object sender, EventArgs e)
        {
            if (tb_path.Text != "")
            {
                mfolderBrowserDialog.SelectedPath = tb_path.Text;
            }
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
                    BaseBean b = BeanTools.getBeanFromXML(typename, file);
                                         
                    ReflectTools rt = new ReflectTools("EditorOfBIMS", "EditorOfBIMS", b.ClassName,new object[]{new object[]{b,this.PanRight,this.treeViewRight}});
                    //rt.setPropertyInfo("Bean", b);
                    rt.setPropertyInfo("Location", b.MPoint);
                  //  rt.setPropertyInfo("MPanel", this.PanRight);                  
                   
                    this.PanRight.Controls.Add((Control)rt.MObj);
                }
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Point contextMenuPoint = this.PanRight.PointToClient(Control.MousePosition);   
            int index = listBox1.SelectedIndex;

            switch (listItems[index][3].ToString())
            {
                case "Left":
                    ReflectTools rt = new ReflectTools("EditorOfBIMS", "EditorOfBIMS", listItems[index][2]);
                    rt.setPropertyInfo("MPanel", this.PanRight);
                    this.PanRight.Controls.Add((Control)rt.MObj);
                    break;
                case "Right":
                    rt = new ReflectTools("EditorOfBIMS", "EditorOfBIMS", listItems[index][2], new object[] {this.PanRight, this.treeViewRight });
                   // rt.setPropertyInfo("MPanel", this.PanRight);
                    this.PanRight.Controls.Add((Control)rt.MObj);
                    break;
            }           
        }

        private void treeViewRight_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //Console.WriteLine(treeViewRight.SelectedNode);
            //Console.WriteLine(treeViewRight.SelectedNode.Index);
            try
            {
                Control[] ctls = this.PanRight.Controls.Find(treeViewRight.SelectedNode.Parent.Text, false);
                if (ctls.Length > 0)
                {
                    foreach (PictureBox p in this.PanRight.Controls)
                    {
                        p.BorderStyle = BorderStyle.None;
                    }
                    BoxDevice bd = (BoxDevice)ctls[0];
                    bd.showChild(treeViewRight.SelectedNode.Index);
                }
                else
                {
                    MessageBox.Show("奇怪的异常");
                }
            }
            catch
            {

            }
       
        }

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                       
            if (this.treeViewRight.SelectedNode.Level == 0)
            {
                Control[] ctls = this.PanRight.Controls.Find(treeViewRight.SelectedNode.Text, false); 
                BaseDevice bd =(BaseDevice) ctls[0];
                bd.showForm();
            }
            else if (this.treeViewRight.SelectedNode.Level == 1)
            {
                Control[] ctls = this.PanRight.Controls.Find(treeViewRight.SelectedNode.Parent.Text, false); 
                BoxDevice bd = (BoxDevice)ctls[0];
                bd.showChildAttri(treeViewRight.SelectedNode.Index);
            }
           
        }
        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string searchtext = "";
            if (this.treeViewRight.SelectedNode.Level == 0)
            {
                searchtext = treeViewRight.SelectedNode.Text;
            }
            else if (this.treeViewRight.SelectedNode.Level == 1)
            {
                searchtext = treeViewRight.SelectedNode.Parent.Text;
            }
            Control[] ctls = this.PanRight.Controls.Find(searchtext, false);
            if (ctls.Length > 0)
            {
                if (this.treeViewRight.SelectedNode.Level == 0)
                {
                    BoxDevice bd = (BoxDevice)ctls[0];
                    bd.delectMe();
                    this.treeViewRight.Nodes.Remove(this.treeViewRight.SelectedNode);
                }
                else if (this.treeViewRight.SelectedNode.Level == 1)
                {
                    BoxDevice bd = (BoxDevice)ctls[0];
                    bd.delectChild(treeViewRight.SelectedNode.Index);
                }
            }
        }
        

    }
}