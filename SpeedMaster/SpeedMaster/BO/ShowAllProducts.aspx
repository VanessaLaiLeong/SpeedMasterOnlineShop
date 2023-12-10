<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="ShowAllProducts.aspx.cs" Inherits="SpeedMaster.BO.ShowAllProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    helo

    <asp:DropDownList ID="ddl_productType" runat="server" AutoPostBack="True">
        <asp:ListItem>Motorcycle</asp:ListItem>
        <asp:ListItem>Accessories</asp:ListItem>
    </asp:DropDownList>

    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="table-responsive">
                <table class="table table-bordered">
                    <thead class="thead-light">
                        <tr>
                            <th>Items
                       <%-- <button class="sort-button">...</button></th>--%>
                            <th>Category
                        <%-- <button class="sort-button">...</button></th>--%>
                            <th>Status
                        <%-- <button class="sort-button">...</button></th>--%>

                            <th>Sales
                         <%-- <button class="sort-button">...</button></th>--%>
                            <th>Quantity
                        <%-- <button class="sort-button">...</button></th>--%>
                            <th>Price
                         <%-- <button class="sort-button">...</button></th>--%>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>

                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_productName" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_status" runat="server" Text="Label" class="badge badge-success"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_quantity" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_price" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <%--este butao o icon esta um pouco desalinhado da um pouco de ocd, ja tentei alinhar mas nao estou a conseguir--%>
                                        <asp:LinkButton ID="viewDetail" runat="server" class="btn btn-primary p-1 pb-2" Width="30px" Height="30px" CommandArgument='<%# Eval("ID_Motorcycle") %>' OnClick="viewDetail_Click"><i class="fa-solid fa-eye"></i></asp:LinkButton>
                                        <asp:LinkButton ID="delete" runat="server" class="btn btn-warning p-1 pb-2" Width="30px" Height="30px" CommandArgument='<%# Eval("ID_Motorcycle") %>' OnClick="delete_Click"><i class="fa-solid fa-trash"></i></asp:LinkButton>

                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_productName" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_status" runat="server" Text="Label" class="badge badge-success"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_quantity" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_price" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <%--este butao o icon esta um pouco desalinhado da um pouco de ocd, ja tentei alinhar mas nao estou a conseguir--%>
                                        <asp:LinkButton ID="viewDetail" runat="server" class="btn btn-primary p-1 pb-2" Width="30px" Height="30px" CommandArgument='<%# Eval("ID_Motorcycle") %>' OnClick="viewDetail_Click"><i class="fa-solid fa-eye"></i></asp:LinkButton>
                                        <asp:LinkButton ID="delete" runat="server" class="btn btn-warning p-1 pb-2" Width="30px" Height="30px" CommandArgument='<%# Eval("ID_Motorcycle") %>' OnClick="delete_Click"><i class="fa-solid fa-trash"></i></asp:LinkButton>

                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </tbody>

                </table>
            </div>
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


        </asp:View>
        <asp:View ID="View2" runat="server">
            <div class="table-responsive">
                <table class="table table-bordered">
                    <thead class="thead-light">
                        <tr>
                            <th>Items
                       <%-- <button class="sort-button">...</button></th>--%>
                            <th>Category
                        <%-- <button class="sort-button">...</button></th>--%>
                            <th>Status
                        <%-- <button class="sort-button">...</button></th>--%>

                            <th>Sales
                         <%-- <button class="sort-button">...</button></th>--%>
                            <th>Quantity
                        <%-- <button class="sort-button">...</button></th>--%>
                            <th>Price
                         <%-- <button class="sort-button">...</button></th>--%>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>




                        <asp:Repeater ID="Repeater3" runat="server" OnItemDataBound="Repeater3_ItemDataBound">
                            <ItemTemplate>

                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_productName" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_status" runat="server" Text="Label" class="badge badge-success"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_quantity" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_price" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <%--este butao o icon esta um pouco desalinhado da um pouco de ocd, ja tentei alinhar mas nao estou a conseguir--%>
                                          <asp:LinkButton ID="accessoryDeatils" runat="server" class="btn btn-primary p-1 me-2" Width="30px" Height="30px" CommandArgument='<%# Eval("ID_Accessory") %>' OnClick="accessoryDeatils_Click"><i class="fa-solid fa-eye"></i></asp:LinkButton>
                                       <asp:LinkButton ID="acessoryDelete" runat="server" class="btn btn-warning p-1 pb-2" Width="30px" Height="30px" CommandArgument='<%# Eval("ID_Accessory") %>' OnClick="acessoryDelete_Click"><i class="fa-solid fa-trash"></i></asp:LinkButton>

                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_productName" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_status" runat="server" Text="Label" class="badge badge-success"></asp:Label>
                                    </td>

                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_quantity" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_price" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="accessoryDeatils" runat="server" class="btn btn-primary p-1 me-2" Width="30px" Height="30px" CommandArgument='<%# Eval("ID_Accessory") %>' OnClick="accessoryDeatils_Click"><i class="fa-solid fa-eye"></i></asp:LinkButton>
                                        <%--<asp:ImageButton ID="btn_viewDetail" runat="server" class="btn btn-primary p-1 me-2" ImageUrl="~/BO/img/eye-solid.svg"
                        Width="30px" Height="30px" CommandArgument='<%# Eval("ProductID") %>' OnClick="btn_viewDetail_Click" />
                    <asp:ImageButton ID="btn_delete" runat="server" ImageUrl="~/BO/img/trash-can-solid.svg" class="btn btn-danger p-1"
                        Width="30px" Height="30px" OnClick="btn_delete_Click" />--%>

                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </tbody>

                </table>
            </div>
            <asp:Repeater ID="Repeater4" runat="server" OnItemCommand="Repeater4_ItemCommand">
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


        </asp:View>
    </asp:MultiView>

</asp:Content>
