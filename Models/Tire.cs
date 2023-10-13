using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcTire.Models
{
    public class Tire
    {
            public int Id { get; set; }
            public string Brand { get; set; }
        public string Colour { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
            public decimal Size { get; set; }


    }
}
