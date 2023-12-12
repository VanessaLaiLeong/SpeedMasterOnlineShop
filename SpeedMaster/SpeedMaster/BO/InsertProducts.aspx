<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="InsertProducts.aspx.cs" Inherits="SpeedMaster.BO.InsertProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" >
        <asp:ListItem>Motorcycle</asp:ListItem>
        <asp:ListItem>Accessories</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btn_next" runat="server" Text="Button" OnClick="btn_next_Click" class="btn btn-success"/>
</asp:Content>
