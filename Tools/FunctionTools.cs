using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tools
{
    public  class FunctionTools
    {
        public static decimal calculateByString(decimal input, string expressions)
        {
            DataTable table = new DataTable();
            //int result=0;
            //object o = table.Compute(string.Format(expressions,input),"");
            //int.TryParse(table.Compute(string.Format(expressions,input), "").ToString(),out result);
            return (decimal)table.Compute(string.Format(expressions, input), "");            
        }

    }
    enum BIMSConnectState
    {
        OK = 0,
        ERROR_TCPIP = 1,
        ERROR_CHECKSUM = 2,
    }
}
