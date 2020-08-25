using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public class ConnectionData
    {
        public static int Port { get; set; } = 11000;
        public static int BufSize { get; set; } = 512;
        public static string IPAddr { get; set; } = "127.0.0.1";
    }
}
