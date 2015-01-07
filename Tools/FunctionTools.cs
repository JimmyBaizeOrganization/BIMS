using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Tools
{
    public static class FunctionTools
    {
        public static decimal calculateByString(decimal input, string expressions)
        {
            DataTable table = new DataTable();
            //int result=0;
            //object o = table.Compute(string.Format(expressions,input),"");
            //int.TryParse(table.Compute(string.Format(expressions,input), "").ToString(),out result);
            return (decimal)table.Compute(string.Format(expressions, input), "");            
        }
        public static string GetEnumDes(this Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }
     
    }

    public enum BIMSConnectState
    {
        OK = 0,
        [Description("TCPIP连接异常")]   
        ERROR_TCPIP = 1,
        [Description("设备数据校验异常")] 
        ERROR_CHECKSUM = 2,
        [Description("数据库连接异常")] 
        ERROR_DATABASE = 3,
    }
}
