<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="UpdateProductDetailsMotorcycle.aspx.cs" Inherits="SpeedMaster.BO.UpdateProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Motorcycle Details</h2>
    <div class="form-group container">
        <label id="lbl_model" runat="server">Model</label>
        <asp:TextBox ID="tb_model" runat="server" class="form-control" placeholder="model" />
        <br />
        <label id="lbl_engType" runat="server">Engine Type</label>
        <asp:TextBox ID="tb_engType" runat="server" class="form-control" placeholder="engine type" />
        <br />
        <label id="lbl_engCap" runat="server">Engine Capacity</label>
        <asp:TextBox ID="tb_engCap" runat="server" class="form-control" placeholder="engine capcity" />
        <br />
        <label id="lbl_color" runat="server">Color</label>
        <asp:TextBox ID="tb_color" runat="server" class="form-control" placeholder="color" />
        <br />
        <label id="lbl_condition" runat="server">Condition</label>
        <asp:TextBox ID="tb_condition" runat="server" class="form-control" placeholder="condition" />
        <br />
        <label id="lbl_manu_date" runat="server">Manufacturing Date</label>
        <asp:TextBox ID="tb_manuDate" runat="server" class="form-control" placeholder="Manufacturing Date" />
        <br />
        <label id="lbl_description" runat="server">Description</label>
        <asp:TextBox ID="tb_description" runat="server" class="form-control" placeholder="description" />
        <br />
        <label id="lbl_price" runat="server">Price</label>
        <asp:TextBox ID="tb_price" runat="server" class="form-control" placeholder="Price" />
        <br />
        <label id="Label1" runat="server">Active</label>
        <asp:RadioButtonList ID="rd_active" runat="server">
            <asp:ListItem>yes</asp:ListItem>
            <asp:ListItem>no</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:DropDownList ID="ddl_Brand" runat="server" DataSourceID="SqlDataSource1" DataTextField="BrandName" DataValueField="ID_Brand"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SpeedMasterConnectionString %>" SelectCommand="SELECT * FROM [Brands]"></asp:SqlDataSource>
        <br />
        <asp:FileUpload ID="fu_moto" runat="server" />
        <br />
        <br />
        <asp:Button ID="btn_submit" runat="server" OnClick="bnt_update_Click" Text="submit" class="btn btn-success" />
        <asp:Button ID="btn_delete" runat="server" OnClick="btn_delete_Click" Text="delete" class="btn btn-danger" />
    </div>
</asp:Content>
