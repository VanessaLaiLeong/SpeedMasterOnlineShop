<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FO_MasterPage.Master" AutoEventWireup="true" CodeBehind="ShopMotorcycle.aspx.cs" Inherits="SpeedMaster.FO.Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <img src="https://mdbcdn.b-cdn.net/img/new/standard/city/044.webp" class="card-img-top"
                    alt="Skyscrapers" />
                <div class="card-body">
                    <h5 class="card-title">Card title</h5>
                    <p class="card-text">
                        This is a wider card with supporting text below as a natural lead-in to
          additional content. This content is a little bit longer.
                    </p>
                </div>
                <div class="card-footer">
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


    <style>
        body {
            background-color: #eef3f4;
        }

        .height-100 {
            height: 100vh;
        }

        .card {
            width: 380px;
            border: none;
            height: 280px;
        }

        .ratings {
            margin-right: 10px;
        }

            .ratings i {
                color: #cecece;
                font-size: 32px;
            }

        .rating-color {
            color: #fbc634 !important;
        }

        .review-count {
            font-weight: 400;
            margin-bottom: 2px;
            font-size: 24px !important;
        }

        .small-ratings i {
            color: #cecece;
        }

        .review-stat {
            font-weight: 300;
            font-size: 18px;
            margin-bottom: 2px;
        }


    </style>

</asp:Content>
