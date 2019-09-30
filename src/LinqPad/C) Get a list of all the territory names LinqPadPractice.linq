<Query Kind="Expression">
  <Connection>
    <ID>caae588d-6620-452b-a933-2a1ddc57f8f4</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//C) Get a list of all the territory names
from person in Territories

select new

{
  regionName  = person.TerritoryDescription 
}