using System;

using log4net;

namespace MassTransit3TestLib.StaticHelpers
{
    public static class ConsoleHelper
    {
        /// <summary>
        /// Writes to the log with a level of 'DEBUG'
        /// Also writes to the console when compiled in debug mode.
        /// Note: there will be no console to view when in a deployed environment
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="colour"></param>
        /// <param name="withDateTime"></param>
        public static void WriteLine(string msg, ConsoleColor colour = ConsoleColor.White, bool withDateTime = false)
        {
            if (withDateTime)
            {
                msg = DateTime.UtcNow.ToString("G") + " : " + msg;
            }
#if DEBUG
            Console.ForegroundColor = colour;

            if (colour == ConsoleColor.Black)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
#endif
            LogManager.GetLogger(typeof(ConsoleHelper).FullName).Debug(msg);
        }

        public static void WriteDebugLine(string msg, bool withDateTime = false)
        {
            if (withDateTime)
            {
                msg = DateTime.UtcNow.ToString("G") + " : " + msg;
            }

            System.Diagnostics.Debug.WriteLine(msg, "SERVICEBUS");
        }
    }
}
