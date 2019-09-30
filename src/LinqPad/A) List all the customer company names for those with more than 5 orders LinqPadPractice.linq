<Query Kind="Expression">
  <Connection>
    <ID>caae588d-6620-452b-a933-2a1ddc57f8f4</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

//A) List all the customer company names for those with more than 5 orders.
from person in Customers

where person.Orders.Count > 5

select new

{
  companyName  = person.CompanyName 
}