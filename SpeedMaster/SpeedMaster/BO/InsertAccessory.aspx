<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="InsertAccessory.aspx.cs" Inherits="SpeedMaster.BO.InsertAccessory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <div class="form-group pb-2">
            <label for="lbl_name">Acessory Name</label>
            <asp:TextBox runat="server" class="form-control" ID="tb_name" placeholder="ex. Honda Gloves" />
        </div>
        <div class="form-group pb-2">
            <label for="lbl_Description">Acessory Description</label>
            <asp:TextBox runat="server" class="form-control" ID="tb_description" placeholder="ex. Female and male biker gloves in leather or textile with protections for greater safety. Available in various colors and..." />
        </div>
        <div class="form-group pb-2">
            <label for="lbl_Price">Acessory Price</label>
            <asp:TextBox runat="server" class="form-control" ID="tb_price" placeholder="ex. 200" />
        </div>
        <div class="form-group pb-2">
            <label for="lbl_stoc">Acessory Stock</label>
            <asp:TextBox runat="server" class="form-control" ID="tb_stock" placeholder="ex. 200" />
        </div>
        <asp:DropDownList ID="dp_category" runat="server" DataSourceID="SqlDataSource1" DataTextField="CategoryName" DataValueField="ID_Category"></asp:DropDownList>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:SpeedMasterConnectionString %>' SelectCommand="SELECT * FROM [Categories]"></asp:SqlDataSource>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btn_add" runat="server" class="btn btn-primary" Text="Submit" OnClick="btn_add_Click" />
        <br />
        <asp:Button runat="server" ID="btn_submit" type="submit" Text="Submit" class="btn btn-success mt-3"></asp:Button>
    </div>
    <asp:View ID="View1" runat="server"></asp:View>
</asp:Content>
