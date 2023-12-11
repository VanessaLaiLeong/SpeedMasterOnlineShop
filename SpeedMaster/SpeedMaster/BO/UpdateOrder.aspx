﻿<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="UpdateOrder.aspx.cs" Inherits="SpeedMaster.BO.UpdateOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:TextBox ID="tb_orderDate" runat="server" Text=""></asp:TextBox>
        <br />
        <asp:TextBox ID="tb_ShippingDate" runat="server" Text=""></asp:TextBox>
        <br />
        <asp:TextBox ID="tb_totalAmount" runat="server" Text=""></asp:TextBox>
        <br />
        <asp:DropDownList ID="dp_orderStatus" runat="server" DataSourceID="SqlDataSource1" DataTextField="StatusName" DataValueField="StatusName"></asp:DropDownList>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SpeedMasterConnectionString %>" SelectCommand="SELECT DISTINCT [StatusName] FROM [OrderStatus]"></asp:SqlDataSource>
        <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="submit" />
    </div>
</asp:Content>
