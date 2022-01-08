using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_wine_collection.Models
{
    public class Producer
    {
        public int ID { get; set; }
        public string ProducerName { get; set; }
        public ICollection<Wine> Drinks { get; set; }
    }
}
