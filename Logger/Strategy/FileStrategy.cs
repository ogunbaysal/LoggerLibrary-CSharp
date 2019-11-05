using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Logger.Enum;
using Logger.Interface;

namespace Logger.Strategy
{
    class FileStrategy : Strategy
    {
        private const string FILE_NAME = "logs.txt";
        private const string REAGENT = "-*-*-*-*-*-*-*-*-*-*-*-"; //ayıraç
        private const string ITEM_SEPERATOR = "//**//";
        private readonly string _filePath;
        public FileStrategy(string filePath)
        {
            this._filePath = filePath;
        }
        public FileStrategy()
        {
            this._filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + FILE_NAME;
        }
        public override void close()
        {
            throw new NotImplementedException();
        }

        public override void deleteLogs()
        {
            System.IO.File.Delete(_filePath);
        }
        public override List<IRecord> getLogs()
        {
            List<IRecord> records = new List<IRecord>();
            var data = System.IO.File.ReadAllText(_filePath);
            string[] filter = {REAGENT};
            string[] parsed = data.Split(filter, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in parsed)
            {
                string newItem = item.Replace("\r\n", "");
                string onLinuxNewItem = item.Replace("\n", "");
                if(newItem == "" || onLinuxNewItem == "") continue;
                string[] seperatorArr = {ITEM_SEPERATOR};
                string[] parsedItem = newItem.Split(seperatorArr, StringSplitOptions.RemoveEmptyEntries);

                DateTime time = Convert.ToDateTime(parsedItem[2].Split(':')[1].Trim().ToString());
                Record tmp = new Record(time);
                LogLevel level;
                if (LogLevel.TryParse(parsedItem[0].Split(':')[1].Trim().ToString(), out level))
                {
                    tmp.setLevel(level);
                }
                tmp.setMessage(parsedItem[1].Split(':')[1].Trim().ToString());
                records.Add(tmp);
            }

            return records;
        }

        public override bool handle(IRecord record)
        {
            try
            {
                using (StreamWriter w = File.AppendText(this._filePath))
                {
                    return writeLog(record, w);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool writeLog(IRecord record, TextWriter writer)
        {
            try
            {
                writer.Write("Log Level : ");
                writer.WriteLine(record.getLevel() + ITEM_SEPERATOR);
                writer.Write("Log Message : ");
                writer.WriteLine(record.getMessage() + ITEM_SEPERATOR);
                writer.Write("Date : ");
                writer.WriteLine(record.getDate().ToShortDateString() + ITEM_SEPERATOR);
                writer.WriteLine(REAGENT);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
