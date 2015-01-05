using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    class MessageCat
    {
        string com;
        private SerialPort port;
        public MessageCat(String acom,int baud)
        {
            com = acom;
            port = new SerialPort(com, baud, Parity.None, 8, StopBits.One);

        }
    }
}
