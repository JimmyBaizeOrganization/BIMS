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
using System.Net.Sockets;
using System.Net;

namespace BIMS
{
    public class StateRegister<T>
    {
        public T oldState;
        public StateRegister(T initState)
        {
            oldState = initState;
        }
        public bool checkVaule(T newState)
        {
            if (oldState.Equals(newState))
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
        public BaseBean bean;
        public static int imageSize = 30;
        private Form mform;
        public Form Mform
        {
            get { return mform; }
            set { mform = value; }
        }
        public StateRegister<bool> connectState = new StateRegister<bool>(true);
        //public void checkConnectState(int newState){
        //    if(connectState.checkVaule(newState))
        //    {
        //        changeImageState(newState == 0);
        //    }
        //}
        public BaseDevice()
        {
            //this.MouseDown += new MouseEventHandler(Common_MouseDown);
           // this.MouseEnter += new EventHandler(Common_MouseEnter);
            
            this.MouseEnter += new EventHandler(Common_MouseDown);
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
          public virtual  void newform() {
              
          }
          

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
        Control[] getAllDevice();
       
    }
    class DED194E_9S1YK2K2 : BaseDevice, InterfaceDevice
    {
        
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
        public Control[] getAllDevice()
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
            if (connectState.checkVaule(state))
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
        public AIBean iobean;
        decimal[] dataVaule;
        int druing;
     
        public override void newform()
        {
            Mform = new Frm_AI(dataVaule, iobean, druing);
        }
        public AI(AIBean b, int dur, decimal[] d)
        {
            iobean = b;
            dataVaule = d;
            druing = dur;
            this.Image = ImageTools.getImage(iobean.imagePath, imageSize, imageSize);
            this.Size = Image.Size;
            this.Location = iobean.mpoint;
        }
        public override void changeImageState(bool state)
        {
            if (connectState.checkVaule(state))
            {
                if (state)
                {
                    this.Image = ImageTools.getImage(iobean.imagePath, imageSize, imageSize);
                }
                else
                {
                    this.Image = ImageTools.MakeGrayscale(iobean.imagePath, imageSize, imageSize);
                }
            }
        }
    }
    public class DI : BaseDevice
    {
        public DIBean bean;
        
      
        public StateRegister<int> vauleState ;
        
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
                vauleState = new StateRegister<int>(1);
                imagePath = bean.imagePath;
            }
            else{
                vauleState = new StateRegister<int>(0);
                 imagePath = bean.imageClosePath;
            }
            this.Image = ImageTools.getImage(imagePath, imageSize, imageSize);
            this.Size = Image.Size;
        }
        public override void changeImageState(bool state)
        {
            if (connectState.checkVaule(state))
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
    /// <summary>
    /// 控制DO输出，去执行TCPIP连接，返回值是改变之后的值，如果控制失败，则报警，返回值为原来的值
    /// </summary>
    /// <param name="newVaule"></param>
    /// <returns></returns>
    public class DOFunDelegates
    {
        public delegate Tools.BIMSConnectState DOControlDelegate(byte newVaule, byte index);
        public delegate byte DOGetVauleDelegate(byte index);
        public DOControlDelegate mDOControlDelegate;
        public DOGetVauleDelegate mDOGetVauleDelegate;
        public DOFunDelegates( DOControlDelegate doc)
        {
            this.mDOControlDelegate = doc;
        }
        public DOFunDelegates(DOControlDelegate doc,DOGetVauleDelegate dgd)
        {
            this.mDOControlDelegate = doc;
            this.mDOGetVauleDelegate = dgd;
        }
    }
    
    public class DO : BaseDevice
    {
        public DOBean bean;
        
        public string imagePath;
        private DOFunDelegates mDOFunDelegates ;
        private byte nowVaule;
        
        public override void newform()
        {
            Mform = new Frm_DO(bean, mDOFunDelegates, nowVaule);
           
        }

       
        public DO(DOBean b,DOFunDelegates dofd)
        {
            bean = b;
            mDOFunDelegates = dofd;
            this.Location = bean.mpoint;
            changeOutputState(null,null);
            
            this.Image = ImageTools.getImage(imagePath, imageSize, imageSize);
            this.Size = Image.Size;
            Mform = new Frm_DO(bean, mDOFunDelegates, nowVaule);
           // Mform.LostFocus += new EventHandler(this.changeOutputState);
            Mform.Disposed += new EventHandler(this.changeOutputState);
           // Mform.FormClosed += new FormClosedEventHandler(this.changeOutputState);
              //  new EventHandler(this.changeOutputState);
          //  Mform.FormClosed
        }
        public override void changeImageState(bool state)
        {
            if (connectState.checkVaule(state))
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
        }
        public void changeOutputState(object sender, EventArgs e)
        {
            nowVaule = mDOFunDelegates.mDOGetVauleDelegate((byte)bean.ioIndex);

            if (nowVaule == 0)
            {
                imagePath = bean.imageClosePath;
            }
            else if (nowVaule == 1)
            {
                imagePath = bean.imagePath;
            }
            else
            {
                connectState.oldState = false;
                imagePath = bean.imagePath;
            }
            if (connectState.oldState)
            {
                this.Image = ImageTools.getImage(imagePath, imageSize, imageSize);
            }
            else
            {
                this.Image = ImageTools.MakeGrayscale(imagePath, imageSize, imageSize);
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
        public Control[] getAllDevice()
        {
            ArrayList devices = new ArrayList();
            if (bean.aiBeans != null) { 
                foreach (AIBean aib in bean.aiBeans)
                {
                    ais[aib.ioIndex] = new AI(aib, bean.During, dataVaule);
                    devices.Add(ais[aib.ioIndex]);
                }
            }
            if (bean.diBeans != null)
            { 
                foreach (DIBean dib in bean.diBeans)
                {
                    dis[dib.ioIndex-8] = new DI(dib);
                    devices.Add(dis[dib.ioIndex - 8]);
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
                            dataVaule[aib.ioIndex] = FunctionTools.calculateByString(mCalHandler(dataVaule[0]), aib.function);
                            ais[aib.ioIndex].changeImageState(0 == dataVaule[10]);
                        }
                        
                    }
                }
                if (bean.diBeans != null)
                {
                    foreach (DIBean dib in bean.diBeans)
                    {
                        if (dib.useing)
                        {

                            dis[dib.ioIndex - 8].changeInputState((int)dataVaule[dib.ioIndex]);
                            dis[dib.ioIndex-8].changeImageState(0 == dataVaule[10]);
                        }
                    }
                }
               
            }

        }
    }
    public class C2000MD82 : InterfaceDevice
    {
        public Bean_C2000MD82 bean;
        private string beanKey;
        private string scmd;
        Int16[] dataVaule = new Int16[9];           
        public DI[] dis = new DI[8];
        public DO[] dos = new DO[2];
        
        
        public C2000MD82(Bean_C2000MD82 b)
        {
            bean = b;
            beanKey = bean.getBeanKey();
            scmd = @"select * from (select STATE,DI0,DI1,DI2,DI3,DI4,DI5,DI6,DI7 from C2000MD82 where DEVICE_GUID='" + beanKey + "' order by CREAT_TIME desc) where rownum=1 ";
        }
        private byte getDOVaule(byte index)
        {
            byte state = 0;
            index -= 8;
            byte[] cmd = CRC.GetCRC16Full(new byte[] { (byte)bean.SlaveNum, 0x03, 0x01, index , 0x00, 1 }, true);
            IPAddress ipa = IPAddress.Parse(bean.Ip);//把ip地址字符串转换为IPAddress类型的实例 
            IPEndPoint ipe = new IPEndPoint(ipa, bean.Port);//用指定的端口和ip初始化IPEndPoint类的新实例 
            using (Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    c.ReceiveTimeout = 5000;
                    c.SendTimeout = 5000;
                    c.Connect(ipe);
                    c.Send(cmd);//发送信息            
                    byte[] buff = new byte[7];
                    c.Receive(buff);//从服务器端接受返回信息                                        
                    if (CRC.isDataRight(buff))
                    {
                        state = buff[4];
                    }
                    else
                    {
                        ///校验异常
                        state = 6;
                    }
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2.ToString());
                    //ＴＣＰIP  链接异常
                    state = 7;
                }
                finally
                {
                    
                }
            }
            return state;
            
        }
        private Tools.BIMSConnectState controlDO(byte newVaule, byte index)
        {
            BIMSConnectState state = BIMSConnectState.OK;
            index -= 8;
            byte[] cmd = CRC.GetCRC16Full(new byte[] { (byte)bean.SlaveNum, 0x10, 0x01, index, 0x00, 1, 2, 0, newVaule }, true);
            IPAddress ipa = IPAddress.Parse(bean.Ip);//把ip地址字符串转换为IPAddress类型的实例 
            IPEndPoint ipe = new IPEndPoint(ipa, bean.Port);//用指定的端口和ip初始化IPEndPoint类的新实例 
            using (Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    c.Connect(ipe);
                    c.Send(cmd);//发送信息            
                    byte[] buff = new byte[8];
                    c.Receive(buff);//从服务器端接受返回信息                                        
                    if (CRC.isDataRight(buff))
                    {
                        //无法从返回包中直接获得数据,用校验来做判断即可
                        state = BIMSConnectState.OK;
                        
                    }
                    else
                    {
                        ///校验异常
                        state = BIMSConnectState.ERROR_CHECKSUM;
                       
                    }
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2.ToString());
                    //ＴＣＰIP  链接异常
                    state = BIMSConnectState.ERROR_TCPIP;
                }
                finally
                {
                    string scmd = @"INSERT INTO DO_RECORD (DEVICE_GUID, STATE,CREAT_TIME,IO_INDEX,NEW_VAULE) values ('" + beanKey + @"'," + (int)state + @",TO_DATE('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                                                  + @"','yyyy-mm-dd hh24:mi:ss')," + index + @"," + newVaule + @")";
                    using (OracleConnection conn = new OracleConnection(OracleTools.connString))
                    {
                        try
                        {

                            OracleCommand ocmd = new OracleCommand(scmd, conn);
                            conn.Open();
                            ocmd.ExecuteNonQuery();
                        }
                        catch (Exception e2)
                        {
                            state = BIMSConnectState.ERROR_DATABASE;
                            //MessageBox.Show("数据库连接异常");
                        }

                    }
                }
            }
            return state;

        }
        public Control[] getAllDevice()
        {
            ArrayList devices = new ArrayList();
            if (bean.diBeans != null)
            {
                foreach (DIBean dib in bean.diBeans)
                {
                    dis[dib.ioIndex] = new DI(dib);
                    devices.Add(dis[dib.ioIndex]);
                }
            }
            if (bean.doBeans != null)
            {
                foreach (DOBean dob in bean.doBeans)
                {                  
                    dos[dob.ioIndex-8] = new DO(dob,new DOFunDelegates(this.controlDO,this.getDOVaule));
                    devices.Add(dos[dob.ioIndex-8]);
                }
            }
            periodWork(null, null);
            PublicResource.addTimer(bean.During, new ElapsedEventHandler(this.periodWork));

            return (BaseDevice[])devices.Cast<BaseDevice>().ToArray();
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

                    dataVaule[0] = (Int16)mOracleDataReader["DI0"];
                    dataVaule[1] = (Int16)mOracleDataReader["DI1"];
                    dataVaule[2] = (Int16)mOracleDataReader["DI2"];
                    dataVaule[3] = (Int16)mOracleDataReader["DI3"];
                    dataVaule[4] = (Int16)mOracleDataReader["DI4"];
                    dataVaule[5] = (Int16)mOracleDataReader["DI5"];
                    dataVaule[6] = (Int16)mOracleDataReader["DI6"];
                    dataVaule[7] = (Int16)mOracleDataReader["DI7"];
                    dataVaule[8] = (Int16)int.Parse((String)mOracleDataReader["STATE"]);
                    //dataVaule[9] = Int16.Parse((Int16)mOracleDataReader["DI1"]);
                    //dataVaule[10] = Int16.Parse((Int16)mOracleDataReader["STATE"]);


                }
                if (bean.diBeans != null)
                {
                    foreach (DIBean dib in bean.diBeans)
                    {
                        if (dib.useing)
                        {

                            dis[dib.ioIndex].changeInputState((int)dataVaule[dib.ioIndex]);
                            dis[dib.ioIndex].changeImageState(0 == dataVaule[8]);
                        }
                    }
                }
                if (bean.doBeans != null)
                {
                    foreach (DOBean dob in bean.doBeans)
                    {
                        if (dob.useing)
                        {                            
                            dos[dob.ioIndex-8].changeImageState(0 == dataVaule[8]);
                        }
                    }
                }

            }

        }
    }
    public class C2000M281 : InterfaceDevice
    {
        public Bean_C2000M281 bean;
        private string beanKey;
        private string scmd;
        Int16[] dataVaule = new Int16[9];
        public DI[] dis = new DI[8];
        public DO[] dos = new DO[1];


        public C2000M281(Bean_C2000M281 b)
        {
            bean = b;
            beanKey = bean.getBeanKey();
            scmd = @"select * from (select STATE,DI0,DI1,DI2,DI3,DI4,DI5,DI6,DI7 from C2000MD82 where DEVICE_GUID='" + beanKey + "' order by CREAT_TIME desc) where rownum=1 ";
        }
        private byte getDOVaule(byte index)
        {
            byte state = 0;
            Random ran = new Random();
            Int16 RandKey = (Int16)ran.Next( 0x8fff,0xffff);
            byte keyH = (byte)((RandKey & 0xff00) >> 8);
            byte keyL = (byte)((RandKey & 0x00ff));
            byte[] cmdoo = new byte[] { keyH, keyL, 0, 0, 0, 6, 1, 3, 0, 25, 0, 1 };
            IPAddress ipa = IPAddress.Parse(bean.Ip);//把ip地址字符串转换为IPAddress类型的实例 
            IPEndPoint ipe = new IPEndPoint(ipa, bean.Port);//用指定的端口和ip初始化IPEndPoint类的新实例 
            using (Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    c.ReceiveTimeout = 5000;
                    c.SendTimeout = 5000;
                    c.Connect(ipe);
                    c.Send(cmdoo);//发送信息            
                    byte[] buff = new byte[11];
                    c.Receive(buff);//从服务器端接受返回信息                                        
                    if (buff[0] == keyH && buff[1] == keyL)
                    {
                        state = buff[10];
                    }
                    else
                    {
                        ///校验异常
                        state = 6;
                    }
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2.ToString());
                    //ＴＣＰIP  链接异常
                    state = 7;
                }
                finally
                {

                }
            }
            return state;

        }
        private Tools.BIMSConnectState controlDO(byte newVaule, byte index)
        {
            BIMSConnectState state = BIMSConnectState.OK;

            Random ran = new Random();
            Int16 RandKey = (Int16)ran.Next(0x8fff, 0xffff);
            byte keyH = (byte)((RandKey & 0xff00) >> 8);
            byte keyL = (byte)((RandKey & 0x00ff));
            byte[] cmdoo = new byte[] { keyH, keyL, 0, 0, 0, 0x0f, 1, 0x10, 0, 0x19, 0, 1, 2, 0, newVaule };

            IPAddress ipa = IPAddress.Parse(bean.Ip);//把ip地址字符串转换为IPAddress类型的实例 
            IPEndPoint ipe = new IPEndPoint(ipa, bean.Port);//用指定的端口和ip初始化IPEndPoint类的新实例 
            using (Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    c.Connect(ipe);
                    c.Send(cmdoo);//发送信息            
                    byte[] buff = new byte[8];
                    c.Receive(buff);//从服务器端接受返回信息                                        
                    if (buff[0] == keyH && buff[1] == keyL)
                    {
                        //无法从返回包中直接获得数据,用校验来做判断即可
                        state = BIMSConnectState.OK;

                    }
                    else
                    {
                        ///校验异常
                        state = BIMSConnectState.ERROR_CHECKSUM;

                    }
                }
                catch (Exception e2)
                {
                    Console.WriteLine(e2.ToString());
                    //ＴＣＰIP  链接异常
                    state = BIMSConnectState.ERROR_TCPIP;
                }
                finally
                {
                    string scmd = @"INSERT INTO DO_RECORD (DEVICE_GUID, STATE,CREAT_TIME,IO_INDEX,NEW_VAULE) values ('" + beanKey + @"'," + (int)state + @",TO_DATE('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                                                  + @"','yyyy-mm-dd hh24:mi:ss')," + index + @"," + newVaule + @")";
                    using (OracleConnection conn = new OracleConnection(OracleTools.connString))
                    {
                        try
                        {

                            OracleCommand ocmd = new OracleCommand(scmd, conn);
                            conn.Open();
                            ocmd.ExecuteNonQuery();
                        }
                        catch (Exception e2)
                        {
                            state = BIMSConnectState.ERROR_DATABASE;
                            //MessageBox.Show("数据库连接异常");
                        }

                    }
                }
            }
            return state;

        }
        public Control[] getAllDevice()
        {
            ArrayList devices = new ArrayList();
            if (bean.diBeans != null)
            {
                foreach (DIBean dib in bean.diBeans)
                {
                    dis[dib.ioIndex] = new DI(dib);
                    devices.Add(dis[dib.ioIndex]);
                }
            }
            if (bean.doBeans != null)
            {
                foreach (DOBean dob in bean.doBeans)
                {
                    dos[dob.ioIndex - 8] = new DO(dob, new DOFunDelegates(this.controlDO, this.getDOVaule));
                    devices.Add(dos[dob.ioIndex - 8]);
                }
            }
            periodWork(null, null);
            PublicResource.addTimer(bean.During, new ElapsedEventHandler(this.periodWork));

            return (BaseDevice[])devices.Cast<BaseDevice>().ToArray();
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

                    dataVaule[0] = (Int16)mOracleDataReader["DI0"];
                    dataVaule[1] = (Int16)mOracleDataReader["DI1"];
                    dataVaule[2] = (Int16)mOracleDataReader["DI2"];
                    dataVaule[3] = (Int16)mOracleDataReader["DI3"];
                    dataVaule[4] = (Int16)mOracleDataReader["DI4"];
                    dataVaule[5] = (Int16)mOracleDataReader["DI5"];
                    dataVaule[6] = (Int16)mOracleDataReader["DI6"];
                    dataVaule[7] = (Int16)mOracleDataReader["DI7"];
                    dataVaule[8] = (Int16)int.Parse((String)mOracleDataReader["STATE"]);
                    //dataVaule[9] = Int16.Parse((Int16)mOracleDataReader["DI1"]);
                    //dataVaule[10] = Int16.Parse((Int16)mOracleDataReader["STATE"]);


                }
                if (bean.diBeans != null)
                {
                    foreach (DIBean dib in bean.diBeans)
                    {
                        if (dib.useing)
                        {

                            dis[dib.ioIndex].changeInputState((int)dataVaule[dib.ioIndex]);
                            dis[dib.ioIndex].changeImageState(0 == dataVaule[8]);
                        }
                    }
                }
                if (bean.doBeans != null)
                {
                    foreach (DOBean dob in bean.doBeans)
                    {
                        if (dob.useing)
                        {
                            dos[dob.ioIndex - 8].changeImageState(0 == dataVaule[8]);
                        }
                    }
                }

            }

        }
    }
    public class C2000MH08 : InterfaceDevice
    {
        public Bean_C2000MH08 bean;
        private string beanKey;
        private string scmd;
        string[] dataVaule = new string[9];
        private Ctrl_C2000MH08 mCtrl_C2000MH08;
        public StateRegister<bool> connectState = new StateRegister<bool>(true);
        public C2000MH08(Bean_C2000MH08 b)
        {
            bean = b;
            beanKey = bean.getBeanKey();
            mCtrl_C2000MH08 = new Ctrl_C2000MH08(bean.detail);
            mCtrl_C2000MH08.Location = bean.MPoint;
           
            scmd = @"select * from (select STATE,DI0,DI1,DI2,DI3,DI4,DI5,DI6,DI7 from C2000MH08 where DEVICE_GUID='" + beanKey + "' order by CREAT_TIME desc) where rownum=1 ";
        }
        public Control[] getAllDevice()
        {          
            periodWork(null, null);
            PublicResource.addTimer(bean.During, new ElapsedEventHandler(this.periodWork));
            return new Control[]{mCtrl_C2000MH08};
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
                    dataVaule[0] = (string)mOracleDataReader["DI0"];
                    dataVaule[1] = (string)mOracleDataReader["DI1"];
                    dataVaule[2] = (string)mOracleDataReader["DI2"];
                    dataVaule[3] = (string)mOracleDataReader["DI3"];
                    dataVaule[4] = (string)mOracleDataReader["DI4"];
                    dataVaule[5] = (string)mOracleDataReader["DI5"];
                    dataVaule[6] = (string)mOracleDataReader["DI6"];
                    dataVaule[7] = (string)mOracleDataReader["DI7"];
                    dataVaule[8] = (string)mOracleDataReader["STATE"];                   
                }
                if (connectState.checkVaule("0".Equals(dataVaule[8])))
                {
                    if (connectState.oldState)
                    {

                    }
                    else
                    {

                    }
                }
                if (connectState.oldState)
                {
                    mCtrl_C2000MH08.changeVaule(dataVaule);
                }
            }

        }
    }
    public class HIKVISION : BaseDevice, InterfaceDevice
    {
        private Bean_HIKVISION bean;
        private static string imageURL = "HIKVSION.png";
        public override void newform()
        {
            Mform = new Frm_HIKVISION(bean);
        }
        public HIKVISION(Bean_HIKVISION b)
        {
            bean = b;

        }
        public Control[] getAllDevice()
        {
            this.Image = ImageTools.getImage(imageURL, imageSize, imageSize);
            this.Size = new Size(imageSize, imageSize);
            this.Location = bean.MPoint;
            return new BaseDevice[] { this };
        }
    }
}
