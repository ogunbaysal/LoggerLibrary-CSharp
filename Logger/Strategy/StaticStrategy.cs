using System;
using System.Collections.Generic;
using System.Text;
using Logger.Interface;

namespace Logger.Strategy
{
    class StaticStrategy : Strategy
    {
        private List<IRecord> logs;

        public StaticStrategy()
        {
            logs = new List<IRecord>();
        }
        public override void close()
        {
            this.logs = null;
        }

        public override bool handle(IRecord record)
        {
            _isHandling = true;
            this.logs.Add(record);
            _isHandling = false;
            return true;
        }
        
        public override List<IRecord> getLogs()
        {
            return this.logs;
        }

        public override void deleteLogs()
        {
            logs.Clear();
        }
    }
}
