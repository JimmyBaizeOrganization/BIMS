using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows .Forms;
using System.Drawing;
using Tools;
using Oracle.DataAccess.Client;
using System.Data;
using System.Timers;
using System.Collections;

namespace BIMS
{
    public static class PublicResource
    {
        public static Hashtable timers = new Hashtable();
        public static void addTimer(double timespace, ElapsedEventHandler handler)
        {
            System.Timers.Timer timer;
            if(!timers.ContainsKey(timespace))
            {
                Console.WriteLine("添加一个itmer");
                 timer = new System.Timers.Timer(timespace);
                 timer.Start();
                 timers.Add(timespace, timer);
            }
            else
            {
                timer = (System.Timers.Timer)timers[(object)timespace];
            }
            timer.Elapsed += handler;
        }
    }
    public abstract  class BaseDevice: PictureBox 
    {
        private Form mform;
        public Form Mform
        {
            get { return mform; }
            set { mform = value; }
        }
        public BaseDevice()
        {
            this.MouseDown += new MouseEventHandler(Common_MouseDown);
            //this.MouseEnter += new EventHandler(Common_MouseEnter);
            //this.MouseLeave += new EventHandler(Common_MouseLeave);
        }

        private void Common_MouseDown(object sender, EventArgs e) 
        {
            if (Mform == null || Mform.IsDisposed)
            {
                newform();
                Mform.LostFocus += new EventHandler(Common_LostFocus);
            }

            Mform.Show();
            Mform.Focus();

            if (MousePosition.X < 1280)
            {
                if (MousePosition.Y < 720)
                { Mform.Location = new Point(MousePosition.X , MousePosition.Y ); }
                else
                { Mform.Location = new Point(MousePosition.X , MousePosition.Y - Mform.Size.Height ); }
            }
            else
            {
                if (MousePosition.Y < 720)
                { Mform.Location = new Point(MousePosition.X - Mform.Size.Width , MousePosition.Y ); }
                else
                { Mform.Location = new Point(MousePosition.X - Mform.Size.Width , MousePosition.Y - Mform.Size.Height ); }
            }
        }

        private void Common_LostFocus(object sender, EventArgs e)
        { Mform.Hide(); }
        //  private void Common_MouseEnter(object sender, EventArgs e)
        //{
        //    if (Mform == null || Mform.IsDisposed) 
        //    { 
        //         newform() ;
        //    }

        //    if (MousePosition.X < 1280)
        //    {
        //        if (MousePosition.Y < 720)
        //        { Mform.Location = new Point(MousePosition.X - 10, MousePosition.Y - 10); } 
        //        else
        //        { Mform.Location = new Point(MousePosition.X - 10, MousePosition.Y - Mform.Size.Height - 10); }
        //    }
        //    else
        //    {
        //        if (MousePosition.Y < 720)
        //        { Mform.Location = new Point(MousePosition.X - Mform.Size.Width - 10, MousePosition.Y - 10); }
        //        else
        //        { Mform.Location = new Point(MousePosition.X - Mform.Size.Width - 10, MousePosition.Y - Mform.Size.Height - 10); }
        //    }
               
        //    Mform.Show();
        //    Mform.Focus();
        //}
        //  private void Common_MouseLeave(object sender, EventArgs e) 
        //  {
        //      //Mform.Hide();
        //  }


          public virtual  void newform() { }
    }

    class DED194E_9S1YK2K2 : BaseDevice
    {
        private Bean_DED194E_9S1YK2K2 bean;
        private string beanKey;
        private string scmd;
        private OracleDataReader mOracleDataReader;
        private static string imageURL = "ElectricityGauge.png";

        public static string ImageURL
        {
            get { return DED194E_9S1YK2K2.imageURL; }
            set { DED194E_9S1YK2K2.imageURL = value; }
        }
        
        public DED194E_9S1YK2K2(Bean_DED194E_9S1YK2K2 b)
        {
            bean = b;
            beanKey = bean.getBeanKey();
            scmd = @"select 	VOLTAGE,I,STATE,P,Q,S,FREQ,PF,DCVAL from DED194E_9S1YK2K2 where DEVICE_GUID='" + beanKey + "' and rownum<2 order by CREAT_TIME desc";

            //System.Timers.Timer timer = new System.Timers.Timer(5000);
            //timer.Elapsed += new ElapsedEventHandler(this.periodWork);
            //timer.Start();
            PublicResource.addTimer(b.During, new ElapsedEventHandler(this.periodWork));
        }

        public override  void newform() 
        {
            Mform = new Frm_DED194E_9S1YK2K2(mOracleDataReader);
        }
        public void periodWork(object o, ElapsedEventArgs e)
        {
            Console.WriteLine("23333333");
            using (OracleConnection conn = new OracleConnection(OracleTools.connString))
            {                
                OracleCommand cmd = new OracleCommand(scmd, conn);
                conn.Open();
                mOracleDataReader = cmd.ExecuteReader();
            }
        }
       
    }
}
