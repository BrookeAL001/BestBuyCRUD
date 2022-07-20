using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUD
{
    public class Product
    {
        //adding each column from the product table as properties
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; }
        public string StockLevel { get; set; }
    }
}
