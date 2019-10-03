<Query Kind="Expression">
  <Connection>
    <ID>05a2444e-14ea-4451-ad3d-3398e9ff7898</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//G) List all the product names that contain the word "chef" in the name.
from product in Products

where product.ProductName.Contains("chef")
select product.ProductName