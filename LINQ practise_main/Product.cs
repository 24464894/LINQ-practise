using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LINQ_practise_main
{
    public class Product
    {
        
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }//dec
        public string Price { get; set; }//dec
        public string CommodityCategory { get; set; }
        
        public Product(string Line  )
        {
            var sp = Line.Split(',');
            ProductNumber = sp[0];
            ProductName = sp[1];
            ProductDescription = sp[2];
            Price = sp[3];
            CommodityCategory = sp[4];
        }

    }
}
