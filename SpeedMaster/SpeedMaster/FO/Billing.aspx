<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FOMaster.Master" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="SpeedMaster.FO.Billing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="tb_nome" runat="server"></asp:TextBox>
    <asp:TextBox ID="tb_morada" runat="server"></asp:TextBox>
    <asp:TextBox ID="tb_email" runat="server"></asp:TextBox>
    <asp:Button ID="btn_submit" runat="server" Text="Button" OnClick="btn_submit_Click" />
</asp:Content>
