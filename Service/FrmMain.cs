using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Tools;

namespace Service
{
    public partial class Frm_Main : Form
    {

        private Hashtable devices = new Hashtable();
        private Hashtable timers = new Hashtable();
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

        }

        private void bt_OpenFile_Click(object sender, EventArgs e)
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

                    ReflectTools rt = new ReflectTools("Service", "Service", b.ClassName,new object[]{b});
                             
                    if (devices.Contains(b.getBeanKey()))
                    {
                        Console.WriteLine("已存在该设备哎");
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
                        Console.WriteLine("成功添加一个设备");
                        continue;
                       
                    }                    
                   
                    System.Timers.Timer time = new System.Timers.Timer(b.During);
                    time.Elapsed += new ElapsedEventHandler(bd.periodWork);
                    time.Start();

                    timers.Add(b.During,time);
                    devices.Add(b.getBeanKey(),rt.MObj);
                    Console.WriteLine("成功添加一个设备和一个timer");
                  
                }
            }
        }

       
    }
}
