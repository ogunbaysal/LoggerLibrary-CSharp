using System;
using System.Collections.Generic;
using System.Text;
using Logger.Interface;

namespace Logger.Formatter
{
    abstract class Formatter : IFormatter
    {
        protected readonly IRecord _record;
        protected StringBuilder _formatted = null;
        protected Formatter(IRecord record)
        {
            this._record = record;
        }

        public abstract IFormatter format();

        public string getFormatted()
        {
            return _formatted.ToString();
        }
    }
}
