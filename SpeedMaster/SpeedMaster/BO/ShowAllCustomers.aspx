<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="ShowAllCustomers.aspx.cs" Inherits="SpeedMaster.BO.ShowAllCustomers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" DataSourceID="SqlDataSource1">
                            <ItemTemplate>

                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_customerName" runat="server" Text="Label"></asp:Label>
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
                                        <asp:LinkButton ID="viewDetail" runat="server" class="btn btn-primary p-1 pb-2" Width="30px" Height="30px" CommandArgument='<%# Eval("ID_Customer") %>' OnClick="viewDetail_Click" ><i class="fa-solid fa-eye"></i></asp:LinkButton>
                                        <asp:LinkButton ID="delete" runat="server" class="btn btn-warning p-1 pb-2" Width="30px" Height="30px" CommandArgument='<%# Eval("ID_Customer") %>' OnClick="delete_Click"  ><i class="fa-solid fa-trash"></i></asp:LinkButton>

                                    </td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_customerName" runat="server" Text="Label"></asp:Label>
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
                                        <asp:LinkButton ID="viewDetail" runat="server" class="btn btn-primary p-1 pb-2" Width="30px" Height="30px" CommandArgument='<%# Eval("ID_Customer") %>' OnClick="viewDetail_Click" ><i class="fa-solid fa-eye"></i></asp:LinkButton>
                                        <asp:LinkButton ID="delete" runat="server" class="btn btn-warning p-1 pb-2" Width="30px" Height="30px" CommandArgument='<%# Eval("ID_Customer") %>' OnClick="delete_Click"  ><i class="fa-solid fa-trash"></i></asp:LinkButton>

                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SpeedMasterConnectionString %>" SelectCommand="SELECT * FROM [Customers]"></asp:SqlDataSource>
                    </tbody>

                </table>
            </div>
</asp:Content>
