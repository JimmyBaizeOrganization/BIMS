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

namespace Service
{

    class BaseDevice
    {
        public virtual void periodWork(object o, ElapsedEventArgs e)
        {
        }
    }
    class DED194E_9S1YK2K2 : BaseDevice
    {
         const  int dataLenth = 16;//采集数据个数       
        float[] data = new float[dataLenth/2];
        
        byte[] cmd ;

        private Bean_DED194E_9S1YK2K2 bean;

        public Bean_DED194E_9S1YK2K2 Bean
        {
            get { return bean; }
            set { bean = value; }
        }

        public DED194E_9S1YK2K2(Bean_DED194E_9S1YK2K2 b)
        {
            bean = b;
            cmd = CRC.GetCRC16Full(new byte[] { (byte)bean.SlaveNum, 0x03, 0x00, 0x0a, 0x00, dataLenth }, true);
        }
        public override void periodWork(object o, ElapsedEventArgs e)
        {
            IPAddress ipa = IPAddress.Parse(bean.Ip);//把ip地址字符串转换为IPAddress类型的实例 
            IPEndPoint ipe = new IPEndPoint(ipa, bean.Port);//用指定的端口和ip初始化IPEndPoint类的新实例 
            using (Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
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
                        Console.WriteLine(data[i].ToString());
                    }
                }
                    
                
            }
        }
  

    }
}
