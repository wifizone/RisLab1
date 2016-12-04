using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisLab1
{
    [Serializable]
    public class DbEntry
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Location { get; set; }
        public string RAM { get; set; }
    }
}
