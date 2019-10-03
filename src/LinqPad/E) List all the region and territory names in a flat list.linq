<Query Kind="Expression">
  <Connection>
    <ID>05a2444e-14ea-4451-ad3d-3398e9ff7898</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//E) List all the region and territory names in a "flat" list

from data in Territories

select new
{
Region = data.Region.RegionDescription,
Territory = data.TerritoryDescription 
}