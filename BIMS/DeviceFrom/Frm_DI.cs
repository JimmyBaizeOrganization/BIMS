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
    public partial class Frm_DI : Form
    {
        
        
        public DIBean bean;
        public BaseBean basebean;
        public Frm_DI(DIBean b, BaseBean bb)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
            bean = b;
            basebean = bb;
            if (bean.detail != null) { 
            label1.Text = bean.detail;
             }
            else
            {
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            String[][] s = new string[][]
            {
                new string[]{"CREAT_TIME","DI"+bean.ioIndex%8},
                new string[]{"时间",bean.detail}
            };
            String cmd = @"select CREAT_TIME,DI" + bean.ioIndex%8 + ",STATE from " + basebean.ClassName + " where  DEVICE_GUID ='" + basebean.getBeanKey() + "'   ";
            SearchForm frm = new SearchForm(s, cmd);
            frm.Show();
            frm.Focus();
        }

     
    }
}
