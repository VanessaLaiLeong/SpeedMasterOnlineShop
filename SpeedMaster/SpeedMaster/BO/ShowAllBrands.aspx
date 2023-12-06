<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ShowAllBrands.aspx.cs" Inherits="SpeedMaster.BO.ShowAllBrands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rp_brands" runat="server" DataSourceID="SqlDataSource1" OnItemDataBound="rp_brands_ItemDataBound">
        <ItemTemplate>
            <asp:Label ID="lbl_brandName" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbl_countryOfOrigin" runat="server"></asp:Label>
        </ItemTemplate>
    </asp:Repeater>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SpeedMasterConnectionString %>" SelectCommand="SELECT BrandName, CountryOfOrigin FROM [Brands]"></asp:SqlDataSource>
</asp:Content>
