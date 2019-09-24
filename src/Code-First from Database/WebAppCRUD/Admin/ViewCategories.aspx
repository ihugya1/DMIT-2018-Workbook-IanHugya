<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCategories.aspx.cs" Inherits="WebAppCRUD.Admin.ViewCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Categories</h1>
<asp:ListView ID="CategoryListView" runat="server"
        DataSourceID="CategoryDataSource"
        InsertItemPosition="FirstItem"
        ItemType="WestWindSystem.Entities.Categories" 
       
        DataKeyNames="CategoryID"><%--REMEBER THIS--%>
        <LayoutTemplate>
              <table class="table table-hover table-condensed">
                  <thead>
                    <tr>
                        <th>CategoryID</th>
                        <th>Category Name</th>
                        <th>Description</th>
                        <th>Picture</th>
                        <th>PictureMimeType</th>
                       
                    </tr>
                </thead>
                  <tbody>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </tbody>
            </table>
        </LayoutTemplate>

     <ItemTemplate>
            <tr>
                <td><asp:LinkButton ID="EditSupplier" runat="server" CssClass="btn btn-info glyphicon glyphicon-pencil" CommandName="Edit"> Edit</asp:LinkButton>
                      <asp:LinkButton ID="Delete" runat="server" CssClass="btn btn-danger " CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this supplier?')">Delete</asp:LinkButton>
                </td>
              
                <td><%# Item.CategoryID %></td>
                <td>
                    <b><%# Item.CategoryName %></b>
                    &ndash;
             
                </td>
                <td>
                    <%# Item.Description %>
                    <br />
                   
                    &nbsp;&nbsp;
                 
                </td>
                <td>
                    <%# Item.Picture %>
                    <br />
                    <%# Item.Fax %>
                </td>
            </tr>
        </ItemTemplate>

    <asp:ObjectDataSource ID="CategoryDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListCategories" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>
