using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
        public int StatusId { get; set; }
        public int ColorId { get; set; }
        public string Description { get; set; }
    }
}
