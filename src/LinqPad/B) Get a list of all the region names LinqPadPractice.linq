<Query Kind="Expression">
  <Connection>
    <ID>caae588d-6620-452b-a933-2a1ddc57f8f4</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//B) Get a list of all the region names
from person in Regions



select new

{
  regionName  = person.RegionDescription 
}