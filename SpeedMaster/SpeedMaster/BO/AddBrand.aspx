<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="AddBrand.aspx.cs" Inherits="SpeedMaster.BO.AddBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="tb_brand_name" runat="server" Text="Brand name"></asp:TextBox>
    <asp:TextBox ID="tb_brand_origin" runat="server" Text="Country of origin"></asp:TextBox>
    <br />
    <asp:Button ID="btn_add_brand" runat="server" OnClick="btn_add_brand_Click" Text="Add" />
    <asp:Button ID="btn_discard" runat="server" OnClick="btn_discard_Click" Text="Discard" />
</asp:Content>
