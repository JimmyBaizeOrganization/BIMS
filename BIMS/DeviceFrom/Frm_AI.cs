using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace BIMS.DeviceFrom
{
    public partial class Frm_AI : Form
    {
        
        decimal[] data;
        public AIBean bean;
        BaseBean basebean;
        public Frm_AI(decimal[] d,AIBean b,int dur,BaseBean bb)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
            data = d;
            bean = b;
            basebean = bb;
            timer1.Interval = dur / 2;
            timer1_Tick(null, null);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = string.Format(bean.detail, data[bean.ioIndex]);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            String[][] s = new string[][]
            {
                new string[]{"CREAT_TIME","AI"+bean.ioIndex},
                new string[]{"时间",bean.detail}
            };
            String cmd = @"select CREAT_TIME,AI" + bean.ioIndex + ",STATE from "+ basebean.ClassName + " where  DEVICE_GUID ='" + basebean.getBeanKey() + "'   ";
            SearchForm frm = new SearchForm(s, cmd);
            frm.Show();
            frm.Focus();
            
        }
    }
}
