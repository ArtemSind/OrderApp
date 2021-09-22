using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Models
{
    public class Order
    {
        public string FromCity { get; set; }
        public string FromAdress { get; set; }
        public string ToCity { get; set; }
        public string ToAdress { get; set; }
        public double Weight { get; set; }
        public DateTime Date { get; set; }
    }
}
