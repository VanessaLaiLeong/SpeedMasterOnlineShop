<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FOMaster.Master" AutoEventWireup="true" CodeBehind="ShopMotorcycleDetails.aspx.cs" Inherits="SpeedMaster.FO.ShopMotorcycleDetails1" %>
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
                                    <asp:Label ID="lbl_modelo" runat="server" Text="Modelo do produto" class="lead"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lbl_ano" runat="server" Text="Ano do produto"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lbl_TipoMotor" runat="server" Text="tipo de motor do produto"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lbl_Capacity" runat="server" Text="cc do motor do produto"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lbl_cor" runat="server" Text="cor do produto"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lbl_condicao" runat="server" Text="condicao do produto"></asp:Label>
                                </p>
                                <div class="pb-3">
                                    <p>
                                        <asp:Label ID="lbl_productDescription" runat="server" Text="Desc do produto"></asp:Label>
                                    </p>
                                    <p>
                                        <asp:Label ID="lbl_preco" runat="server" Text="preco do produto"></asp:Label>
                                    </p>
                                </div>


                                <!-- Product Quantity and Add to Cart Form -->
                                <div>
                                    <div class="form-group">
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
                                    <asp:LinkButton ID="btn_addToCart" runat="server" class="fa-solid fa-cart-shopping pt-1" CommandArgument='<%# Eval("ProductID") %>' OnClick="btn_addToCart_Click"> Add To Cart</asp:LinkButton>

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
    </style>
</asp:Content>
