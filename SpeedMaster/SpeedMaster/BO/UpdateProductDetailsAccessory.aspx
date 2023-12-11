<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="UpdateProductDetailsAccessory.aspx.cs" Inherits="SpeedMaster.BO.UpdateProductDetailAccessory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Accessory details</h2>
    <div class="form-group container">
        <label id="lbl_name" runat="server">Name</label>
        <asp:TextBox ID="in_name" runat="server" class="form-control" placeholder="name" />
        <br />
        <label id="lbl_description" runat="server">Description</label>
        <asp:TextBox ID="in_description" runat="server" class="form-control" placeholder="description"></asp:TextBox>
        <br />
        <label id="lbl_price" runat="server">Price</label>
        <asp:TextBox ID="in_price" type="number" runat="server" class="form-control" placeholder="Price" />
        <br />
        <label id="lbl_stock" runat="server">Stock</label>
        <asp:TextBox ID="in_stock" type="number" runat="server" class="form-control" placeholder="Stock" />
        <br />
        <label id="lbl_category" runat="server">Category</label>
        <asp:DropDownList ID="dp_category" runat="server" DataSourceID="SqlDataSource2" DataTextField="CategoryName" DataValueField="ID_Category"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SpeedMasterConnectionString %>" SelectCommand="SELECT * FROM [Categories]"></asp:SqlDataSource>
        <br />
        <asp:FileUpload ID="fu_access" runat="server" />
        <br />
        <br />
        <asp:Button ID="btn_submit" runat="server" OnClick="update_Click" Text="submit" class="btn btn-success" />
        <asp:Button ID="btn_delete" runat="server" OnClick="btn_delete_Click" Text="delete" class="btn btn-danger" />
    </div>
</asp:Content>
