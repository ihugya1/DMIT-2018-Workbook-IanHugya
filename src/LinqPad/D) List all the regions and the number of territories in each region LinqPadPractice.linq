<Query Kind="Expression">
  <Connection>
    <ID>caae588d-6620-452b-a933-2a1ddc57f8f4</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//D) List all the regions and the number of territories in each region
from person in Regions



select new

{
  regionName  = person.RegionDescription + person.Territories.Count
}