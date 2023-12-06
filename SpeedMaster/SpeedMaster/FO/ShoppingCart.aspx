<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FOMaster.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="SpeedMaster.FO.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <asp:Label ID="lbl_productName" runat="server" Text="Label"></asp:Label>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <asp:Label ID="lbl_productName" runat="server" Text="Label"></asp:Label>
        </AlternatingItemTemplate>
    </asp:Repeater>
</asp:Content>
