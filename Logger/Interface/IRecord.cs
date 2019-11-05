using System;
using System.Collections.Generic;
using System.Text;
using Logger.Enum;

namespace Logger.Interface
{
    interface IRecord
    {
        
        IRecord setLevel(LogLevel level);
        IRecord setMessage(string message);
        IRecord setContext(Dictionary<string, string> context);
        DateTime getDate();
        LogLevel getLevel();
        string getMessage();
        Dictionary<string, string> getContext();

        dynamic serialize();
    }
}