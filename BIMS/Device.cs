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
        { 
            Mform.Dispose();
        }
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
    public static class PublicResource
    {
        public static Hashtable timers = new Hashtable();
        public static void addTimer(double timespace, ElapsedEventHandler handler)
        {
            System.Timers.Timer timer;
            if (!timers.ContainsKey(timespace))
            {
               
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
        //public static DataSet  
    }
    class DED194E_9S1YK2K2 : BaseDevice
    {
        private Bean_DED194E_9S1YK2K2 bean;
        private string beanKey;

        decimal[] dataVaule = new decimal[9];
        private static string imageURL = "ElectricityGauge.png";
       // private decimal[] dataVaule = new decimal[9];
        
        string scmd;
        public static string ImageURL
        {
            get { return DED194E_9S1YK2K2.imageURL; }
            set { DED194E_9S1YK2K2.imageURL = value; }
        }
        
        public DED194E_9S1YK2K2(Bean_DED194E_9S1YK2K2 b)
        {    
            bean = b;
            beanKey = bean.getBeanKey();
            scmd = @"select * from (select VOLTAGE,I,STATE,P,Q,S,FREQ,PF,DCVAL from DED194E_9S1YK2K2 where DEVICE_GUID='" + beanKey + "' order by CREAT_TIME desc) where rownum=1 ";
            periodWork(null, null);
            PublicResource.addTimer(b.During, new ElapsedEventHandler(this.periodWork));
        }

        public override  void newform() 
        {
            Mform = new Frm_DED194E_9S1YK2K2(dataVaule,bean.During);
        }
        public void periodWork(object o, ElapsedEventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(OracleTools.connString))
            {
                OracleCommand cmd = new OracleCommand(scmd, conn);
                conn.Open();
                OracleDataReader mOracleDataReader = cmd.ExecuteReader();
               
                while (mOracleDataReader.Read())
                {
                    
                    
                    Frm_DED194E_9S1YK2K2 f = (Frm_DED194E_9S1YK2K2)Mform;
                    
                    dataVaule[0] = (decimal)mOracleDataReader["VOLTAGE"];
                    dataVaule[1] = (decimal)mOracleDataReader["I"];
                    dataVaule[2] = decimal.Parse((string)mOracleDataReader["STATE"]);
                    dataVaule[3] = (decimal)mOracleDataReader["P"];
                    dataVaule[4] = (decimal)mOracleDataReader["Q"];
                    dataVaule[5] = (decimal)mOracleDataReader["S"];
                    dataVaule[6] = (decimal)mOracleDataReader["FREQ"];
                    dataVaule[7] = (decimal)mOracleDataReader["PF"];
                    dataVaule[8] = (decimal)mOracleDataReader["DCVAL"];
                   
                }
            }  
            
        }
       
    }

}
