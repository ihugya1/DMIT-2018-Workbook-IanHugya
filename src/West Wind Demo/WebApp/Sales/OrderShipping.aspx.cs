﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Admin.Security;
using WebApp.UserControls;
using WestWindSystem.BLL;
using WestWindSystem.DataModels;

namespace WebApp.Sales
{
    public partial class OrderShipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only allow suppliers to use/access this page
            if (!Request.IsAuthenticated || !User.IsInRole(Settings.SupplierRole))
                Response.Redirect("~", true);
            
            if(!IsPostBack) // GET - first visit to the page
            {
                // Load up the info on the supplier
                // TODO: Replace hard-coded supplier ID with the user's supplier ID
                // - Show Company name and contact
                SupplierInfo.Text = "Temp supplier: ID 2";
            }
        }

        protected void CurrentOrders_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "Ship")
            {
                // Extract data from the form and call the BLL ship the order
                //Gather information from the form for the products to be shipped and the shipping information. This
                //Info is sent to the void OrderProcessingController.SHipOrder(int orderId, ShippingDirections shipping, list<ProductShipment> products)
                int orderId = 0;
                ShippingDirections shippingInfo = new ShippingDirections();

                Label idLabel = e.Item.FindControl("OrderIdLabel") as Label; //safe cast to a label
                if (idLabel != null)// I sucessfully got the control
                {
                    orderId = int.Parse(idLabel.Text);
                }
                DropDownList shipVia = e.Item.FindControl("ShipperDropDown") as DropDownList;
                if(shipVia != null)
                {
                    shippingInfo.ShipperId = int.Parse(shipVia.SelectedValue);
                }
               
                TextBox tracking = e.Item.FindControl("TrackingCode") as TextBox;
                if (tracking != null)
                {
                    shippingInfo.TrackingCode = tracking.Text;
                }
                
                TextBox freight = e.Item.FindControl("FreightCharge") as TextBox;
                decimal charge;
                if (freight != null && decimal.TryParse(freight.Text, out charge))
                {
                    shippingInfo.FreightCharge = charge;
                }
                //Extract the items being shipped, as per the GridView
                List<ProductShipment> itemShipped = new List<ProductShipment>();
                GridView gv = e.Item.FindControl("ProductsGridView") as GridView;
                if(gv != null)
                {
                    foreach(GridViewRow row in gv.Rows)
                    {
                        HiddenField prodHidden = row.FindControl("ProdId") as HiddenField;
                        TextBox shipqty = row.FindControl("ShipQuantity") as TextBox;
                        if (prodHidden != null && shipqty != null)
                        {
                            int qty;
                            if(int.TryParse(shipqty.Text, out qty))
                            {
                                var item = new ProductShipment
                                {
                                    ProductId = int.Parse(prodHidden.Value),
                                    ShipQuantity = qty
                                };
                                itemShipped.Add(item);
                            }
                        }
                    }
                }
                MessageUserControl.TryRun(() =>
                {
                    //send the data into the bll
                    var controller = new OrderProcessingController();
                    controller.ShipOrder(orderId, shippingInfo, itemShipped);
                }, "Success", "The order shipment information has been recorded");
                
            }
        }
    }
}