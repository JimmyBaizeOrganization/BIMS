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
using BIMS.DeviceFrom;

namespace BIMS
{
    public class StateRegister
    {
        private int oldState;
        public StateRegister(int initState)
        {
            oldState = initState;
        }
        public bool checkVaule(int newState)
        {
            if (oldState == newState)
            {
                return false;
            }
            else
            {
                oldState = newState;
                return true;
            }
        }
    }
    public abstract  class BaseDevice: PictureBox 
    {
        public static int imageSize = 30;
        private Form mform;
        public Form Mform
        {
            get { return mform; }
            set { mform = value; }
        }
        public StateRegister connectState = new StateRegister(0);
        public void checkConnectState(int newState){
            if(connectState.checkVaule(newState))
            {
                changeImageState(newState == 0);
            }
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
          public virtual  void newform() { }
          public virtual void changeImageState(bool state) { }
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
    public interface InterfaceDevice
    {
        BaseDevice[] getAllDevice();
    }
    class DED194E_9S1YK2K2 : BaseDevice, InterfaceDevice
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
        public BaseDevice[] getAllDevice()
        {
            this.Image = ImageTools.getImage(ImageURL, imageSize, imageSize);
            this.Size = new Size(imageSize,imageSize);
            this.Location = bean.MPoint;
            return new BaseDevice[]{this};
        }
        public override  void newform() 
        {
            Mform = new Frm_DED194E_9S1YK2K2(dataVaule,bean.During);
        }
        public override void changeImageState(bool state)
        {
            if (state)
            {
                this.Image = ImageTools.getImage(ImageURL, imageSize, imageSize);
            }
            else
            {
                this.Image = ImageTools.MakeGrayscale(ImageURL, imageSize, imageSize);
            }
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
                changeImageState(0 == dataVaule[2]);
            }  
            
        }
       
    }
    public class AI:BaseDevice
    {
        public AIBean bean;
        decimal[] dataVaule;
        int druing;
     
