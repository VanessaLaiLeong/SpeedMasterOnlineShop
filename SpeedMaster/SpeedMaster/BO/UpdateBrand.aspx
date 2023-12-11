<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="UpdateBrand.aspx.cs" Inherits="SpeedMaster.BO.UpdateBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div>
        <div class="form-group pb-2">
            <label for="lbl_name">Brand Name</label>
            <asp:TextBox runat="server" class="form-control" ID="tb_brand_name" placeholder="ex. Honda Gloves" />
        </div>
        <div class="form-group pb-2">
            <label for="lbl_Description">Brand Origin</label>
            <asp:TextBox runat="server" class="form-control" ID="tb_brand_origin" placeholder="ex. Female and male biker gloves in leather or textile with protections for greater safety. Available in various colors and..." />
        </div>
        <div class="form-group pb-2">
            <label for="lbl_Price">Acessory Price</label>
            <asp:TextBox runat="server" type="text" class="form-control" ID="Price" placeholder="ex. 200" />
        </div>
        <br />
        <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" class="btn btn-success" Text="Update values" />
        <asp:Button ID="btn_delete" runat="server" OnClick="btn_delete_Click" class="btn btn-danger" Text="Remove Brand" />
    </div>
</asp:Content>
