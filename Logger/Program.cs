using System;
using System.Collections.Generic;
using Logger.Enum;
using Logger.Interface;

namespace Logger
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Logger logger = LoggerCreator.LoggerFactory("test", LogStrategy.FILE);

            logger.Info(new Record("Bu Bir Test Info Logudur!!!"));
            logger.Warning(new Record("Bu Bir Test Warning Logudur!!!"));


            List<IRecord> logs = logger.getLogs();
            if (logs != null)
            {
                foreach (var item in logs)
                {
                    Console.WriteLine(item.getMessage() + " - " + item.getLevel());
                }
            }
            else
            {
                Console.WriteLine("No Log Found!!");
            }
            

            Console.ReadKey();
        }
    }
}