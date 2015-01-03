using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Tools;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Service
{
    public partial class Frm_Main : Form
    {

        private Hashtable devices = new Hashtable();
        private Hashtable timers = new Hashtable();
        //创建日志记录组件实例
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

        }

        private void bt_OpenFile_Click(object sender, EventArgs e)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(Environment.CurrentDirectory);
            mopenFileDialog.InitialDirectory = dirinfo.Parent.Parent.Parent.FullName;
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

                    ReflectTools rt = new ReflectTools("Service", "Service", b.ClassName,new object[]{b});
                             
                    if (devices.Contains(b.getBeanKey()))
                    {
                        log.Info("已存在该设备哎");
                        continue;
                    }

                    if (b.During <= 0)
                    {
                        continue;
                    }
                    BaseDevice bd = (BaseDevice)rt.MObj;
                    if(timers.ContainsKey(b.During))
                    {
                        System.Timers.Timer t = (System.Timers.Timer)timers[b.During];
                       t.Elapsed += new ElapsedEventHandler(bd.periodWork);
                        devices.Add(b.getBeanKey(), rt.MObj);
                        log.Info("成功添加一个设备");                        
                        continue;
                       
                    }                    
                   
                    System.Timers.Timer time = new System.Timers.Timer(b.During);
                   time.Elapsed += new ElapsedEventHandler(bd.periodWork);
                    time.Start();

                    timers.Add(b.During,time);
                    devices.Add(b.getBeanKey(),rt.MObj);
                    log.Info("成功添加一个设备和一个timer");  
                  
                    
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            mdataGridView.Rows.Clear();

            foreach (DictionaryEntry de in devices)
            {
                BaseDevice d = (BaseDevice)de.Value;
                IBeanTool ibean = (IBeanTool)d;
                BaseBean b = ibean.getBean();

                if (!mcheckedListBox.GetItemChecked(0) || b.BuildingName == textBox_building.Text) 
                {
                    if (!mcheckedListBox.GetItemChecked(1) || b.FloorNum  == int.Parse (textBox_floor .Text))
                    {
                        if (!mcheckedListBox.GetItemChecked(2) || b.DeviceNum == int.Parse(textBox_deviceNum.Text))
                        {
                            if (!mcheckedListBox.GetItemChecked(3) || b.DeviceType  == textBox_type .Text)
                            {
                                mdataGridView.Rows.Add(b.BuildingName, b.FloorNum, b.DeviceNum, b.DeviceType);
                            }
                        }
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            mdataGridView.Rows.Clear();

            foreach (DictionaryEntry de in devices)
            {
                BaseDevice d = (BaseDevice)de.Value;
                IBeanTool ibean = (IBeanTool)d;
                BaseBean b = ibean.getBean();
                mdataGridView.Rows.Add(b.BuildingName, b.FloorNum, b.DeviceNum, b.DeviceType);
            } 

            
            //for (int i = 0; i < mdataGridView.RowCount; i++)
            //{
            //    if ( !mcheckedListBox.GetItemChecked(0))
            //    {
            //        if ( !mcheckedListBox.GetItemChecked(1))
            //        {
            //            if (!mcheckedListBox.GetItemChecked(2))
            //            {
            //                if ( !mcheckedListBox.GetItemChecked(3))
            //                {
            //                    mdataGridView.Rows.AddCopy(i);
            //                }
            //            }
            //        }
            //    }
                //if ((string)mdataGridView.Rows[i].Cells[0].Value == textBox_building.Text || !mcheckedListBox.GetItemChecked(0))
                //{
                //    if ((string)mdataGridView.Rows[i].Cells[1].Value == textBox_floor.Text || !mcheckedListBox.GetItemChecked(1))
                //    {
                //        if ((string)mdataGridView.Rows[i].Cells[2].Value == textBox_deviceNum.Text || !mcheckedListBox.GetItemChecked(2))
                //        {
                //            if ((string)mdataGridView.Rows[i].Cells[3].Value == textBox_type.Text || !mcheckedListBox.GetItemChecked(3))
                //            {
                //                mdataGridView.Rows.AddCopy(i);
                //            }
                //        }
                //    }
                //}
         

            //for (int i = 0; i < mdataGridView.RowCount; i++)
            //{ mdataGridView.Rows.RemoveAt(0); }
                     
        }

       
    }
}
