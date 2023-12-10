<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FOMaster.Master" AutoEventWireup="true" CodeBehind="ShopAccessoriesDetails.aspx.cs" Inherits="SpeedMaster.FO.ShopMotorcycleDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Start Content -->
    <div style="height: 72.5vh;" class="ps-5 pe-5 d-flex justify-content-center">
        <div class="ps-5 pe-5">
            <div class="ps-5 pe-5">
                <div class="container mt-5 mb-5 ps-5 pe-5">
                    <div class="row">
                        <div class="col-md-6 text-end pe-5">
                            <!-- Product Image -->
                            <asp:Image ID="ImagemProduto" CssClass="ImagemProduto" runat="server" ImageUrl="~/FO/img/logo.jpeg" Height="500px" Width="500px" />
                        </div>
                        <div class="col-md-6 ps-5">
                            <!-- Product Information -->
                            <div class="product-info" style="padding-left: 25%;">
                                <p>
                                    <asp:Label ID="lbl_marca" runat="server" Text="Marca do produto" class="lead"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lbl_nome" runat="server" Text="Nome do produto" class="lead"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lbl_preco" runat="server" Text="Preco do produto"></asp:Label>
                                </p>
                                <div class="pb-3">
                                <p>
                                    <asp:Label ID="lbl_productDescription" runat="server" Text="Desc do produto"></asp:Label>
                                </p>
                                    </div>


                                <!-- Product Quantity and Add to Cart Form -->
                                <div id="QuantityBox" class="form-group align-bottom">
                                    <div class="form-group align-bottom">
                                        <label for="quantity">Quantity:</label>
                                        <div class="input-group pb-3 pt-2">
                                            <div class="input-group-prepend">
                                                <asp:LinkButton ID="btn_minus" runat="server" class="btn btn-outline-secondary" OnClick="btn_minus_Click"><i class="fa-solid fa-minus"></i></asp:LinkButton>
                                            </div>
                                            <div class="" style="width: 45px">
                                                <asp:TextBox ID="tb_quantiity" runat="server" class="form-control quantity-input" Text="1"></asp:TextBox>
                                            </div>
                                            <div class="input-group-append">
                                                <asp:LinkButton ID="btn_plus" runat="server" class="btn btn-outline-secondary" OnClick="btn_plus_Click"><i class="fa-solid fa-plus"></i></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:Label ID="lbl_message" runat="server" Text="Stock unavailable for this amount!" ForeColor="Red" Visible="false"></asp:Label>
                                    <asp:LinkButton ID="btn_addToCart" runat="server" class="fa-solid fa-cart-shopping" CommandArgument='<%# Eval("ProductID") %>' OnClick="btn_addToCart_Click"> Add To Cart</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <style>
        .ImagemProduto {
            border-radius: 30px;
        }

        #QuantityBox{
            padding-top: 22vh;
            /*background-color:black;*/
        }
    </style>


</asp:Content>
