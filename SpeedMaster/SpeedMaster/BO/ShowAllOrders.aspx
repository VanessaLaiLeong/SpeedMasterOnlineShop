<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="ShowAllOrders.aspx.cs" Inherits="SpeedMaster.BO.ShowAllOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-4">
        <div class="col-md-3">
            <asp:DropDownList ID="ddl_productType" class="form-select" runat="server">
                <asp:ListItem>Select a Filter</asp:ListItem>
                <asp:ListItem>Name</asp:ListItem>
                <asp:ListItem>Filter_2</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-6 d-flex justify-content-start">
            <asp:Button ID="btn_createProduct" class="btn btn-success me-2" runat="server" Text="Create" />
            <asp:Button ID="btn_modifyProduct" class="btn btn-primary me-2" runat="server" Text="Modify" />
            <asp:Button ID="btn_deleteProduct" class="btn btn-danger me-2" runat="server" Text="Erase" />
        </div>
    </div>
    <div class="container">
        <table class="table">
            <asp:Repeater ID="rp_orders" runat="server" OnItemDataBound="rp_orders_ItemDataBound" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_idOrder" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_orderDate" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_shippingDate" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_totalAmount" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_statusName" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="btn_edit" runat="server" OnClick="btn_edit_Click" Text="submit" CommandArgument='<%# Eval("ID_Order") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SpeedMasterConnectionString %>" SelectCommand="select ID_Order, OrderDate, ShippingDate, TotalAmount, StatusName from Orders as o inner join OrderStatus as s on o.ID_OrderStatus = s.ID_OrderStatus;"></asp:SqlDataSource>
</asp:Content>
