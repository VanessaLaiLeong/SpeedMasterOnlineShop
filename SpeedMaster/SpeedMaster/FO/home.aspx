<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FOMaster.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="SpeedMaster.FO.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="ps-5 pe-5" style="height: 72.5vh;">
        <div class="ps-5 pe-5">
            <div class="ps-5 pe-5">
                <div id="template-mo-zay-hero-carousel" class="carousel slide" data-bs-ride="carousel">


                    <div class="carousel-inner" style="border-radius: 30px;">

                        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                            <div class="carousel-indicators">
                                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
                            </div>
                            <div class="carousel-inner">
                                <div class="carousel-item active">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/banner-1.jpg" class="d-block w-100" />
                                </div>
                                <div class="carousel-item">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/banner-2.jpg" class="d-block w-100" />
                                </div>
                                <div class="carousel-item">
                                    <asp:Image ID="Image6" runat="server" class="d-block w-100" ImageUrl="~/images/banner-3.jpg" />
                                </div>
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>
                    </div>

                </div>
                <section class="bg-light">
                    <div class="container py-5">
                        <div class="row text-center py-3">
                            <div class="col-lg-6 m-auto">
                                <h1 class="h1">Welcome to SpeedMaster</h1>
                                <p>
                                    Enjoy your stay!
                                </p>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-12 col-md-4 mb-4">
                                <div class="card" style="width: 18rem;">
                                    <asp:Image ID="Image3" runat="server" class="card-img-top" ImageUrl="~/img/logo.jpg" />
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_productName" runat="server" Text="Label" class="card-title"></asp:Label>

                                            </div>
                                            <div class="col text-right">
                                                €
                                                <asp:Label ID="lbl_productPrice" runat="server" Text="Label" class="card-title"></asp:Label>
                                            </div>
                                        </div>


                                        <p class="card-text">
                                            <asp:Label ID="lbl_productDescription" runat="server" Text="Label"></asp:Label>
                                        </p>
                                        <asp:Button ID="Button1" runat="server" Text="Check" class="btn btn-success" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-md-4 mb-4">
                                <div class="card" style="width: 18rem;">
                                    <asp:Image ID="Image4" runat="server" class="card-img-top" ImageUrl="~/FO/img/logo.jpeg" />
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_productName2" runat="server" Text="Label" class="card-title"></asp:Label>

                                            </div>
                                            <div class="col text-right">
                                                €
                                                <asp:Label ID="lbl_productPrice2" runat="server" Text="Label" class="card-title"></asp:Label>
                                            </div>
                                        </div>


                                        <p class="card-text">
                                            <asp:Label ID="lbl_productDescription2" runat="server" Text="Label"></asp:Label>
                                        </p>
                                        <asp:Button ID="Button2" runat="server" Text="Check" class="btn btn-success" OnClick="Button2_Click"/>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-md-4 mb-4">
                                <div class="card rounded-0 h-100" style="width: 18rem;">
                                    <asp:Image ID="Image5" runat="server" class="card-img-top" ImageUrl="~/FO/img/logo.jpeg" />
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="lbl_productName3" runat="server" Text="Label" class="card-title"></asp:Label>

                                            </div>
                                            <div class="col text-right">
                                                €
                                                <asp:Label ID="lbl_productPrice3" runat="server" Text="Label" class="card-title"></asp:Label>
                                            </div>
                                        </div>


                                        <p class="card-text">
                                            <asp:Label ID="lbl_productDescription3" runat="server" Text="Label"></asp:Label>
                                        </p>
                                        <asp:Button ID="Button3" runat="server" Text="Check" class="btn btn-success" OnClick="Button3_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <!-- End Featured Product -->
            </div>
        </div>
    </div>


</asp:Content>
