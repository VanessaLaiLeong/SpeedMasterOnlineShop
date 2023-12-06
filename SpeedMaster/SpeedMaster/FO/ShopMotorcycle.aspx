<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FO_MasterPage.Master" AutoEventWireup="true" CodeBehind="ShopMotorcycle.aspx.cs" Inherits="SpeedMaster.FO.Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <link rel="stylesheet" runat="server" href="/FO/css/shop.css" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
        <ItemTemplate>
            <asp:Label ID="lbl_productName" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btn_viewDeatils" runat="server" Text="Button" CommandArgument='<%# Eval("ID_Motorcycle") %>' OnClick="btn_viewDeatils_Click" />
            <asp:Button ID="btn_addCart" runat="server" Text="Button" CommandArgument='<%# Eval("ID_Motorcycle") %>' OnClick="btn_addCart_Click" />
        </ItemTemplate>
        <AlternatingItemTemplate>
            <asp:Label ID="lbl_productName" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btn_viewDeatils" runat="server" Text="Button" CommandArgument='<%# Eval("ID_Motorcycle") %>' OnClick="btn_viewDeatils_Click" />
            <asp:Button ID="btn_addCart" runat="server" Text="Button" CommandArgument='<%# Eval("ID_Motorcycle") %>' OnClick="btn_addCart_Click" />
        </AlternatingItemTemplate>
    </asp:Repeater>
    <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
        <ItemTemplate>
            <asp:LinkButton ID="btnPage"
                Style="padding: 8px; margin: 2px; background: #ffa100; border: solid 1px #666; font: 8pt tahoma;"
                CommandName="Page"
                CommandArgument='<%# Container.DataItem %>'
                runat="server" ForeColor="White" Font-Bold="True">
                        <%# Container.DataItem %>
            </asp:LinkButton>

        </ItemTemplate>
    </asp:Repeater>

    <br />
    <br />
    <br />

    <%--CARD PARA USAR NO FINAL--%>


    <div class="row row-cols-1 row-cols-md-3 g-4">
        <div class="col">
            <div class="card h-100">
                <div class="show-image">
                    <img src="https://mdbcdn.b-cdn.net/img/new/standard/city/044.webp" class="card-img-top hover-overlay" alt="Skyscrapers" />
                    <div class="d-grid gap-2 col-6 mx-auto">
                    <asp:LinkButton runat="server" CssClass="update" OnClientClick=""><i class="fa-solid fa-cart-shopping"></i></asp:LinkButton>
                        <%--<asp:LinkButton runat="server" CssClass="delete" OnClientClick="">Delete</asp:LinkButton>--%>
                    
                    </div>
                </div>
                <div class="card-body">
                    <a href="details.aspx" style="color: #000000; text-decoration: none; text-decoration: underline;"><h5 class="card-title text-center">Title</h5></a>
                    <h5 class="card-title text-center">Price €</h5>
                    <p class="card-text text-center">
                        This is a wider card with supporting text below as a natural lead-in to
          additional content. This content is a little bit longer.
                    </p>
                </div>
                <div class="card-footer text-center">
                    <div class="small-ratings">
                        <i class="fa fa-star rating-color"></i>
                        <i class="fa fa-star rating-color"></i>
                        <i class="fa fa-star rating-color"></i>
                        <i class="fa fa-star"></i>
                        <i class="fa fa-star"></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />



</asp:Content>
