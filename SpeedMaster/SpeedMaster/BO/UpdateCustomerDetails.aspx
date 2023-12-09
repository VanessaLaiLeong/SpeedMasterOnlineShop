<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="UpdateCustomerDetails.aspx.cs" Inherits="SpeedMaster.BO.UpdateCustomerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="tb_email" runat="server" ></asp:TextBox>
    <asp:TextBox ID="tb_firstname" runat="server" ></asp:TextBox>
    <asp:TextBox ID="tb_lastname" runat="server" ></asp:TextBox>
    <asp:TextBox ID="tb_password" runat="server" ></asp:TextBox>
    <asp:TextBox ID="tb_adress" runat="server" ></asp:TextBox>
    <asp:TextBox ID="tb_phone" runat="server" ></asp:TextBox>
    <asp:TextBox ID="tb_nif" runat="server" ></asp:TextBox>
    <asp:Button ID="update" runat="server" Text="Update Customer Details" OnClick="update_Click" />
</asp:Content>
