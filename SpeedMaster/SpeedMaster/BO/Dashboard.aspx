<%@ Page Title="" Language="C#" MasterPageFile="~/BO/BOMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SpeedMaster.BO.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid px-4">
        <h1 class="mt-4">Dashboard</h1>

        <!-- Títulos e Caixas de Informações -->
        <div class="row">
            <div class="col-xl-6 col-md-6">
                <h4>Quantity of Sales</h4>
                <div class="card bg-primary text-white mb-4">
                    <div class="card-body">
                        <h1>
                            <asp:Label ID="lbl_quantSales" runat="server"></asp:Label></h1>
                        <!-- Valor Exemplo -->
                    </div>
                </div>
            </div>
            <div class="col-xl-6 col-md-6">
                <h4>Sales Total in Euros</h4>
                <div class="card bg-success text-white mb-4">
                    <div class="card-body">
                        <h1>
                            <asp:Label ID="lbl_moneySales" runat="server"></asp:Label></h1>
                        <!-- Valor Exemplo -->
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xl-6 col-md-6">
                <h4>Number of Bikes sold</h4>
                <div class="card bg-primary text-white mb-4">
                    <div class="card-body">
                        <h1>
                            <asp:Label ID="lbl_bikesSold" runat="server"></asp:Label></h1>
                        <!-- Valor Exemplo -->
                    </div>
                </div>
            </div>
            <div class="col-xl-6 col-md-6">
                <h4>Number of accessories</h4>
                <div class="card bg-success text-white mb-4">
                    <div class="card-body">
                        <h1>
                            <asp:Label ID="lbl_accessNumber" runat="server"></asp:Label></h1>
                        <!-- Valor Exemplo -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</asp:Content>
