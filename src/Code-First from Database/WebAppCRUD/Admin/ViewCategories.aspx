<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCategories.aspx.cs" Inherits="WebAppCRUD.Admin.ViewCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Categories</h1>

    <asp:ListView ID="CategoryListView" runat="server" DataSourceID="CategoryDataSource" ItemType="WestWindSystem.Entities.Category">
        <LayoutTemplate>
            <div id="itemPlaceholder" runat="server">

            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div>
                  <img src='<%# "data:" + Item.PictureMimeType + ";base64," + Convert.ToBase64String(Item.Picture) %>' alt="Alternate Text" width="50px" />
                <b><%# Item.CategoryName %></b>
                <i><%# Item.Description %></i>
              
            </div>
        </ItemTemplate>
    </asp:ListView>

    <asp:ObjectDataSource ID="CategoryDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListCategories" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>
