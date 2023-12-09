<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="UpdateOrder.aspx.cs" Inherits="SpeedMaster.BO.UpdateOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:TextBox ID="tb_orderDate" runat="server"></asp:TextBox>
        <asp:TextBox ID="tb_ShippingDate" runat="server"></asp:TextBox>
        <asp:TextBox ID="tb_totalAmount" runat="server"></asp:TextBox>
        <asp:TextBox ID="tb_status" runat="server"></asp:TextBox>
        <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" />
    </div>
</asp:Content>
