using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_wine_collection.Models
{
    public class Type
    {
        public int ID { get; set; }
        public string TypeName { get; set; }
        public ICollection<WineType> WineTypes { get; set; }
    }
}
