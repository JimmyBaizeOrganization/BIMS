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
    public partial class Frm_DO : Form
    {
        
        
        public DOBean bean;
        DOFunDelegates mDOFunDelegates;
        public Frm_DO(DOBean b, DOFunDelegates dofb,byte nowVaule)
        {
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
            mDOFunDelegates = dofb;
            bean = b;
            if (nowVaule == 0)
            {
               // toggleSwitch1.IsOn = false;
            }
            else if (nowVaule == 1)
            {
               // toggleSwitch1.IsOn = true;
            }
           
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            byte newVaule;
            //if (this.toggleSwitch1.IsOn)
            //{
            //    newVaule = 1;
            //}
            //else
            //{
            //    newVaule = 0;
            //}

            //BIMSConnectState state = mDOFunDelegates.mDOControlDelegate(newVaule, (byte)bean.ioIndex);
            //if (state != BIMSConnectState.OK)
            //{
            //    MessageBox.Show(FunctionTools.GetEnumDes(state));
               
            //}
        }

     
    }
}
