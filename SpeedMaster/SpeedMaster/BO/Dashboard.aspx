﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BO/BOMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SpeedMaster.BO.Dashboard" %>

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
                        <h1><asp:Label ID="lbl_quantSales" runat="server"></asp:Label></h1>
                        <!-- Valor Exemplo -->
                    </div>
                </div>
            </div>
            <div class="col-xl-6 col-md-6">
                <h4>Sales Total in Euros</h4>
                <div class="card bg-success text-white mb-4">
                    <div class="card-body">
                        <h1><asp:Label ID="lbl_moneySales" runat="server"></asp:Label></h1>
                        <!-- Valor Exemplo -->
                    </div>
                </div>
            </div>
        </div>

        <!-- Gráfico de Motas Vendidas por Marca -->
        <div class="card mb-4">
            <div class="card-header">
                <i class="fas fa-chart-bar me-1"></i>
                Motorcycles sold by brand
            </div>
            <div class="card-body">
                <canvas id="myAreaChart" width="100%" height="40"></canvas>
            </div>
        </div>
    </div>
</asp:Content>