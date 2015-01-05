﻿using EditorOfBIMS.DeviceFrom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace EditorOfBIMS
{
 
    public abstract class BaseDevice : PictureBox
    {
        public static int imageSize = 30;
        //记录设备号。自动添加设备号
        static int deviceIndex = 0;

        public static int DeviceIndex
        {
            get { return BaseDevice.deviceIndex; }
            set { BaseDevice.deviceIndex = value; }
        }

        private Point mouse_offset = new Point();

        public Point Mouse_offset
        {
            get { return mouse_offset; }
            set { mouse_offset = value; }
        }
        private Panel mPanel;
        private ContextMenuStrip mContextMenuStrip;
        private Form mForm;

        public Form MForm
        {
            get { return mForm; }
            set { mForm = value; }
        }

        public Panel MPanel
        {
            get { return mPanel; }
            set { mPanel = value; }
        }
        public BaseDevice()
            : base()
        {
            this.Size = new Size(imageSize, imageSize);
            this.Location = new Point(100, 100);
            mContextMenuStrip = new ContextMenuStrip();
            mContextMenuStrip.Items.Add("属性" );
            mContextMenuStrip.Items.Add("删除");
            this.ContextMenuStrip = mContextMenuStrip;

            this.MouseMove += new MouseEventHandler(Common_MouseMove);
            this.MouseDown += new MouseEventHandler(Common_MouseDown);
            this.MouseClick += new MouseEventHandler(Common_MouseClick);
            this.MouseDoubleClick += new MouseEventHandler(Common_DoubleClick);
            this.mContextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(Common_ContextMenuStripClick);

           
        }
        private void Common_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = (Control)sender;
            if (e.Button == MouseButtons.Left)
            {
                control.Left = control.Left + e.X - mouse_offset.X;
                control.Top = control.Top + e.Y - mouse_offset.Y;

            }
        }
        private void Common_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(e.X, e.Y);
        }

        private void Common_MouseClick(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys != Keys.Control)
            {
                foreach (PictureBox c in mPanel.Controls)
                {
                    c.BorderStyle = BorderStyle.None;
                }
            }

            BorderStyle = BorderStyle.FixedSingle;
        }

        private void Common_DoubleClick(object sender, MouseEventArgs e)
        {
            if (mForm==null)
            {
                creatForm();
            }
            else 
            {
                mForm.Show();
            }
        }

        private void Common_ContextMenuStripClick(object sender, ToolStripItemClickedEventArgs e)
        {

            if (((ContextMenuStrip)sender).Items[0] == e.ClickedItem)
            {
                

                if (mForm==null || mForm.IsDisposed)
                {
                    creatForm();
                    mForm.Show();
                }
                else
                {
                    mForm.Show();
                    mForm.Focus();
                }
            }
            else if (((ContextMenuStrip)sender).Items[1] == e.ClickedItem)
            {
                //Console.WriteLine("1");
                this.Dispose();
            }
           
        }
        public abstract void creatForm();
        public abstract void saveToXML(string building,int floor,string path);
    }

   

    public class DED194E_9S1YK2K2 : BaseDevice
    {
        private Bean_DED194E_9S1YK2K2 bean;

        public Bean_DED194E_9S1YK2K2 Bean
        {
            get { return bean; }
            set { bean = value; }
        }
        public DED194E_9S1YK2K2()
        {
            bean = new Bean_DED194E_9S1YK2K2();
            //bean.MPoint = Mouse_offset;
            Image = ImageTools.getImage("DED194E_9S1YK2K2.png", imageSize, imageSize);
          //  Size = new System.Drawing.Size(20, 20);
            bean.DeviceNum = DeviceIndex++;
        }
        public override void creatForm()
        {
            MForm = new Frm_DED194E_9S1YK2K2(bean);
        }
        public override void saveToXML(string building,int  floor,string path)
        {
            
            bean.MPoint = Location;
            bean.BuildingName = building;
            bean.FloorNum = floor;
            XMLSerializerHelper.XmlSerialize(bean, path + @"\"+bean.BuildingName+bean.FloorNum+bean.DeviceNum+@".Bean_DED194E_9S1YK2K2.xml");
        }

    }

    public class AI : BaseDevice
    {

        public AIBean bean = new AIBean();
        public TreeNode mTreeNode;

        public override void creatForm()
        {
            MForm = new Frm_AI(bean);
            MForm.FormClosing += new FormClosingEventHandler(this.refreshView);
            MForm.Text = mTreeNode.Text +"的第"+ bean.inputIndex+"个输入端口";
        }
        private void refreshView(object o, FormClosingEventArgs a)
        {
            if (bean.useing)
            {
                this.Image = ImageTools.getImage(bean.imagePath, imageSize, imageSize);
                this.Visible = true;
                MPanel.Controls.Add(this);
                mTreeNode.Nodes[bean.inputIndex].BackColor = Color.Red;
            }
            else
            {
                this.Visible = false;
            }
        }
        public override void saveToXML(string building, int floor, string path)
        {
            bean.mpoint = Location;
        }
        public AI(int index, TreeNode tn)
        {
            bean.inputIndex = index;
            mTreeNode = tn;
            this.Disposed += new EventHandler(this.shutDownMe);
        }

        private void shutDownMe(object sender, EventArgs e)
        {
            mTreeNode.Nodes[bean.inputIndex].BackColor = Color.White;
        }

     
        public void openForm()
        {
            if (MForm == null || MForm.IsDisposed) creatForm();
            MForm.Show();
        }

        
    }
    public interface BoxDevice
    {
        void openChild(int index);
        
    }
    public class C2000MDxA : BaseDevice, BoxDevice
    {
        private TreeView treeView;
        private AI[] ais  =new AI[8];
        
        public TreeView TreeView
        {
            get { return treeView; }
            set { treeView = value; }
        }
        public TreeNode mTreeNode;
        private Bean_C2000MDxA bean;
        public Bean_C2000MDxA Bean
        {
            get { return bean; }
            set { bean = value; }
        }
        public C2000MDxA(TreeView t)
        {
            bean = new Bean_C2000MDxA();
            bean.DeviceNum = DeviceIndex++;
            this.Visible = false;
            treeView = t;
            mTreeNode = new TreeNode();
            mTreeNode.Text = "C2000MDxA(" + bean.DeviceNum+")";
            this.Name = mTreeNode.Text;
            treeView.Nodes.Add(mTreeNode);
            for (int i = 0; i < 8; i++) 
            {
                TreeNode node1 = new TreeNode();
                node1.Text = "AI" + i.ToString();
                mTreeNode.Nodes.Add(node1);
            }        
           
        }
        public override void creatForm()
        {
            MForm = new Frm_C2000MDxA(bean);
        }
        public  void openChild(int index)
        {
            if (index < 8)
            {
                if (ais[index] == null)
                {
                    ais[index] = new AI(index, mTreeNode);
                    ais[index].MPanel = MPanel;
                }
                if (ais[index].bean.useing)
                {
                    ais[index].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                }
                else
                {
                    ais[index].openForm();
                }
                
            }
        }
 
        public override void saveToXML(string building, int floor, string path)
        {

            bean.MPoint = Location;
            bean.BuildingName = building;
            bean.FloorNum = floor;
            ArrayList bs = new ArrayList();
            foreach (AI a in ais)
            {
                if (a!=null && a.bean.useing)
                {
                    bs.Add(a.bean);
                }
            }
            //bean.aiBeans = (AIBean[])bs.ToArray(typeof(AIBean));
            bean.aiBeans = bs.Cast<AIBean>().ToArray();
            XMLSerializerHelper.XmlSerialize(bean, path + @"\" + bean.BuildingName + bean.FloorNum + bean.DeviceNum + @".Bean_C200MDxA.xml");
        }
    }
}
