using System;
using System.Collections.Generic;
using System.Text;
using Logger.Enum;
using Logger.Interface;

namespace Logger.Strategy
{
    abstract class Strategy : ILogStrategy
    {
        protected bool _isHandling = false;
        public abstract void close();
        public abstract bool handle(IRecord record);

        public void handleAll(List<IRecord> records)
        {
            foreach (var record in records)
            {
                this.handle(record);
            }
        }

        public bool isHandling()
        {
            return this._isHandling;
        }

        ~Strategy()
        {
            this.close();
        }

        public abstract List<IRecord> getLogs();
        public abstract void deleteLogs();
    }
}
