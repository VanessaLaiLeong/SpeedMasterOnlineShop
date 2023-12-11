<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FOMaster.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="SpeedMaster.FO.Billing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" runat="server" href="/FO/css/shop.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex align-items-center justify-content-center" style="height: 72vh;">
    <div class="filter-container d-flex align-items-center justify-content-center">
            <asp:TextBox ID="tb_nome" runat="server" Placeholder="Nome" CssClass="filter-input"></asp:TextBox>
            <asp:TextBox ID="tb_morada" runat="server" Placeholder="Morada" CssClass="filter-input"></asp:TextBox>
            <asp:TextBox ID="tb_email" runat="server"  Placeholder="Email" CssClass="filter-input"></asp:TextBox>
            <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="filter-input" OnClick="btn_submit_Click" />
    </div>
    </div>
</asp:Content>
