using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows .Forms;

namespace BIMS
{
    class BaseDevice: PictureBox 
    {
        private Form mform;

        public Form Mform
        {
            get { return mform; }
            set { mform = value; }
        }
        public BaseDevice()
        {
            this.MouseEnter += new EventHandler(Common_MouseEnter);
        }
          private void Common_MouseEnter(object sender, EventArgs e)
        {
            if (Mform == null || Mform.IsDisposed) 
            { 
            newform() ;
            }
            //Mform.Location =new PointToClient()
            Mform.Show();
            Mform.Focus();
        }
          public virtual void newform() { }
    }

    class DED194E_9S1YK2K2 : BaseDevice
    { 

        public DED194E_9S1YK2K2()
        {
           
        }
      
    }
}
