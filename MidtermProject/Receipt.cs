using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{

    public class Receipt
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Receipt(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
