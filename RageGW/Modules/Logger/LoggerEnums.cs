using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RageGW.Modules.Logger
{
    class LoggerEnums : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Write("Module: LoggerEnums geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Write("Module: LoggerEnums entladen", LoggerEnums.LogType.Info);
        }

        public enum LogType
        {
            Success = ConsoleColor.Green,
            Warning = ConsoleColor.Yellow,
            Info = ConsoleColor.Blue,
            Error = ConsoleColor.Red
        }
    }
}
