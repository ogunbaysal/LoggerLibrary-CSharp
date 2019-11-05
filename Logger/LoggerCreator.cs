using System;
using Logger.Enum;
using Logger.Interface;
using Logger.Strategy;
using Logger;
namespace Logger
{
    internal class LoggerCreator
    {
        public static Logger LoggerFactory(string name, LogStrategy strategy = LogStrategy.STATIC)
        {
            ILogStrategy _strategy;
            switch (strategy)
            {
                case LogStrategy.STATIC:
                    _strategy = new StaticStrategy();
                    break;
                case LogStrategy.HTTP_API:
                    _strategy = new APIStrategy();
                    break;
                case LogStrategy.FILE:
                    _strategy = new FileStrategy();
                    break;
                default:
                    throw new Exception("Invalid Log Strategy!!");
                    break;
            }
            return new Logger(name, _strategy);
        }

        public static Logger LoggerFactory(string name, ILogStrategy strategy)
        {
            return new Logger(name, strategy);
        }
    }
}
