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
    public class BeanTools{
        public static BaseBean getBeanFromXML(String beanname,string  filepath)
        {
            return (BaseBean)XMLSerializerHelper.XmlDeserialize(ReflectTools.getType("Tools", "Tools", beanname)
                            , filepath);
        }
    }
    
}
