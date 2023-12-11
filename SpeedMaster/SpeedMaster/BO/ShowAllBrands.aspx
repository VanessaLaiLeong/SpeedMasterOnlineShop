﻿<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="ShowAllBrands.aspx.cs" Inherits="SpeedMaster.BO.ShowAllBrands" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Products</h1>
    <div class="row mb-4">
        <div class="col-md-3">
            <asp:DropDownList ID="ddl_productType" class="form-select" runat="server">
                <asp:ListItem>Select a Filter</asp:ListItem>
                <asp:ListItem>Motorcycles</asp:ListItem>
                <asp:ListItem>Accessories</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-6 d-flex justify-content-start">
            <asp:Button ID="btn_createProduct" class="btn btn-success me-2" runat="server" Text="Create" OnClick="btn_createProduct_Click" />
        </div>
    </div>
    <table class="table">
        <thead>
            <tr>
                <th scope="col">Brand Name</th>
                <th scope="col">Country of Origin</th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rp_showBrands" runat="server" OnItemDataBound="rp_showBrands_ItemDataBound" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_brandName" runat="server" Text="Not found"></asp:Label></td>
                        <td>
                            <asp:Label ID="lbl_countryOfOrigin" runat="server" Text="Not found"></asp:Label></td>
                        <td>
                            <asp:Button ID="btn_brand" runat="server" CommandArgument='<%# Eval("ID_Brand") %>' Text="Details" OnClick="btn_brand_Click" CssClass="btn btn-secondary"/></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SpeedMasterConnectionString %>" SelectCommand="SELECT * FROM [Brands]"></asp:SqlDataSource>

</asp:Content>
