using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DataModels;

namespace WestWindSystem.BLL
{
    public class OrderProcessingController
    {
       public List<OutstandingOrder> LoadOrders(int supplierId)
        {
            throw new NotImplementedException();
            /* TODO: Implemented this method
             * Validation:
                Make sure the supplier ID exists, otherwise throw exception
                [Advanced:] Make sure the logged-in user works for the identified supplier.
                Query for outstanding orders, getting data from the following tables:
                TODO: List table names*/
        }
        public List<ShipperSelection> ListShippers()
        {
            throw new NotImplementedException();
            //TODO : QUeries for all shippers.
        }
    }
}
