using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppCRUD.ReadModels
{
    public class SupplierProduct
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string QtyperUnit { get; set; }
    }
}