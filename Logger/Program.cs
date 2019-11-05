using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Logger.Enum;
using Logger.Interface;
using Logger.Strategy;

namespace Logger
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Logger logger = LoggerCreator.LoggerFactory("test", LogStrategy.FILE);
            FileStrategy strategy = new FileStrategy(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Logger loggers = LoggerCreator.LoggerFactory("test", strategy);
            logger.Info(new Record("Bu Bir Test Info Logudur!!!"));
            logger.Warning(new Record("Bu Bir Test Warning Logudur!!!"));
            Record record = new Record("This is a Test Log");
            logger.Warning(record);
            record.setLevel(LogLevel.Alert);
            logger.Log(record);
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