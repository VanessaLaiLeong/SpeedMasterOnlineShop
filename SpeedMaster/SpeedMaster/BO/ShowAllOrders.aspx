<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ShowAllOrders.aspx.cs" Inherits="SpeedMaster.BO.ShowAllOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SpeedMasterConnectionString %>" SelectCommand="select ID_Order, OrderDate, ShippingDate, TotalAmount, StatusName from Orders as o inner join OrderStatus as s on o.ID_OrderStatus = s.ID_OrderStatus;"></asp:SqlDataSource>
</asp:Content>
