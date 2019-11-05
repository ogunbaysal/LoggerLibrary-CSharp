using System;
using System.Collections.Generic;
using System.Text;
using Logger.Interface;

namespace Logger.Formatter
{
    class JsonFormatter : Formatter
    {
        public JsonFormatter(IRecord record) : base(record)
        {
        }

        public override IFormatter format()
        {
            var source = _record.serialize();
            var output = new StringBuilder();
            output.Append("{");
            output.Append("'level' : '" + source.logLevel + "',");
            output.Append("'message' : '" + source.message + "',");
            output.Append("'dateTime' : '" + source.dateTime + "',");
            output.Append("'context' : {");
            foreach (var item in (Dictionary<string, string>)source.context)
            {
                output.Append(string.Format("'%s' : '%s'", item.Key.ToString(), item.Value.ToString()));
            }
            output.Append("}");
            output.Append("}");
            this._formatted = output;
            return this;
        }
    }
}