        public override void newform()
        {
            Mform = new Frm_AI(dataVaule, bean,druing);
        }
        public AI(AIBean b, int dur, decimal[] d)
        {
            bean = b;
            dataVaule = d;
            druing = dur;
            this.Image = ImageTools.getImage(bean.imagePath, imageSize, imageSize);
            this.Size = Image.Size;
            this.Location = bean.mpoint;
        }
        public override void changeImageState(bool state)
        {
            if (state)
            {
                this.Image = ImageTools.getImage(bean.imagePath, imageSize, imageSize);
            }
            else
            {
                this.Image = ImageTools.MakeGrayscale(bean.imagePath, imageSize, imageSize);
            }
        }
    }
    public class DI : BaseDevice
    {
        public DIBean bean;
        
      
        public StateRegister vauleState ;
        public string imagePath;
        public override void newform()
        {
            Mform = new Frm_DI( bean);
        }
        public DI(DIBean b)
        {
            bean = b;          
            
            this.Location = bean.mpoint;
            if(bean.normalVaule)
            {
                vauleState = new StateRegister(1);
                imagePath = bean.imagePath;
            }
            else{
                 vauleState = new StateRegister(0);
                 imagePath = bean.imageClosePath;
            }
            this.Image = ImageTools.getImage(imagePath, imageSize, imageSize);
            this.Size = Image.Size;
        }
        public override void changeImageState(bool state)
        {
            if (state)
            {
                this.Image = ImageTools.getImage(imagePath, imageSize, imageSize);
            }
            else
            {
                this.Image = ImageTools.MakeGrayscale(imagePath, imageSize, imageSize);
            }
        }
        public void changeInputState(int newVaule)
        {
            if (vauleState.checkVaule(newVaule))
            {
                if (newVaule == 0)
                {
                    imagePath = bean.imageClosePath;
                }
                else
                {
                    imagePath = bean.imagePath;
                }
            }
        }
    }
    public class C2000MDxA: InterfaceDevice
    {
        public Bean_C2000MDxA bean;
        private string beanKey;
        private string scmd;
        decimal[] dataVaule = new decimal[11];
        delegate decimal CalHandler(decimal x) ;
        private  CalHandler mCalHandler;
        public AI[] ais = new AI[8];
        public DI[] dis  =new DI[2];
        public static class CalFunction
        {
            public static decimal ICalFun(decimal v)
            {
                if (v < 0x8000)
                {
                    return ((v * 5) * 1000 / 4080000) / 240;
                }
                else
                {
                    return ((65535 - v + 1) * 5) * 1000 / 4080000 / 240;
                }
            }
            public static decimal VCalFun(decimal v)
            {
                if (v < 0x8000)
                {
                    return ((v * 5) * 1000 / 4080000);
                }
                else
                {
                    return ((65535 - v + 1) * 5) * 1000 / 4080000;
                }
            }
        }
        public C2000MDxA(Bean_C2000MDxA b)
        {
            bean = b;
            beanKey = bean.getBeanKey();
            if (bean.VorI)
            {
                mCalHandler = new CalHandler(CalFunction.VCalFun);
            }
            else
            {
                mCalHandler = new CalHandler(CalFunction.ICalFun);
            }
            scmd = @"select * from (select STATE,AI0,AI1,AI2,AI3,AI4,AI5,AI6,AI7,DI0,DI1 from C2000MDXA where DEVICE_GUID='" + beanKey + "' order by CREAT_TIME desc) where rownum=1 ";
           
           
           
        }
        public BaseDevice[] getAllDevice()
        {
            ArrayList devices = new ArrayList();
            if (bean.aiBeans != null) { 
                foreach (AIBean aib in bean.aiBeans)
                {
                    ais[aib.inputIndex] = new AI(aib, bean.During, dataVaule);
                    devices.Add(ais[aib.inputIndex]);
                }
            }
            if (bean.diBeans != null)
            { 
                foreach (DIBean dib in bean.diBeans)
                {
                    dis[dib.inputIndex-8] = new DI(dib);
                    devices.Add(dis[dib.inputIndex - 8]);
                }
            }

            periodWork(null, null);
            PublicResource.addTimer(bean.During, new ElapsedEventHandler(this.periodWork));

            return  (BaseDevice[])devices.Cast<BaseDevice>().ToArray();
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
                    
                    dataVaule[0] = (decimal)mOracleDataReader["AI0"];
                    dataVaule[1] = (decimal)mOracleDataReader["AI1"];
                    dataVaule[2] = (decimal)mOracleDataReader["AI2"];
                    dataVaule[3] = (decimal)mOracleDataReader["AI3"];
                    dataVaule[4] = (decimal)mOracleDataReader["AI4"];
                    dataVaule[5] = (decimal)mOracleDataReader["AI5"];
                    dataVaule[6] = (decimal)mOracleDataReader["AI6"];
                    dataVaule[7] = (decimal)mOracleDataReader["AI7"];
                    dataVaule[8] = decimal.Parse((string)mOracleDataReader["DI0"]);
                    dataVaule[9] = decimal.Parse((string)mOracleDataReader["DI1"]);
                    dataVaule[10] = decimal.Parse((string)mOracleDataReader["STATE"]);

                    
                }
                if (bean.aiBeans != null) { 
                foreach (AIBean aib in bean.aiBeans)
                    {
                        if (aib.useing)
                        {
                            dataVaule[aib.inputIndex] = FunctionTools.calculateByString(mCalHandler(dataVaule[0]), aib.function);
                            ais[aib.inputIndex].changeImageState(0 == dataVaule[10]);
                        }
                        
                    }
                }
                if (bean.diBeans != null)
                {
                    foreach (DIBean dib in bean.diBeans)
                    {
                        if (dib.useing)
                        {

                            dis[dib.inputIndex - 8].changeInputState((int)dataVaule[dib.inputIndex]);
                            dis[dib.inputIndex-8].changeImageState(0 == dataVaule[10]);
                        }
                    }
                }
               
            }

        }
    }

}
