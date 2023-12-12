<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FOMaster.Master" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="SpeedMaster.FO.userProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" runat="server" href="/FO/css/shop.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Start Content -->
    <div style="height: 72.5vh;" class="ps-5 pe-5 pt-5 d-flex justify-content-center">
        <div class="ps-5 pe-5">
            <div class="ps-5 pe-5">
                <div class="container mt-5 mb-5 ps-5 pe-5">
                    <div class="row">
                        <div class="col-md-6 text-end pe-5">
                            <!-- Product Image -->
                                <asp:Image ID="ImagemProduto" CssClass="ImagemProduto" runat="server" ImageUrl="~\Images\user.jpg" Height="300px" Width="300px" />

                        </div>
                        <div class="col-md-6 ps-5">
                            <!-- Product Information -->
                            <div class="product-info" style="padding-left: 25%;">
                                <p>
                                    <asp:Label ID="lbl_primeironome" runat="server" Text="Name" class="lead"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lbl_Sobrenome" runat="server" Text="Surname" class="lead"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lbl_email" runat="server" Text="Email"></asp:Label>
                                </p>
                                <p>
                                    <asp:Label ID="lbl_Phone" runat="server" Text="Phone"></asp:Label>
                                </p>
                                <asp:Button ID="Change_Password" runat="server" Text="Change password" CssClass="filter-input" OnClick="Change_Password_Click" />
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
