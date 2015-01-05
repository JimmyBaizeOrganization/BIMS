﻿using System;
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
    class BaseDevice
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
        private int state;
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
                        state = 0;
                    }
                    else
                    {
                        ///校验异常
                        state = 1;
                    }
                }
                catch
                {
                    //ＴＣＰIP  链接异常
                    state = 2;
                }
                finally
                {
                   
                    string scmd = @"INSERT INTO DED194E_9S1YK2K2 (DEVICE_GUID, STATE,CREAT_TIME,DCVAL,PF,FREQ,S,Q,P,VOLTAGE,I) values ('" + GUID + @"'," + state + @",TO_DATE('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                                                    + @"','yyyy-mm-dd hh24:mi:ss')," + data[0] + @"," + data[1] + "," + data[2] + "," + data[3] + "," + data[4] + "," + data[5] + "," + data[6] + "," + data[7] + @")";

                    //using (OracleConnection conn = new OracleConnection(OracleTools.connString))
                    //{
                    //    string scmd = @"INSERT INTO DED194E_9S1YK2K2 (DEVICE_GUID, STATE,CREAT_TIME,DCVAL,PF,FREQ,S,Q,P,VOLTAGE,I) values ('" + GUID + @"'," + state + @",TO_DATE('" + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                    //                                                + @"','yyyy-mm-dd hh24:mi:ss')," + data[0] + @"," + data[1] + "," + data[2] + "," + data[3] + "," + data[4] + "," + data[5] + "," + data[6] + "," + data[7] + @")";
                    //    OracleCommand cmd = new OracleCommand(scmd, conn);
                    //    conn.Open();
                    //    int a  = cmd.ExecuteNonQuery();
                    //    MessageBox.Show(a.ToString());
                    //}
                    using (OracleConnection conn = new OracleConnection(OracleTools.connString))
                    {
                        try
                        {
                            //Console.WriteLine("INSERT INTO DED194E_9S1YK2K2 (DEVICE_GUID, STATE,CREAT_TIME,DCVAL,PF,FREQ,S,Q,P,VOLTAGE,I) values ('" + GUID + "', " + state + ",TO_DATE('" + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                            //                    + "','yyyy-mm-dd hh24:mi:ss')," + data[0] + "," + data[1] + "," + data[2] + "," + data[3] + "," + data[4] + "," + data[5] + "," + data[6] + "," + data[7] + ");");

                            //if (Conn.State == ConnectionState.Closed)
                            //{
                            //    Console.WriteLine("open ");

                            //}

                            // Console.WriteLine(scmd);
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
            float[] ai  = new float[8];
            char[] oi = new char[2];
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
                            int v = h << 8 + l;
                            if (v < 0x8000)
                            {
                                ai[i] = ((v * 5) * 1000.0f / 4080000.0f) / 240.0f;
                            }
                            else
                            {
                                ai[i] = ((65535 - v+1) * 5) * 1000 / 4080000 / 240.0f;
                            }
                        }
                        oi[0] = (char)buff[20];
                        oi[1] = (char)buff[22];
                        state = 0;
                    }
                    else
                    {
                        ///校验异常
                        state = 1;
                    }
                }
                catch
                {
                    //ＴＣＰIP  链接异常
                    state = 2;
                }
                finally
                {

                    string scmd = @"INSERT INTO C2000MDXA (DEVICE_GUID, STATE,CREAT_TIME,AI0,AI1,AI2,AI3,AI4,AI5,AI6,AI6,AI7,DI0,DI1) values ('" + GUID + @"'," + state + @",TO_DATE('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                                                    + @"','yyyy-mm-dd hh24:mi:ss')," + ai[0] + @"," + ai[1] + "," + ai[2] + "," + ai[3] + "," + ai[4] + "," + ai[5] + "," + ai[6] + "," + ai[7] + "," + oi[0] + "," + "," + oi[1] + "," + @")";

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
