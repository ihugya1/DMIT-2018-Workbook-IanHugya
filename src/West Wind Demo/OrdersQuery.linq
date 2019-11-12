<Query Kind="Program">
  <Connection>
    <ID>f96faa94-4f1c-4543-a56e-80cae12cb813</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

void Main()
{
	int supplier; // 1,2,7,8,16,19
	Scratchpad();
	
}
void Scratchpad(){
var result = from ord in Orders
	where !ord.Shipped // Still items to be shipped
	&& ord.OrderDate.HasValue //The order has been placed and is ready to ship
	select new OutstandingOrder{
	OrderId = ord.OrderID,
	ShipToName = ord.ShipName,
	OrderDate = ord.OrderDate.Value,
	RequiredBy = ord.RequiredDate.Value,
	 OutstandingItems = from detail in ord.OrderDetails 
	 					select new OrderProductInformation 
						{
						ProductId= detail.ProductID,
						ProductName = detail.Product.ProductName,
						Qty = detail.Quantity,
						QtyPerUnit = detail.Product.QuantityPerUnit,
						//TODO
						//Outstanding = (from ship in detail.Order.Shipments
						//				from item in ship.ManifestItems
						//				where item.ProductID == detail.ProductID
						//				select item.ShipQuantity)ToList().Sum()
						},
	//ord.Customer.Address,
	//note to self: if there is a shipto address, use that, otherwise use the customer address
	FullShippingAddress = ord.ShipAddressID.HasValue
	? Addresses.Where(x => x.AddressID == ord.ShipAddressID).Select(a => a.Address + Environment.NewLine +
	a.City + Environment.NewLine +
	a.Region + " " +
	a.Country + ", "+
	a.PostalCode).FirstOrDefault()
	: ord.Customer.Address.Address + Environment.NewLine+
	ord.Customer.Address.City + Environment.NewLine+
	ord.Customer.Address.Region +" "+
	ord.Customer.Address.Country +", " +
	ord.Customer.Address.PostalCode
	,
	Comments = ord.Comments
	};
	result.Dump();
}
// Define other methods and classes here
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
	public class OutstandingOrder
    {
        public int OrderId { get; set; }
        public string ShipToName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredBy { get; set; }
        public TimeSpan DaysRemaining { get; } // Calculated
        public IEnumerable<OrderProductInformation> OutstandingItems { get; set; }
        public string FullShippingAddress { get; set; }
        public string Comments { get; set; }
    }
   public class OrderProductInformation
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public short Qty { get; set; }
        public string QtyPerUnit { get; set; }
        public short Outstanding { get; set; }
        // NOTE: Outstanding <= OrderDetails.Quantity - Sum(ManifestItems.ShipQuantity) for that product/order
    }