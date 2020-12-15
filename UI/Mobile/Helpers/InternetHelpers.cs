// -------------------------------------------------------------------------------------------------
// Copyright (c) MedGame Technologies AB. All rights reserved.
// -------------------------------------------------------------------------------------------------

using MedGame.Settings;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mqtt;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MedGame.Common.Helpers
{
    public static class InternetHelpers
    {




        /// <summary>
        /// Checks if MedGame Business is online or not.
        /// </summary>
        public static void CheckIfMedGameBusinessIsOnline(string microservice)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send(microservice, 1000);

                    if (reply.Status != IPStatus.Success)
                    {
                        Debug.WriteLine("Can not connect to server: " + reply.Status);
                        Environment.Exit(0);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Can not connect to server: " + ex.InnerException);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Returns the first local ip address.
        /// </summary>
        /// <returns>String of IpAddress.</returns>
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            Console.WriteLine("No network adapters with an IPv4 address in the system!");
            Environment.Exit(0);
            return null;
        }

        /// <summary>
        /// Prin out all Ipv4 addresses that can be found.
        /// </summary>
        public static void PrintAllIpAddresses()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine(ip.ToString());
                }
            }
        }
    }
}
