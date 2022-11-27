using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RageGW.Modules.Logger.LoggerEnums;

namespace RageGW.Modules.Logger
{
    class Logger : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Write("Module: Logger geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Write("Module: Logger entladen", LoggerEnums.LogType.Info);
        }

        public Logger() { }

        public static void Write(string msg, LogType type)
        {
            if (type == LogType.Success)
            {
                Console.ForegroundColor = (ConsoleColor)type;
                Console.Write("[Success] ");
                Console.ResetColor();
                Console.WriteLine(msg);
            }

            if (type == LogType.Warning)
            {
                Console.ForegroundColor = (ConsoleColor)type;
                Console.Write("[Warning] ");
                Console.ResetColor();
                Console.WriteLine(msg);
            }

            if (type == LogType.Info)
            {
                Console.ForegroundColor = (ConsoleColor)type;
                Console.Write("[Information] ");
                Console.ResetColor();
                Console.WriteLine(msg);
            }

            if (type == LogType.Error)
            {
                Console.ForegroundColor = (ConsoleColor)type;
                Console.Write("[Error] ");
                Console.ResetColor();
                Console.WriteLine(msg);
            }
        }
    }
}
