using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_wine_collection.Models
{
    public class Wine
    {
        public int ID { get; set; }
        [Display(Name = "Label")]
        public string Name { get; set; }
        public string Region { get; set; }
        public string Year { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        public int ProducerID { get; set; }
        public Producer Producer { get; set; }
        public ICollection<WineType> WineTypes { get; set; }
    }
}
