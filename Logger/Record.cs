using System;
using System.Collections.Generic;
using Logger.Enum;
using Logger.Interface;

namespace Logger
{
    internal class Record : IRecord
    {
        private LogLevel _logLevel;
        private string _levelName;
        private string _message;
        //it includes custom data
        private DateTime _dateTime;
        private Dictionary<string, string> _context;

        public Record()
        {
            this._dateTime = DateTime.Now;
        }

        public Record(DateTime datetime)
        {
            this._dateTime = datetime;
        }
        public Record(string message)
        {
            this.setMessage(message);
            this._dateTime = DateTime.Now;
        }
        public IRecord setLevel(LogLevel level)
        {
            this._logLevel = level;
            this._levelName = level.ToString();
            return this;
        }

        public Dictionary<string, string> getContext()
        {
            return this._context;
        }

        public dynamic serialize()
        {
            dynamic obj = new
            {
                logLevel = this._logLevel.ToString(),
                message = this._message,
                dateTime = this._dateTime,
                context = this._context
            };
            return obj;
        }
        public IRecord setMessage(string message)
        {
            this._message = message;
            return this;
        }


        public IRecord setContext(Dictionary<string, string> context)
        {
            this._context = context;
            return this;
        }

        public LogLevel getLevel()
        {
            return this._logLevel;
        }

        public string getMessage()
        {
            return this._message;
        }

        public DateTime getDate()
        {
            return this._dateTime;
        }
    }
}
