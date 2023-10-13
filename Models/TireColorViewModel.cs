using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcTire.Models
{
    public class TireColorViewModel
    {
        public List<Tire> Tires { get; set; }
        public SelectList Colors { get; set; }
        public string TireColor { get; set; }
        public string SearchString { get; set; }
    }
}