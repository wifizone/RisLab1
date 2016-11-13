using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RisLab1;

namespace RisLab1Server
{
    class ReceivedMessage
    {
        public string Label { get; set; }
        public List<DbEntry> DbEntries { get; set; }
    }
}
