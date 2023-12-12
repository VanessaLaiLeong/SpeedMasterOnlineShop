<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FOMaster.Master" AutoEventWireup="true" CodeBehind="ShopAccessories.aspx.cs" Inherits="SpeedMaster.FO.ShopAccessories1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <link rel="stylesheet" runat="server" href="/FO/css/shop.css" />


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- Filter --%>

    <div class="filter-container">

        <asp:LinkButton ID="btn_removeFilter" runat="server" OnClick="btn_removeFilter_Click" CssClass="filter-input">Remove Filters</asp:LinkButton>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="CategoryName" DataValueField="ID_Category" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="filter-dropdown"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SpeedMasterConnectionString %>" SelectCommand="SELECT * FROM [Categories]"></asp:SqlDataSource>

        <asp:TextBox ID="minPrice" runat="server" CssClass="filter-input" placeholder="Min Price"></asp:TextBox>
        <asp:TextBox ID="maxPrice" runat="server" CssClass="filter-input" placeholder="Max Price"></asp:TextBox>
        <asp:Button ID="btn_filterPrice" runat="server" Text="Go" OnClick="btn_removeFilter_Click" CssClass="filter-input" />
    </div>


    <div id="GridCardShop" class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">
                        <div class="show-image">
                            <asp:ImageButton ID="Image" runat="server" class="card-img-top hover-overlay" ImageUrl="~/Images/logoSpeedMaster.png" />
                            <div class="d-grid gap-2 col-6 mx-auto">
                                <asp:LinkButton ID="addShoppingCart" runat="server" CssClass="update" CommandArgument='<%# Eval("ID_Accessory") %>' OnClick="addShoppingCart_Click"><i class="fa-solid fa-cart-shopping"></i></asp:LinkButton>

                                <%--<asp:LinkButton runat="server" CssClass="delete" OnClientClick="">Delete</asp:LinkButton>--%>
                            </div>
                        </div>
                        <div class="card-body">
                            <a href="details.aspx" style="color: #000000; text-decoration: none; text-decoration: underline;">
                                <h5 class="card-title text-center">
                                    <asp:LinkButton ID="lk_accessoryName" runat="server" CommandArgument='<%# Eval("ID_Accessory") %>' OnClick="lk_accessoryName_Click"></asp:LinkButton>
                                </h5>
                            </a>
                            <h5 class="card-title text-center">
                                <asp:Label ID="lbl_price" runat="server" Text="Label"></asp:Label>€</h5>
                            <p class="card-text text-center">
                                <asp:Label ID="lbl_description" runat="server" Text="Label"></asp:Label>
                            </p>
                            <p class="card-text text-center">
                                <asp:Label ID="lbl_stock" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
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
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="col">
                    <div class="card h-100">
                        <div class="show-image">
                            <asp:ImageButton ID="Image" runat="server" class="card-img-top hover-overlay" ImageUrl="~/Images/logoSpeedMaster.png" />
                            <div class="d-grid gap-2 col-6 mx-auto">
                                <asp:LinkButton ID="addShoppingCart" runat="server" CssClass="update" CommandArgument='<%# Eval("ID_Accessory") %>' OnClick="addShoppingCart_Click"><i class="fa-solid fa-cart-shopping"></i></asp:LinkButton>

                                <%--<asp:LinkButton runat="server" CssClass="delete" OnClientClick="">Delete</asp:LinkButton>--%>
                            </div>
                        </div>
                        <div class="card-body">
                            <a href="details.aspx" style="color: #000000; text-decoration: none; text-decoration: underline;">
                                <h5 class="card-title text-center">
                                    <asp:LinkButton ID="lk_accessoryName" runat="server" CommandArgument='<%# Eval("ID_Accessory") %>' OnClick="lk_accessoryName_Click"></asp:LinkButton>
                                </h5>
                            </a>
                            <h5 class="card-title text-center">
                                <asp:Label ID="lbl_price" runat="server" Text="Label"></asp:Label>€</h5>
                            <p class="card-text text-center">
                                <asp:Label ID="lbl_description" runat="server" Text="Label"></asp:Label>
                            </p>
                            <p class="card-text text-center">
                                <asp:Label ID="lbl_stock" runat="server" Text=""></asp:Label>
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
            </AlternatingItemTemplate>
        </asp:Repeater>
    </div>
    <div class="container mb-5">
        <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton ID="btnPage"
                    Style="padding: 8px; margin: 2px; background: #ffa100; border: solid 1px #666; font: 8pt tahoma; padding-inline: 10px;"
                    CommandName="Page"
                    CommandArgument='<%# Container.DataItem %>'
                    runat="server" ForeColor="White" Font-Bold="True">
                        <%# Container.DataItem %>
        </asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
