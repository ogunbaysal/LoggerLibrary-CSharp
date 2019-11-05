using System;
using System.Collections.Generic;
using System.Text;
using Logger.Enum;

namespace Logger.Interface
{
    interface ILogStrategy
    {
        bool isHandling();
        bool handle(IRecord record);
        void handleAll(List<IRecord> records);
        void close();
        List<IRecord> getLogs();
        void deleteLogs();
    }
}
