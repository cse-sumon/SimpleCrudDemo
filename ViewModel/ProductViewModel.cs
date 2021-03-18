using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public IFormFile FormFile { get; set; }
        public IFormFile UpdateFormFile { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string Description { get; set; }
    }
}
