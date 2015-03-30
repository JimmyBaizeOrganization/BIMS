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
        BaseBean basebean;
        public Frm_DO(DOBean b, DOFunDelegates dofb,byte nowVaule, BaseBean bb)
        {
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
            mDOFunDelegates = dofb;
            bean = b;
            basebean = bb;
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

        private void label2_Click_1(object sender, EventArgs e)
        {
            String[][] s = new string[][]
            {
                new string[]{"CREAT_TIME","NEW_VAULE"},
                new string[]{"时间",bean.detail}
            };
            String cmd = @"select CREAT_TIME,NEW_VAULE,STATE from DO_RECORD where  DEVICE_GUID ='" + basebean.getBeanKey() + "'   ";
            SearchForm frm = new SearchForm(s, cmd);
            frm.Show();
            frm.Focus();
        }

        private void toggleSwitch1_Toggled_1(object sender, EventArgs e)
        {
            byte newVaule;
            if (this.toggleSwitch1.IsOn)
            {
                newVaule = 1;
            }
            else
            {
                newVaule = 0;
            }

            BIMSConnectState state = mDOFunDelegates.mDOControlDelegate(newVaule, (byte)bean.ioIndex);
            if (state != BIMSConnectState.OK)
            {
                MessageBox.Show(FunctionTools.GetEnumDes(state));

            }
        }

    

     
    }
}
