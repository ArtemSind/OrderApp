using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string FromCity { get; set; }
        public string FromAdress { get; set; }
        public string ToCity { get; set; }
        public string ToAdress { get; set; }
        public double Weight { get; set; }
        public string Date { get; set; }
    }
}
