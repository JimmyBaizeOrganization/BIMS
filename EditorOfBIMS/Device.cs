using System;
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
            mContextMenuStrip = new ContextMenuStrip();
            mContextMenuStrip.Items.Add("属性" );
            mContextMenuStrip.Items.Add("删除");
            this.ContextMenuStrip = mContextMenuStrip;

            this.MouseMove += new MouseEventHandler(Common_MouseMove);
            this.MouseDown += new MouseEventHandler(Common_MouseDown);
            this.MouseClick += new MouseEventHandler(Common_MouseClick);
            this.MouseDoubleClick += new MouseEventHandler(Common_DoubleClick);
            this.mContextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(Common_ContextMenuStripClick);

            deviceIndex++;
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
            Image = ImageTools.getImage("ElectricityGauge.png");
            Size = new System.Drawing.Size(100, 100);
            bean.DeviceNum = DeviceIndex;
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
            XMLSerializerHelper.XmlSerialize(bean, path + @"\"+bean.DeviceNum+@".Bean_DED194E_9S1YK2K2.xml");
        }

    }
}
