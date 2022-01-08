using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_wine_collection.Models
{
    public class WineType
    {
        public int ID { get; set; }
        public int WineID { get; set; }
        public Wine Wine { get; set; }
        public int TypeID { get; set; }
        public Type Type { get; set; }
    }
}
