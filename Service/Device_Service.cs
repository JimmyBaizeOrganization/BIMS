﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service
{

    class BaseDevice
    {
        String ip;

        public String Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        int port;

        public int Port
        {
            get { return port; }
            set { port = value; }
        }
        string buildingName;
        int floorNum;
        int deviceNum;
        string deviceType;
        int during;

        public int During
        {
            get { return during; }
            set { during = value; }
        }
        public BaseDevice(string mip, int mport, int mdeviceNum, string mbuildingName, int mfloorNum, string mdeviceType
            ,int mduring)
        {
            ip = mip;
            port = mport;
            deviceNum = mdeviceNum;
            buildingName = mbuildingName;
            floorNum = mfloorNum;
            deviceType = mdeviceType;
            during = mduring;
        }
    }
    class DED194E9_9S1YK2K2 : BaseDevice
    {
        const int dataLenth = 16;//采集数据个数
        int slaveNum;//从机编号
        float[] data = new float[dataLenth/2];
        Thread task;

        byte[] cmd ;
            
            
        public DED194E9_9S1YK2K2(string mip, int mport, int mdeviceNum, string mbuildingName
            , int mfloorNum, string mdeviceType, int mslaveNum,int mduring)
            : base(mip, mport, mdeviceNum, mbuildingName, mfloorNum, mdeviceType, mduring)
        {
            slaveNum = mslaveNum;
            cmd = CRC.GetCRC16Full(new byte[] { (byte)slaveNum, 0x03, 0x00, 0x0a, 0x00, dataLenth }, true);
            //开一个线程  读数据 写数据到数据库
            task = new Thread(ReadDataAndWriteData);
            task.Start();
        }
        void ReadDataAndWriteData()
        {
            IPAddress ipa = IPAddress.Parse(Ip);//把ip地址字符串转换为IPAddress类型的实例 
            IPEndPoint ipe = new IPEndPoint(ipa, Port);//用指定的端口和ip初始化IPEndPoint类的新实例 
            using (Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                int recLenth = dataLenth*2+5;
                c.Connect(ipe);
                while (true)
                {
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
                           // float f = BitConverter.ToSingle(bf, 0);
                            Console.WriteLine(data[i].ToString());
                        }
                    }
                    Thread.Sleep(During);
                }
            }
        }

  

    }
}