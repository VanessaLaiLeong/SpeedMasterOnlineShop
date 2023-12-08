<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FOMaster.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="SpeedMaster.FO.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="shoppingCart">
        <div class="card">
            <div class="row">
                <div class="col-8 cart">
                    <div class="title">
                        <div class="row">
                            <div class="col">
                                <h4><b>Shopping Cart</b></h4>
                            </div>

                        </div>
                    </div>

                    <table class="table p-5" style="font-size: 16px;">
                        <thead>
                            <tr>
                                <th scope="col">Product</th>
                                <th scope="col">Name</th>
                                <th scope="col">Price per unit</th>
                                <th scope="col">Quantity</th>
                                <th scope="col">Total price</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Image ID="productImg" runat="server" class="img-fluid" /></td>
                                        <td>
                                            <asp:Label ID="lbl_productName" runat="server" Text="Label"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lbl_productPriceSingle" runat="server" Text="Label"></asp:Label></td>
                                        <td>
                                            <asp:LinkButton ID="addCart" runat="server" CommandArgument='<%# Eval("ProductID") %>'><i class="fa-solid fa-plus"></i></asp:LinkButton>
                                            <asp:Label ID="lbl_productQuantity" runat="server" Text="Label" class="border"></asp:Label>
                                            <asp:LinkButton ID="delete_from_cart" runat="server" CommandArgument='<%# Eval("ProductID") %>' ><i class="fa-solid fa-minus"></i></asp:LinkButton>
                                        </td>
                                        <td>&euro;<asp:Label ID="lbl_productPrice" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div class="back-to-shop"><a href="#">&leftarrow;</a><span class="text-muted">Back to shop</span></div>
                </div>
                <div class="col-md-4 summary">
                    <div>
                        <h5><b>Summary</b></h5>
                    </div>
                    <hr>


                    <table class="table">
                        <tbody>
                            <tr>
                                <td>Total Items
                                    <asp:Label ID="lbl_totalItems" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td>&euro;
                                    <asp:Label ID="lbl_totalPriceNoShipping" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Shipping
                                </td>
                                <td>&euro; 2.99
                                </td>
                            </tr>
                            <tr>
                                <td>TOTAL PRICE
                                </td>
                                <td>&euro;<asp:Label ID="lbl_totalPriceFinish" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>

                        </tbody>
                    </table>



                    <asp:Button ID="btn_checkOut" runat="server" Text="Check Out" class="btn btn-dark"  />
                </div>
            </div>

        </div>
    </div>
</asp:Content>
