<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplyChain.aspx.cs" Inherits="WebAppCRUD.Admin.SupplyChain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Active Suppliers</h1>
    <asp:ObjectDataSource runat="server" ID="SupplierSummaryDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSuppliersSummaries" TypeName="WestWindSystem.BLL.SupplierSummary" />
    <asp:Repeater ID="SupplierSummaryRepeater" runat="server" DataSourceID="SupplierSummaryDataSource" ItemType="WestWindSystem.ReadModels.SupplierSummary">
        <ItemTemplate>
            <div>
                <%#Item.Company %>
                <asp:Repeater ID="ProductRepeater" runat="server" DataSource"></asp:Repeater>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
