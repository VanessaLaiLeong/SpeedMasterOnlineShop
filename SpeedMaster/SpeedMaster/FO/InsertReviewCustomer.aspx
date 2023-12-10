<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FOMaster.Master" AutoEventWireup="true" CodeBehind="InsertReviewCustomer.aspx.cs" Inherits="SpeedMaster.FO.InsertReviewCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:LinkButton ID="star1" runat="server" ForeColor="#FF9933" OnClick="star1_Click" CssClass="fa-regular fa-star no-decoration" CommandArgument="1" style="text-decoration: none;"></asp:LinkButton>
    <asp:LinkButton ID="star2" runat="server" ForeColor="#FF9933" OnClick="star2_Click" CssClass="fa-regular fa-star no-decoration" CommandArgument="2" style="text-decoration: none;"></asp:LinkButton>
    <asp:LinkButton ID="star3" runat="server" ForeColor="#FF9933" OnClick="star3_Click" CssClass="fa-regular fa-star no-decoration" CommandArgument="3" style="text-decoration: none;"></asp:LinkButton>
    <asp:LinkButton ID="star4" runat="server" ForeColor="#FF9933" OnClick="star4_Click" CssClass="fa-regular fa-star no-decoration" CommandArgument="4" style="text-decoration: none;"></asp:LinkButton>
    <asp:LinkButton ID="star5" runat="server" ForeColor="#FF9933" OnClick="star5_Click1" CssClass="fa-regular fa-star no-decoration" CommandArgument="5" style="text-decoration: none;"></asp:LinkButton>

    <asp:TextBox ID="tb_review" runat="server"></asp:TextBox>
    <asp:Button ID="btn_submit" runat="server" Text="Button" OnClick="btn_submit_Click" />



</asp:Content>
