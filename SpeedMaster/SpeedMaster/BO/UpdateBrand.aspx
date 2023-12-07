<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UpdateBrand.aspx.cs" Inherits="SpeedMaster.BO.UpdateBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="tb_brand_name" runat="server" Text=""></asp:TextBox>
    <br />
    <asp:TextBox ID="tb_brand_origin" runat="server" Text=""></asp:TextBox>
    <br />
    <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="Update values" />
    <asp:Button ID="btn_delete" runat="server" OnClick="btn_delete_Click" Text="Remove Brand" />
</asp:Content>
