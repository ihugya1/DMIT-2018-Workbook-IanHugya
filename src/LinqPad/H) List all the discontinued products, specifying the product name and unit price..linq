<Query Kind="Expression">
  <Connection>
    <ID>05a2444e-14ea-4451-ad3d-3398e9ff7898</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// H) List all the discontinued products, specifying the product name and unit price.
from product in Products

where product.Discontinued.Equals(true)
select product.ProductName