<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ShopMotorcycle.aspx.cs" Inherits="SpeedMaster.FO.Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
        <ItemTemplate>
            <asp:Label ID="lbl_productName" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btn_viewDeatils" runat="server" Text="Button" CommandArgument='<%# Eval("ID_Motorcycle") %>' OnClick="btn_viewDeatils_Click" />
            <asp:Button ID="btn_addCart" runat="server" Text="Button" CommandArgument='<%# Eval("ID_Motorcycle") %>' OnClick="btn_addCart_Click"/>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <asp:Label ID="lbl_productName" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btn_viewDeatils" runat="server" Text="Button" CommandArgument='<%# Eval("ID_Motorcycle") %>' OnClick="btn_viewDeatils_Click" />
            <asp:Button ID="btn_addCart" runat="server" Text="Button" CommandArgument='<%# Eval("ID_Motorcycle") %>' OnClick="btn_addCart_Click"/>
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
  
</asp:Content>
