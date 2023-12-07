<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UpdateProductDetailsMotorcycle.aspx.cs" Inherits="SpeedMaster.BO.UpdateProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
    
    <asp:Button ID="bnt_update" runat="server" Text="Button" OnClick="bnt_update_Click" />
</asp:Content>
