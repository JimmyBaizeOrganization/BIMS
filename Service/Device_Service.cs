using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tools;
using System.Timers;
using Oracle.DataAccess.Client;
using System.Data.Common;
using System.Data;


namespace Service
{

    interface IBeanTool
    {
         BaseBean getBean();
    }
    public class BaseDevice
    {



      
       

  

     
       

        public BaseDevice()
        {
           
        }
        public virtual void periodWork(object o, ElapsedEventArgs e)
        {

        }
       
    }
    class DED194E_9S1YK2K2 : BaseDevice,IBeanTool
    {
         const  int dataLenth = 16;//采集数据个数       
        float[] data = new float[dataLenth/2];
        
        byte[] cmd ;
        private BIMSConnectState state;
        private Bean_DED194E_9S1YK2K2 bean;
        IPEndPoint ipe;
        IPAddress ipa;

        private string GUID;
        public Bean_DED194E_9S1YK2K2 Bean
        {
            get { return bean; }
            set { bean = value; }
        }

        public DED194E_9S1YK2K2(Bean_DED194E_9S1YK2K2 b)
        {
            bean = b;
            cmd = CRC.GetCRC16Full(new byte[] { (byte)bean.SlaveNum, 0x03, 0x00, 0x0a, 0x00, dataLenth }, true);
            GUID = bean.getBeanKey();
             ipa = IPAddress.Parse(bean.Ip);//把ip地址字符串转换为IPAddress类型的实例 
             ipe = new IPEndPoint(ipa, bean.Port);//用指定的端口和ip初始化IPEndPoint类的新实例 
            
        }
        public override void periodWork(object o, ElapsedEventArgs e)
        {           
            using (Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    int recLenth = dataLenth * 2 + 5;
                    c.Connect(ipe);
                    c.Send(cmd);//发送信息            
                    byte[] buff = new byte[recLenth];
                    c.Receive(buff);//从服务器端接受返回信息                                        
                    if (CRC.isDataRight(buff))
                    {
                        int start = buff[2] + 2;
                        for (int i = 0; i < buff[2] / 4; i++, start -= 4)
                        {
                            byte[] bf = new byte[4];
                            bf[0] = buff[start];
                            bf[1] = buff[start - 1];
                            bf[2] = buff[start - 2];
                            bf[3] = buff[start - 3];
                            data[i] = BitConverter.ToSingle(bf, 0);
                            //Console.WriteLine(data[i].ToString());
                        }
                        state = BIMSConnectState.OK;
                    }
                    else
                    {
                        ///校验异常
                        state = BIMSConnectState.ERROR_CHECKSUM;
                    }
                }
                catch
                {
                    //ＴＣＰIP  链接异常
                    state = BIMSConnectState.ERROR_TCPIP;
                }
                finally
                {                
                    string scmd = @"INSERT INTO DED194E_9S1YK2K2 (DEVICE_GUID, STATE,CREAT_TIME,DCVAL,PF,FREQ,S,Q,P,VOLTAGE,I) values ('" + GUID + @"'," + state + @",TO_DATE('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                                                    + @"','yyyy-mm-dd hh24:mi:ss')," + data[0] + @"," + data[1] + "," + data[2] + "," + data[3] + "," + data[4] + "," + data[5] + "," + data[6] + "," + data[7] + @")";
                    using (OracleConnection conn = new OracleConnection(OracleTools.connString))
                    {
                        try
                        {                        
                            OracleCommand cmd = new OracleCommand(scmd, conn);
                            conn.Open();
                            int d = cmd.ExecuteNonQuery();
                        }
                        catch (Exception e2)
                        {
                        }                      
                    }                 
               }
            }
           
        }
        public BaseBean getBean()
        {
            return bean;
        }
    }
    //TODO  未完成
    class DED194E_9S1YK4K4 : BaseDevice, IBeanTool
    {
        
        float[] data = new float[3];

        byte[] cmd;
        private BIMSConnectState state;
        private Bean_DED194E_9S1YK4K4 bean;
        IPEndPoint ipe;
        IPAddress ipa;

        private string GUID;
        public Bean_DED194E_9S1YK4K4 Bean
        {
            get { return bean; }
            set { bean = value; }
        }

        public DED194E_9S1YK4K4(Bean_DED194E_9S1YK4K4 b)
        {
            bean = b;
            cmd = CRC.GetCRC16Full(new byte[] { (byte)bean.SlaveNum, 0x03, 0x00, 9, 0x00, 6 }, true);
            GUID = bean.getBeanKey();
            ipa = IPAddress.Parse(bean.Ip);//把ip地址字符串转换为IPAddress类型的实例 
            ipe = new IPEndPoint(ipa, bean.Port);//用指定的端口和ip初始化IPEndPoint类的新实例 

        }
        public override void periodWork(object o, ElapsedEventArgs e)
        {
            using (Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {                   
                    c.Connect(ipe);
                    c.Send(cmd);//发送信息            
                    byte[] buff = new byte[17];
                    c.Receive(buff);//从服务器端接受返回信息                                        
                    if (CRC.isDataRight(buff))
                    {
                        int start = buff[2] + 2;
                        for (int i = 0; i < buff[2] / 4; i++, start -= 4)
                        {
                            byte[] bf = new byte[4];
                            bf[0] = buff[start];
                            bf[1] = buff[start - 1];
                            bf[2] = buff[start - 2];
                            bf[3] = buff[start - 3];
                            data[i] = BitConverter.ToSingle(bf, 0);
                            //Console.WriteLine(data[i].ToString());
                        }
                        state = BIMSConnectState.OK;
                    }
                    else
                    {
                        ///校验异常
                        state = BIMSConnectState.ERROR_CHECKSUM;
                    }
                }
                catch
                {
                    //ＴＣＰIP  链接异常
                    state = BIMSConnectState.ERROR_TCPIP;
                }
                finally
                {
                    string scmd = @"INSERT INTO DED194E_9S1YK4K4 (DEVICE_GUID, STATE,CREAT_TIME,DCVAL,PF,FREQ,S,Q,P,VOLTAGE,I) values ('" + GUID + @"'," + state + @",TO_DATE('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                                                    + @"','yyyy-mm-dd hh24:mi:ss')," + data[0] + @"," + data[1] + "," + data[2] + "," + data[3] + "," + data[4] + "," + data[5] + "," + data[6] + "," + data[7] + @")";
                    using (OracleConnection conn = new OracleConnection(OracleTools.connString))
                    {
                        try
                        {
                            OracleCommand cmd = new OracleCommand(scmd, conn);
                            conn.Open();
                            int d = cmd.ExecuteNonQuery();
                        }
                        catch (Exception e2)
                        {
                        }
                    }
                }
            }

        }
        public BaseBean getBean()
        {
            return bean;
        }
    }
    public class C2000MDxA : BaseDevice, IBeanTool
    {
        static byte dataLenth = 10;//采集数据个数 
        static int recLenth = dataLenth * 2 + 5;
        byte[] cmd;
        private int state;
        private Bean_C2000MDxA bean;

        public Bean_C2000MDxA Bean
        {
            get { return bean; }
            set { bean = value; }
        }
        IPEndPoint ipe;
        IPAddress ipa;

        private string GUID;
        public C2000MDxA(Bean_C2000MDxA b)
        {
            bean = b;
            cmd = CRC.GetCRC16Full(new byte[] { (byte)bean.SlaveNum, 0x03, 0x05, 0x11, 0x00, dataLenth }, true);
            GUID = bean.getBeanKey();
            ipa = IPAddress.Parse(bean.Ip);//把ip地址字符串转换为IPAddress类型的实例 
            ipe = new IPEndPoint(ipa, bean.Port);//用指定的端口和ip初始化IPEndPoint类的新实例 
        }
        public BaseBean getBean()
        {
            return bean;
        }
        public override void periodWork(object o, ElapsedEventArgs e)
        {
            int[] ai = new int[8];
            int[] oi = new int[2];
            using (Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {         
                    c.Connect(ipe);
                    c.Send(cmd);//发送信息            
                    byte[] buff = new byte[recLenth];
                    c.Receive(buff);//从服务器端接受返回信息                                        
                    if (CRC.isDataRight(buff))
                    {
                        int start = 3;
                        for (int i = 0; i < (buff[2] / 2)-2; i++, start += 2)
                        {                            
                            byte h = buff[start];
                            byte l = buff[start + 1];
                            ai[i] = h << 8 + l;
                            //if (v < 0x8000)
                            //{
                            //    ai[i] = ((v * 5) * 1000.0f / 4080000.0f) / 240.0f;
                            //}
                            //else
                            //{
                            //    ai[i] = ((65535 - v+1) * 5) * 1000 / 4080000 / 240.0f;
                            //}
                        }
                        oi[0] = (int)buff[20];
                        oi[1] = (int)buff[22];
                        state = BIMSConnectState.OK;
                    }
                    else
                    {
                        ///校验异常
                        state = BIMSConnectState.ERROR_CHECKSUM;
                    }
                }
                catch(Exception e2)
                {
                    Console.WriteLine(e2.ToString());
                    //ＴＣＰIP  链接异常
                    state = BIMSConnectState.ERROR_TCPIP;
                }
                finally
                {

                    string scmd = @"INSERT INTO C2000MDXA (DEVICE_GUID, STATE,CREAT_TIME,AI0,AI1,AI2,AI3,AI4,AI5,AI6,AI7,DI0,DI1) values ('" + GUID + @"'," + state + @",TO_DATE('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                                                    + @"','yyyy-mm-dd hh24:mi:ss')," + ai[0] + @"," + ai[1] + "," + ai[2] + "," + ai[3] + "," + ai[4] + "," + ai[5] + "," + ai[6] + "," + ai[7] + "," + oi[0]  + "," + oi[1]  + @")";

                    using (OracleConnection conn = new OracleConnection(OracleTools.connString))
                    {
                        try
                        {
                           
                            OracleCommand cmd = new OracleCommand(scmd, conn);
                            conn.Open();
                             cmd.ExecuteNonQuery();
                        }
                        catch (Exception e2)
                        {

                        }

                    }



                }
            }

        }
    }
    public class C2000MD82 : BaseDevice, IBeanTool
    {
        static byte dataLenth = 8;//采集数据个数 
        static int recLenth = dataLenth * 2 + 5;
        byte[] cmd;
        private BIMSConnectState state;
        private Bean_C2000MD82 bean;

        public Bean_C2000MD82 Bean
        {
            get { return bean; }
            set { bean = value; }
        }
        IPEndPoint ipe;
        IPAddress ipa;

        private string GUID;
        public C2000MD82(Bean_C2000MD82 b)
        {
            bean = b;
            cmd = CRC.GetCRC16Full(new byte[] { (byte)bean.SlaveNum, 0x03, 0x01, 0x04, 0x00, dataLenth }, true);
            GUID = bean.getBeanKey();
            ipa = IPAddress.Parse(bean.Ip);//把ip地址字符串转换为IPAddress类型的实例 
            ipe = new IPEndPoint(ipa, bean.Port);//用指定的端口和ip初始化IPEndPoint类的新实例 
        }
        public BaseBean getBean()
        {
            return bean;
        }
        public override void periodWork(object o, ElapsedEventArgs e)
        {
            
            int[] di = new int[8];
            using (Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    c.Connect(ipe);
                    c.Send(cmd);//发送信息            
                    byte[] buff = new byte[recLenth];
                    c.Receive(buff);//从服务器端接受返回信息                                        
                    if (CRC.isDataRight(buff))
                    {
                        int start = 4;
                        for (int i = 0; i < (buff[2] / 2) - 2; i++, start += 2)
                        {
                            di[i] = buff[start];
                        }
                       
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

                    string scmd = @"INSERT INTO C2000MD82 (DEVICE_GUID, STATE,CREAT_TIME,DI0,DI1,DI2,DI3,DI4,DI5,DI6,DI7) values ('" + GUID + @"'," + state + @",TO_DATE('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                                                    + @"','yyyy-mm-dd hh24:mi:ss')," + di[0] + @"," + di[1] + "," + di[2] + "," + di[3] + "," + di[4] + "," + di[5] + "," + di[6] + "," + di[7] + @")";

                    using (OracleConnection conn = new OracleConnection(OracleTools.connString))
                    {
                        try
                        {

                            OracleCommand cmd = new OracleCommand(scmd, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception e2)
                        {

                        }

                    }



                }
            }

        }
    }
    public class C2000M281 : BaseDevice, IBeanTool
    {
        static byte dataLenth = 8;//采集数据个数 
        static int recLenth = dataLenth * 2 + 5;
        byte[] cmd;
        private BIMSConnectState state;
        private Bean_C2000M281 bean;

        public Bean_C2000M281 Bean
        {
            get { return bean; }
            set { bean = value; }
        }
        IPEndPoint ipe;
        IPAddress ipa;

        private string GUID;
        public C2000M281(Bean_C2000M281 b)
        {
            bean = b;
            cmd = CRC.GetCRC16Full(new byte[] { (byte)bean.SlaveNum, 0x03, 0, 27, 0x00, dataLenth }, true);
            GUID = bean.getBeanKey();
            ipa = IPAddress.Parse(bean.Ip);//把ip地址字符串转换为IPAddress类型的实例 
            ipe = new IPEndPoint(ipa, bean.Port);//用指定的端口和ip初始化IPEndPoint类的新实例 
        }
        public BaseBean getBean()
        {
            return bean;
        }
        public override void periodWork(object o, ElapsedEventArgs e)
        {

            int[] di = new int[8];
            using (Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    c.Connect(ipe);
                    c.Send(cmd);//发送信息            
                    byte[] buff = new byte[recLenth];
                    c.Receive(buff);//从服务器端接受返回信息                                        
                    if (CRC.isDataRight(buff))
                    {
                        int start = 4;
                        for (int i = 0; i < (buff[2] / 2) - 2; i++, start += 2)
                        {
                            di[i] = buff[start];
                        }

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

                    string scmd = @"INSERT INTO C2000MD82 (DEVICE_GUID, STATE,CREAT_TIME,DI0,DI1,DI2,DI3,DI4,DI5,DI6,DI7) values ('" + GUID + @"'," + state + @",TO_DATE('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                                                    + @"','yyyy-mm-dd hh24:mi:ss')," + di[0] + @"," + di[1] + "," + di[2] + "," + di[3] + "," + di[4] + "," + di[5] + "," + di[6] + "," + di[7] + @")";

                    using (OracleConnection conn = new OracleConnection(OracleTools.connString))
                    {
                        try
                        {

                            OracleCommand cmd = new OracleCommand(scmd, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception e2)
                        {

                        }

                    }



                }
            }

        }
    }
}
