<Query Kind="Expression">
  <Connection>
    <ID>9f795fec-6525-43c5-bbd0-2819df27768a</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

from company in Suppliers
select new
{
Company= company.CompanyName,
Contact = company.ContactName,
Phone= company.Phone,
Products= from item in company.Products
	select new
	{
		Name=item.ProductName,
		Category= item.Category.CategoryName,
		Price= item.UnitPrice,
		QtyPerUnit= item.QuantityPerUnit
	}
	}
/*
Supplier: 
	Company Name
	Contact Nam
	Phone Number
	Produyct Summary;
		POroduct Name
		Category Name
		Unit PRice
		QUnaitity/Unit
		*/
		