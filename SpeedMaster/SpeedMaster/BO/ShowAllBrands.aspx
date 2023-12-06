<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ShowAllBrands.aspx.cs" Inherits="SpeedMaster.BO.ShowAllBrands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rp_showBrands" runat="server" OnItemDataBound="rp_showBrands_ItemDataBound" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            Brandname: <asp:Label ID="lbl_brandName" runat="server" Text=""></asp:Label>
            <br />
            CountryOfOrigin: <asp:Label ID="lbl_countryOfOrigin" runat="server" Text=""></asp:Label>
            <br />
            <br />
        </ItemTemplate>
    </asp:Repeater>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SpeedMasterConnectionString %>" SelectCommand="SELECT [BrandName], [CountryOfOrigin] FROM [Brands]"></asp:SqlDataSource>

</asp:Content>
