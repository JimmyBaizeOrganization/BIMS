using System;
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
        private HashSet<BaseDevice> devices = new HashSet<BaseDevice>();
        private HashSet<System.Timers.Timer> timers = new HashSet<System.Timers.Timer>();
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

                    ReflectTools rt = new ReflectTools("Service", "Service", b.ClassName);
                    rt.setPropertyInfo("Bean", b);

                    if (devices.Contains((BaseDevice)rt.MObj))
                    {
                        
                        Console.WriteLine("已存在该设备哎");
                        continue;
                    }
                    if (devices.Add((BaseDevice)rt.MObj))
                    {
                        foreach (System.Timers.Timer timer in timers)
                        {
                            if (timer.Interval == b.During)
                            {
                               // timer.Elapsed += new ElapsedEventHandler();
                                Console.WriteLine("成功添加一个设备");
                                break;
                            }
                        }
                        System.Timers.Timer time = new System.Timers.Timer(b.During);
                        //time.Elapsed += new ElapsedEventHandler();
                        time.Start();
                        timers.Add(time);
                        Console.WriteLine("成功添加一个设备和一个timer");
                    }
                    else
                    {
                        Console.WriteLine("成功设备失败");

                    }
                }
            }
        }

       
    }
}
