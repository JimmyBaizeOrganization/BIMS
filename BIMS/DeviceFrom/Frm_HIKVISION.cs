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

using System.Runtime.InteropServices;
using PreviewDemo;

namespace BIMS.DeviceFrom
{
    public partial class Frm_HIKVISION : Form
    {
        Bean_HIKVISION bean;
        private bool m_bInitSDK = false;
        public Frm_HIKVISION(Bean_HIKVISION b)
        {
            InitializeComponent();
            bean = b;
            m_bInitSDK = CHCNetSDK.NET_DVR_Init();

            if (m_bInitSDK == false)
            {
                MessageBox.Show("NET_DVR_Init error!");
                return;
            }
         

            //string DVRIPAddress = bea; //设备IP地址或者域名
           // Int16 DVRPortNumber = Int16.Parse( bean.port);//设备服务端口号
            //string DVRUserName = textBoxUserName.Text;//设备登录用户名
            //string DVRPassword = textBoxPassword.Text;//设备登录密码

            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

            //登录设备 Login the device
            int m_lUserID = CHCNetSDK.NET_DVR_Login_V30(bean.Ip, bean.Port, bean.username, bean.password, ref DeviceInfo);
            if (m_lUserID < 0)
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string str = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //登录失败，输出错误号
                MessageBox.Show(str);
                return;
            }


            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            lpPreviewInfo.hPlayWnd = RealPlayWnd.Handle;//预览窗口
            lpPreviewInfo.lChannel = Int16.Parse(bean.channel);//预te览的设备通道
            lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流

           // CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
            IntPtr pUser = new IntPtr();//用户数据

            //打开预览 Start live view 
            int m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
            if (m_lRealHandle < 0)
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string str = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //预览失败，输出错误号
                MessageBox.Show(str);
                return;
            }
            else
            {
                //预览成功
                //btnPreview.Text = "Stop Live View";
            }

        }
    }
}
