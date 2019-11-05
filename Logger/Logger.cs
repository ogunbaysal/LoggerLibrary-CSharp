using System;
using System.Collections.Generic;
using Logger.Enum;
using Logger.Interface;
using Logger.Interfaces;

namespace Logger
{
    internal class Logger : ILogger
    {
        private string name;
        private ILogStrategy _logStrategy;
        
        public Logger(string name, ILogStrategy strategy)
        {
            this.name = name;
            this._logStrategy = strategy;
        }
        public bool addRecord(Record record)
        {
            try
            {
                _logStrategy.handle(record);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
        public void Log(Record record)
        {
            this.addRecord(record);
        }

        public void Debug(Record record)
        {
            record.setLevel(LogLevel.Debug);
            this.addRecord(record);
        }

        public void Info(Record record)
        {
            record.setLevel(LogLevel.Info);
            this.addRecord(record);
        }
        public void Notice(Record record)
        {
            record.setLevel(LogLevel.Notice);
            this.addRecord(record);
        }
        public void Warning(Record record)
        {
            record.setLevel(LogLevel.Warning);
            this.addRecord(record);
        }
        public void Error(Record record)
        {
            record.setLevel(LogLevel.Error);
            this.addRecord(record);
        }
        public void Critical(Record record)
        {
            record.setLevel(LogLevel.Critical);
            this.addRecord(record);
        }
        public void Alert(Record record)
        {
            record.setLevel(LogLevel.Alert);
            this.addRecord(record);
        }
        public void Emergency(Record record)
        {
            record.setLevel(LogLevel.Emergency);
            this.addRecord(record);
        }

        public string getName()
        {
            return this.name;
        }

        public void reset()
        {
            IResettable tmp = _logStrategy as IResettable;
            tmp?.reset();
        }

        public void close()
        {
            _logStrategy.close();
        }

        public List<IRecord> getLogs()
        {
            return this._logStrategy.getLogs();
        }

        public IRecord getLastLog()
        {
            return this._logStrategy.getLogs()[-1];
        }

        public ILogStrategy GetLogStrategy()
        {
            return _logStrategy;
        }
    }
}
