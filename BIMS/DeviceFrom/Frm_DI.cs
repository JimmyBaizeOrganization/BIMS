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
        public Frm_DI(DIBean b)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
            bean = b;
            if (bean.detail != null) { 
            label1.Text = bean.detail;
             }
            else
            {
                this.Close();
            }
            this.Size = label1.Size;
        }

     
    }
}
