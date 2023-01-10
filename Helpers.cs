using System;
using System.Net;
using System.Text.RegularExpressions;

namespace WakeOnLANTool
{
    public static class Helpers
    {
        static public string domain = ".lan";

        public static IPAddress getIPfromHostname(string hostname)
        {
            IPHostEntry host;
            try
            {
                host = Dns.GetHostEntry(hostname);
            } catch (Exception hostname_except)
            {
                Console.WriteLine(hostname_except.ToString());
                throw hostname_except;
            }
            Console.WriteLine(host.HostName);
            foreach(IPAddress addr in host.AddressList)
            {
                if(addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    Console.WriteLine(addr.ToString());
                    Console.WriteLine(addr.AddressFamily);
                    return addr;
                }
            }

            // 192.168.80.79
            //return new IPAddress(0x4F50A8C0);
            return new IPAddress(0x00000000);

        }
    
        public class MACAddress
        {
            public string rawString;
            public MACAddress(string macString=null)
            {
                this.rawString = macString;
            }

            /// <summary>
            ///     Converts an IP address string to an System.Net.IPAddress instance.
            /// </summary>
            /// <param name="macString">
            ///     A string that contains a MAC address in hexadecimal notation.
            /// <code>
            /// AABBCCDDEEFF
            /// AA:BB:CC:DD:EE:FF
            /// AA-BB-CC-DD-EE-FF
            /// </code>
            /// </param>
            /// <returns>A <see cref="WakeOnLANTool"/>.<see cref="Helpers"/>.<see cref="MACAddress"/> instance.</returns>
            /// <exception cref="System.ArgumentNullException">macString is null</exception>
            /// <exception cref="System.FormatException">macString is not a valid MAC address</exception>
            public static MACAddress Parse(string macString)
            {
                if (macString is null) { throw new ArgumentNullException("macString", "is null"); }
                macString = macString.ToUpper();
                string pattern = @"^([0-9A-F]{2,2}[:-]?){6,6}$";
                if(Regex.IsMatch(macString, pattern))
                {
                    return new MACAddress(macString);
                }
                throw new FormatException($"{macString} is not a valid MAC address.");
            }
            /// <summary>
            ///     Determines whether a string is a valid MAC address.
            /// </summary>
            /// <param name="macString">The string to validate.</param>
            /// <param name="address">The <see cref="WakeOnLANTool"/>.<see cref="Helpers"/>.<see cref="MACAddress"/> version of the string.</param>
            /// <returns>true if macString was able to be parsed as a MAC address; otherwise, false.</returns>
            public static bool TryParse(string macString, out MACAddress address)
            {
                try
                {
                    address = MACAddress.Parse(macString);
                    return true;
                } 
                catch
                {
                    address = null;
                    return false;
                }
                
            }
        }

        public class IPv4Address
        {
            String str_IP;
            public IPv4Address(string ipString)
            {
                this.str_IP = ipString;
            }

            public static IPv4Address Parse(string ipString)
            {
                if (ipString is null) { throw new ArgumentNullException("ipString", "is null"); }
                string pattern = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9]?[0-9])\.?){4,4}$";
                if (Regex.IsMatch(ipString, pattern))
                {
                    return new IPv4Address(ipString);
                }
                throw new FormatException($"{ipString} is not a valid IP address.");
            }
        }

    }
}
