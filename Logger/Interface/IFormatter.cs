using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Interface
{
    interface IFormatter
    {
        IFormatter format();
        string getFormatted();
    }
}
