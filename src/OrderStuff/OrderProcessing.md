# Order Processing

> Orders are shipped directly from our suppliers to our customers. As such, suppliers log onto our system to see what orders there are for the products that they provide.

## User Interface

Suppliers will be interacting with a page that shows the following information.

![Mockup](./Shipping-Orders.svg)

The information shown here will be displayed in a **ListView**, using the *SelectedItemTemplate* as the part that shows the details for a given order.

## POCOs

### Queries
```csharp
public class OrderProductInformation{
public int ProductId{get;set;}
public string PrductName{get;set;}
public short Qty{get;set;}
public string  QtyPerUnit{get;set;}
public int Outstanding{get;set;}
                

}
```
### Commands

## BLL Processing
