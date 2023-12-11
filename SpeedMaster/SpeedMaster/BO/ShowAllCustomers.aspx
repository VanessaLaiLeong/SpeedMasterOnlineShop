<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="ShowAllCustomers.aspx.cs" Inherits="SpeedMaster.BO.ShowAllCustomers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row mb-4">
        <div class="col-md-3">
            <asp:DropDownList ID="ddl_productType" class="form-select" runat="server">
                <asp:ListItem>Select a Filter</asp:ListItem>
                <asp:ListItem>Name</asp:ListItem>
                <asp:ListItem>Filter_2</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-6 d-flex justify-content-start">
            <asp:Button ID="btn_createProduct" class="btn btn-success me-2" runat="server" Text="Create" />
            <asp:Button ID="btn_modifyProduct" class="btn btn-primary me-2" runat="server" Text="Modify" />
            <asp:Button ID="btn_deleteProduct" class="btn btn-danger me-2" runat="server" Text="Erase" />
        </div>
    </div>
    <div class="table-responsive">
                <table class="table table-bordered">
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" DataSourceID="SqlDataSource1">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_email" runat="server" Text="email"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_customerName" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_address" runat="server" Text="address"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_phone" runat="server" Text="phone"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_NIF" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <%--este butao o icon esta um pouco desalinhado da um pouco de ocd, ja tentei alinhar mas nao estou a conseguir--%>
                                        <asp:LinkButton ID="viewDetail" runat="server" class="btn btn-primary p-1 pb-2" Width="30px" Height="30px" CommandArgument='<%# Eval("ID_Customer") %>' OnClick="viewDetail_Click" ><i class="fa-solid fa-eye"></i></asp:LinkButton>
                                        <asp:LinkButton ID="delete" runat="server" class="btn btn-danger me-2" Width="30px" Height="30px" CommandArgument='<%# Eval("ID_Customer") %>' OnClick="delete_Click"  ><i class="fa-solid fa-trash"></i></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SpeedMasterConnectionString %>" SelectCommand="SELECT * FROM [Customers]"></asp:SqlDataSource>
                    </tbody>
                </table>
            </div>
</asp:Content>
