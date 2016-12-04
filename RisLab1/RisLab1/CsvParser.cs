using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RisLab1
{
    class CsvParser
    {
        const string csvPath = @"C:\Users\antonpoluianov\Source\Repos\RisLab1\RisLab1\RisLab1\csvFile\SmartPhones.csv";

        public List<DbEntry> GetDbEntries()
        {
            List<DbEntry> dbEntries = new List<DbEntry>();

            var reader = new StreamReader(File.OpenRead(csvPath));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var dbLine = line.Split(';');
                DbEntry dbEntry = ConvertToDbEntry(dbLine);
                dbEntries.Add(dbEntry);
            }

            return dbEntries;
        }

        public SocketMessage GetSocketMessage(string ip)
        {
            return new SocketMessage() {DbEntries = GetDbEntries(), IP = ip};
        }

        private static DbEntry ConvertToDbEntry(string[] values)
        {
            return new DbEntry()
            {
                Model = values[0],
                Brand = values[1],
                Location = values[2],
                RAM = values[3]
            };
        }

    }
}
