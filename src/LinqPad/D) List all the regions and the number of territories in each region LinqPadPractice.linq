<Query Kind="Expression">
  <Connection>
    <ID>05a2444e-14ea-4451-ad3d-3398e9ff7898</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//D) List all the regions and the number of territories in each region
from person in Regions



select new

{
  regionName  = person.RegionDescription ,
  person.Territories.Count
}