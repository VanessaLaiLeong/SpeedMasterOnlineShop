<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="ShowAllProducts.aspx.cs" Inherits="SpeedMaster.BO.ShowAllProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Products</h1>
    <div class="row mb-4">
        <div class="col-md-3">
            <asp:DropDownList ID="ddl_productType" class="form-select" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_productType_SelectedIndexChanged">
                <asp:ListItem>Select a Filter</asp:ListItem>
                <asp:ListItem>Motorcycles</asp:ListItem>
                <asp:ListItem>Accessories</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
     <asp:Button ID="btn_insert_motorcycles" runat="server" OnClick="btn_insert_motorcycles_Click" class="btn btn-success" Text="Add Product" />
    <div id="div_motor" runat="server">
        <h3>Motorcycles</h3>
       
        <table id="table_motorcycles" class="table">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Brand</th>
                    <th scope="col">Model</th>
                    <th scope="col">Manufacturing Year</th>
                    <th scope="col">Engine Type</th>
                    <th scope="col">Engine Capacity</th>
                    <th scope="col">Color</th>
                    <th scope="col">Price</th>
                    <th scope="col">Condition</th>
                    <th scope="col">Details</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rp_motocycles" runat="server" DataSourceID="sql_motorcycles" OnItemDataBound="rp_motocycles_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td><asp:Label ID="lbl_motorId" runat="server" Text="N/A"></asp:Label></td>
                            <td><asp:Label ID="lbl_brand" runat="server" Text="N/A"></asp:Label></td>
                            <td><asp:Label ID="lbl_model" runat="server" Text="N/A"></asp:Label></td>
                            <td><asp:Label ID="lbl_manYear" runat="server" Text="N/A"></asp:Label></td>
                            <td><asp:Label ID="lbl_engType" runat="server" Text="N/A"></asp:Label></td>
                            <td><asp:Label ID="lbl_engCap" runat="server" Text="N/A"></asp:Label></td>
                            <td><asp:Label ID="lbl_color" runat="server" Text="N/A"></asp:Label></td>
                            <td><asp:Label ID="lbl_price" runat="server" Text="N/A"></asp:Label></td>
                            <td><asp:Label ID="lbl_condition" runat="server" Text="N/A"></asp:Label></td>
                            <td>
                                <asp:Button ID="btn_motorDetails" runat="server" CommandArgument='<%# Eval("ID_Motorcycle") %>' Text="Details" OnClick="btn_motorDetails_Click" CssClass="btn btn-secondary"/>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
    
    <div id="div_access" runat="server">
        <h3>Accessories</h3>
       
        <table id="table_accessories" class="table">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Name</th>
                    <th scope="col">Price</th>
                    <th scope="col">Stock</th>
                    <th scope="col"> Details</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rp_accessories" runat="server" DataSourceID="sql_accessories" OnItemDataBound="rp_accessories_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td><asp:Label ID="lbl_accessId" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lbl_accessName" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lbl_accessPrice" runat="server"></asp:Label></td>
                            <td><asp:Label ID="lbl_accessStock" runat="server"></asp:Label></td>
                            <td>
                                <asp:Button ID="btn_accessDetails" runat="server" CommandArgument='<%# Eval("ID_Accessory") %>' Text="Details" OnClick="btn_accessDetails_Click" CssClass="btn btn-secondary"/>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>

    <asp:SqlDataSource ID="sql_motorcycles" runat="server" ConnectionString="<%$ ConnectionStrings:SpeedMasterConnectionString %>" SelectCommand="select ID_Motorcycle, Brands.BrandName, Model, ManufactoringYear, EngineType, EngineCapacity, Color, Price, Condition from Motorcycles as m inner join  Brands on Brands.ID_Brand = m.ID_Brand;"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sql_accessories" runat="server" ConnectionString="<%$ ConnectionStrings:SpeedMasterConnectionString %>" SelectCommand="select * from Accessories;"></asp:SqlDataSource>
</asp:Content>
