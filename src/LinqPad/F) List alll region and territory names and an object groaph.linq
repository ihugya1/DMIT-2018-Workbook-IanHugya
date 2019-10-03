<Query Kind="Expression">
  <Connection>
    <ID>05a2444e-14ea-4451-ad3d-3398e9ff7898</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//F) List all the region and territory names as an "object graph"
  // - use a nested query

from data in Regions
select new
{
Region=data.RegionDescription,
Territory = from item in data.Territories
               select item.TerritoryDescription
}