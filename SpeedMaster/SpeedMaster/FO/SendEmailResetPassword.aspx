<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FOMaster.Master" AutoEventWireup="true" CodeBehind="SendEmailResetPassword.aspx.cs" Inherits="SpeedMaster.FO.SendEmailResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="tb_email" runat="server"></asp:TextBox>
    <asp:Button ID="btn_sendEmail" runat="server" Text="Send" OnClick="btn_sendEmail_Click" />
</asp:Content>
