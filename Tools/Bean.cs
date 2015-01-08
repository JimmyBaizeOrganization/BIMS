using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class BaseBean
    {
        String ip;

        public String Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        int baud;
        string className;
        string sort;

        public string Sort
        {
            get { return sort; }
            set { sort = value; }
        }
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        public int Baud
        {
            get { return baud; }
            set { baud = value; }
        }

        int port;
        private string beizhu;

        public string Beizhu
        {
            get { return beizhu; }
            set { beizhu = value; }
        }

        public int Port
        {
            get { return port; }
            set { port = value; }
        }
        string buildingName;

        public string BuildingName
        {
            get { return buildingName; }
            set { buildingName = value; }
        }
        int floorNum;

        public int FloorNum
        {
            get { return floorNum; }
            set { floorNum = value; }
        }
        int deviceNum;

        //坐标
        Point mpoint;

        public Point MPoint
        {
            get { return mpoint; }
            set { mpoint = value; }
        }

        public int DeviceNum
        {
            get { return deviceNum; }
            set { deviceNum = value; }
        }
        string deviceType;

        public string DeviceType
        {
            get { return deviceType; }
            set { deviceType = value; }
        }
        int during;

        public int During
        {
            get { return during; }
            set { during = value; }
        }
        public BaseBean(string mip, int mport, int mdeviceNum, string mbuildingName, int mfloorNum, string mdeviceType
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
        public BaseBean()
        {

        }
        public string getBeanKey(){
            return this.buildingName + this.floorNum + this.deviceNum;
        }
    }
    public  class Bean_DED194E_9S1YK2K2 : BaseBean
    {
        int slaveNum;//从机编号

        public int SlaveNum
        {
            get { return slaveNum; }
            set { slaveNum = value; }
        }
        public Bean_DED194E_9S1YK2K2()
        {
            Baud = 9600;
            slaveNum = 1;
            ClassName = "DED194E_9S1YK2K2";
            During = 5000;
            DeviceType = "DED194E_9S1YK2K2";

        }
        public Bean_DED194E_9S1YK2K2(string mip, int mport, int mdeviceNum, string mbuildingName
            , int mfloorNum, string mdeviceType, int mslaveNum,int mduring)
            : base(mip, mport, mdeviceNum, mbuildingName, mfloorNum, mdeviceType, mduring)
        {
            slaveNum = mslaveNum;
        }
       
    }
    public class Bean_DED194E_9S1YK4K4 : BaseBean
    {
        int slaveNum;//从机编号

        public int SlaveNum
        {
            get { return slaveNum; }
            set { slaveNum = value; }
        }
        public Bean_DED194E_9S1YK4K4()
        {
            Baud = 9600;
            slaveNum = 1;
            ClassName = "DED194E_9S1YK4K4";
            During = 5000;
            DeviceType = "DED194E_9S1YK4K4";

        }
    }
    public class BeanTools{
        public static BaseBean getBeanFromXML(String beanname,string  filepath)
        {
            return (BaseBean)XMLSerializerHelper.XmlDeserialize(ReflectTools.getType("Tools", "Tools", beanname)
                            , filepath);
        }
    }
    public class IOBaseBean
    {
        public string imagePath;
        public int ioIndex;
        public Boolean useing = false;
        //坐标
        public Point mpoint;
        public string detail;//输入描述
        public string sort;//
    }
    public class InputBaseBean : IOBaseBean
    {
       
    }

    public class AIBean:InputBaseBean 
    {
        
        public string function;
        public string maxVaule;
        public string mixVaule;
    }
    public class DIBean : InputBaseBean
    {
        public string imageClosePath;//关闭状态下的图片路径
        //public string function;
        public Boolean normalVaule;//正常值
        //public string mixVaule;
    }
    public class OutputBaseBean : IOBaseBean
    {
    }
    public class DOBean : OutputBaseBean
    {
        public string imageClosePath;//关闭状态下的图片路径
        public Boolean normalVaule;//正常值
    }
    public class Bean_C2000MDxA : BaseBean
    {
        int slaveNum;//从机编号
        public AIBean[] aiBeans;
        public DIBean[] diBeans;
        public Boolean VorI;//电压或者电流设备选型
        public int SlaveNum
        {
            get { return slaveNum; }
            set { slaveNum = value; }
        }
        public  Bean_C2000MDxA()
        {
            Baud = 9600;
            slaveNum = 1;
            ClassName = "C2000MDxA";
            During = 5000;
            DeviceType = "C2000MDxA";
        }
    }
    public class Bean_C2000MD82 : BaseBean
    {
        int slaveNum;//从机编号
        public DIBean[] diBeans;
        public DOBean[] doBeans;
        //public Boolean VorI;//电压或者电流设备选型
        public int SlaveNum
        {
            get { return slaveNum; }
            set { slaveNum = value; }
        }
        public Bean_C2000MD82()
        {
            Baud = 9600;
            slaveNum = 1;
            ClassName = "C2000MD82";
            During = 5000;
            DeviceType = "C2000MD82";
        }
    }
    public class Bean_C2000M281 : Bean_C2000MD82
    {
        public Bean_C2000M281(){
            Port = 502;
        }
        
    }
    public class Bean_C2000MH08:BaseBean
    {
        public int slaveNum;//从机编号
        public string[] detail = new string[8];
        public string[] normalVaule = new string[8];
        public Bean_C2000MH08()
        {
            this.Sort = "电";
            Baud = 9600;
            slaveNum = 1;
            ClassName = "C2000MH08";
            During = 5000;
            DeviceType = "C2000MH08";
        }
        
    }
    public class CameraBaseBean:BaseBean
    {
        public CameraBaseBean()
        {
            During = 0;
        }
    }
    public class DigitalCameraBean:CameraBaseBean
    {
      
        public string username = "admin";
        public string password = "12345";
        public string channel = "1";
    }
    public class Bean_HIKVISION : DigitalCameraBean
    {
        public Bean_HIKVISION()
        {
            Ip = "192.168.100.210";
            Port = 8000;
            ClassName = "HIKVISION";
        }
    }
}
