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

namespace EditorOfBIMS.DeviceFrom
{
    public partial class Frm_C2000MDxA : Form
    {
       
        private Bean_C2000MDxA bean;
        public Frm_C2000MDxA(Bean_C2000MDxA b)
        {
            InitializeComponent();
            bean = b;
        }
    }
}
