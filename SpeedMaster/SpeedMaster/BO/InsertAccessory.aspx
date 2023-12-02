<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="InsertAccessory.aspx.cs" Inherits="SpeedMaster.BO.InsertAccessory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btn_add" runat="server" Text="Button" OnClick="btn_add_Click" />
    <asp:View ID="View1" runat="server"></asp:View>
</asp:Content>
