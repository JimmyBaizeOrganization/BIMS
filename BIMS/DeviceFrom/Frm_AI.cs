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
        public Frm_AI(decimal[] d,AIBean b,int dur)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
            data = d;
            bean = b;
            timer1.Interval = dur / 2;
            timer1_Tick(null, null);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = string.Format(bean.detail, data[bean.inputIndex]);
        }
    }
}
