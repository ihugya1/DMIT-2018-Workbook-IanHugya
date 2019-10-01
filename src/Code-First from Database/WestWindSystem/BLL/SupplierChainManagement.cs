using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCRUD.ReadModels;
using WestWindSystem.DAL;

namespace WestWindSystem.BLL
{
    [DataObject]
    public class SupplierChainManagement
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SupplierSummary> GetSuppliersSummaries()
        {
            using(var context = new WestWindContext())
            {
                var result = from company in context.Suppliers
                             select new SupplierSummary
                             {
                                 Company = company.CompanyName,
                                 Contact = company.ContactName,
                                 Phone = company.Phone,
                                 Products = from item in company.Products
                                            select new SupplierProduct
                                            {
                                                Name = item.ProductName,
                                                Category = item.Category.CategoryName,
                                                QtyperUnit = item.QuantityPerUnit
                                            }
                                            
                             };
                return result.ToList();

            }
        }
    }
}
