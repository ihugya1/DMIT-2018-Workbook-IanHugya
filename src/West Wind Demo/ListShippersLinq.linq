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
	var output = ListShippers();
	output.Dump();
}

// Define other methods and classes here
 public List<ShipperSelection> ListShippers()
        {
            //throw new NotImplementedException();
            //TODO : Queries for all shippers.
			var result = from shipper in Shippers
						select new ShipperSelection
						{
						ShipperID = shipper.ShipperID,
						Shipper = shipper.CompanyName
						};
						return result.ToList();
        }
		public class ShipperSelection
		{
		public int ShipperID {get;set;}
		public string Shipper {get;set;}
		}
