<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="InsertAccessory.aspx.cs" Inherits="SpeedMaster.BO.InsertAccessory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <div class="form-group pb-2">
            <label for="lbl_name">Acessory Name</label>
            <asp:TextBox runat="server" class="form-control" id="Name" placeholder="ex. Honda Gloves"/>
        </div>
        <div class="form-group pb-2">
            <label for="lbl_Description">Acessory Description</label>
            <asp:TextBox runat="server" class="form-control" id="Description" placeholder="ex. Female and male biker gloves in leather or textile with protections for greater safety. Available in various colors and..."/>
        </div>        
        <div class="form-group pb-2">
            <label for="lbl_Price">Acessory Price</label>
            <asp:TextBox runat="server" class="form-control" id="Price" placeholder="ex. 200"/>
        </div>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btn_add" runat="server" class="btn btn-primary" Text="Upload" OnClick="btn_add_Click" />
        <br />
        <asp:Button runat="server" ID="btn_submit" type="submit" Text="Submit" class="btn btn-success mt-3"> </asp:Button>
    </div>
    <asp:View ID="View1" runat="server"></asp:View>
</asp:Content>
