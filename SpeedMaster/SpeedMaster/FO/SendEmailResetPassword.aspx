<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FOMaster.Master" AutoEventWireup="true" CodeBehind="SendEmailResetPassword.aspx.cs" Inherits="SpeedMaster.FO.SendEmailResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="filter-container d-flex align-items-center justify-content-center" style="height: 72.5vh;">
    <div>
        <asp:TextBox ID="tb_email" runat="server" PlaceHolder="Email" CssClass="filter-input"></asp:TextBox>
        <asp:Button ID="btn_sendEmail" runat="server" CssClass="filter-input" Text="Send" OnClick="btn_sendEmail_Click" />
    <div class="pt-5 mensagem">
        <asp:Label ID="lbl_Mensagem" runat="server" Text="Email sent!" ForeColor="#027148"></asp:Label>
    </div>
    </div>
    </div>




    <style>
        .filter-input {
            margin-left: 10px;
            padding: 10px;
            background-color: #f1f1f1;
            border: 1px solid #ddd;
            border-radius: 30px;
            text-align: center;
        }
        .mensagem {
            text-align: center;
        }


    </style>

</asp:Content>
