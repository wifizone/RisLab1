using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisLab1
{
    [Serializable]
    public class SocketMessage
    {
        public string IP { get; set; }
        public List<DbEntry> DbEntries { get; set; }
    }
}
