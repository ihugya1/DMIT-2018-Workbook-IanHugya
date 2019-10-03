<Query Kind="Expression">
  <Connection>
    <ID>05a2444e-14ea-4451-ad3d-3398e9ff7898</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//  I) List the company names of all Suppliers in North America (Canada, USA, Mexico)
from supplier in Suppliers

where supplier.Address.Country.Contains("Canada") || supplier.Address.Country.Contains("USA") || supplier.Address.Country.Contains("Mexico")
select supplier.CompanyName