<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSuppliers.aspx.cs" Inherits="WebAppCRUD.Admin.ViewSuppliers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Suppliers</h1>
    <asp:ObjectDataSource ID="SuppliersDataSoruce" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
    <asp:Repeater ID="SupplierRepeater" runat="server" ItemType="WestWindSystem.Entities.Supplier" DataSourceID="SuppliersDataSoruce">
        <HeaderTemplate>
            <ul>
               
        </HeaderTemplate>
        <ItemTemplate><li><b><%#Item.CompanyName %>&ndash;
            ><%#Item.ContactTitle %>
            &mdash;
            <a href="mailto:<%# Item.Email %>"><%#Item.ContactName %> </a>
            <%# Item.Phone %>
           
          
            </li></b></ItemTemplate>
        <SeparatorTemplate> </SeparatorTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
</asp:Content>
