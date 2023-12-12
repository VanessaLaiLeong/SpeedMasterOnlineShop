<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="UpdateOrder.aspx.cs" Inherits="SpeedMaster.BO.UpdateOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        
        <label id="Label1" runat="server">Customer Email</label>
        <asp:TextBox ID="tb_email" runat="server" class="form-control" placeholder="Shopping Cart ID" />
        <br />

        <label id="lbl_OrderDate" runat="server">Order Date</label>
        <asp:TextBox ID="tb_OrderDate" runat="server" class="form-control" placeholder="Order Date" />
        <br />

        <label id="lbl_ShippingDate" runat="server">Shipping Date</label>
        <asp:TextBox ID="tb_ShippingDate" runat="server" class="form-control" placeholder="Shipping Date" />
        <br />

        <label id="lbl_TotalAmount" runat="server">Total Amount</label>
        <asp:TextBox ID="tb_TotalAmount" runat="server" class="form-control" placeholder="Total Amount" />
        <br />

        <label id="lbl_ID_OrderStatus" runat="server">Order Status ID</label>
        <asp:TextBox ID="tb_ID_OrderStatus" runat="server" class="form-control" placeholder="Order Status ID" />
        <br />

        <asp:Button ID="btn_enviarMail" runat="server" Text="Enviar mail de Review" CssClass="btn btn-primary" OnClick="btn_enviarMail_Click" />
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SpeedMasterConnectionString %>" SelectCommand="SELECT DISTINCT [StatusName] FROM [OrderStatus]"></asp:SqlDataSource>
</asp:Content>
