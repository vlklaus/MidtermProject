using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//class for all the products
namespace MidtermProject
{
    public class Product
    {
        public string Name { get; set; }
        public string Categories { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        public Product(string name, string category, decimal price, string description)
        {
            Name = name;
            Categories = category;
            Description = description;
            Price = price;


        }
    }

} 