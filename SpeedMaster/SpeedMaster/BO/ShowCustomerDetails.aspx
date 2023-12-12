<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="ShowCustomerDetails.aspx.cs" Inherits="SpeedMaster.BO.ShowCustomerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Accessory details</h2>
    <div class="form-group container">
        <label id="lbl_Email" runat="server">Email</label>
        <asp:TextBox ID="tb_Email" runat="server" class="form-control" placeholder="Email" />
        <br />

        <label id="lbl_FirstName" runat="server">First Name</label>
        <asp:TextBox ID="tb_FirstName" runat="server" class="form-control" placeholder="First Name" />
        <br />

        <label id="lbl_LastName" runat="server">Last Name</label>
        <asp:TextBox ID="tb_LastName" runat="server" class="form-control" placeholder="Last Name" />
        <br />

        <label id="lbl_Address" runat="server">Address</label>
        <asp:TextBox ID="tb_Address" runat="server" class="form-control" placeholder="Address" />
        <br />

        <label id="lbl_Phone" runat="server">Phone</label>
        <asp:TextBox ID="tb_Phone" runat="server" class="form-control" placeholder="Phone" />
        <br />

        <label id="lbl_Active" runat="server">Active</label>
        <asp:RadioButtonList ID="rd_active" runat="server">
            <asp:ListItem>yes</asp:ListItem>
            <asp:ListItem>no</asp:ListItem>
        </asp:RadioButtonList>
        <br />

        <label id="lbl_NIF" runat="server">NIF</label>
        <asp:TextBox ID="tb_NIF" runat="server" class="form-control" placeholder="NIF" />
        <br />

        <br />
        <br />
        <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="submit" class="btn btn-success" />
       
    </div>
   
</asp:Content>
