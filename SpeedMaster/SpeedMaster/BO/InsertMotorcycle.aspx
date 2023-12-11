<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="InsertMotorcycle.aspx.cs" Inherits="SpeedMaster.BO.InsertMotorcycle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="form-group pb-2">
            <asp:Label ID="lbl_Brand" runat="server">Motorcycle Brand</asp:Label>
            <asp:TextBox ID="tb_brand" runat="server" class="form-control" placeholder="ex. Kawasaki"/>
        </div>
        <div class="form-group pb-2">
            <asp:label ID="lbl_model" runat="server">Motorcycle Model</asp:label>
            <asp:TextBox ID="tb_model" runat="server" class="form-control" placeholder="ex. Ninja H2" />
        </div>
        <div class="form-group pb-2">
            <asp:Label ID="lbl_year" runat="server">Motorcycle Year</asp:Label>
            <asp:TextBox ID="tb_year" runat="server" class="form-control" placeholder="ex. 2023"/>
        </div>
        <div class="form-group pb-2">
            <asp:Label ID="lbl_Engine" runat="server">Motorcycle Engine</asp:Label>
            <asp:TextBox ID="tb_engine" runat="server" class="form-control" placeholder="ex. V-Twin"/>
        </div>
        <div class="form-group pb-2">
            <asp:Label runat="server">Engine Capacity</asp:Label>
            <asp:TextBox ID="tb_engine_capacity" runat="server" class="form-control" placeholder="ex. V-Twin"/>
        </div>
        <div class="form-group pb-2">
            <asp:Label ID="lbl_CC" runat="server">Motorcycle CC</asp:Label>
            <asp:TextBox ID="tb_CC" runat="server" class="form-control" placeholder="ex. 1500"/>
        </div>
        <div class="form-group pb-2">
            <asp:Label ID="lbl_Color" runat="server">Motorcycle Color</asp:Label>
            <asp:TextBox ID="tb_color" runat="server" class="form-control" placeholder="ex. Green"/>
        </div>
        <div class="form-group pb-2">
            <asp:Label ID="lbl_Price" runat="server">Motorcycle Price</asp:Label>
            <asp:TextBox ID="tb_price" runat="server" class="form-control" placeholder="ex. 20,000"/>
        </div>
        <div class="form-group pb-2">
            <asp:Label ID="lbl_Condition" runat="server">Motorcycle Condition</asp:Label>
            <asp:TextBox ID="tb_condition" runat="server" class="form-control" placeholder="ex. New"/>
        </div>
        <div class="form-group pb-2">
            <asp:Label ID="lbl_Description" runat="server">Motorcycle Description</asp:Label>
            <asp:TextBox ID="tb_description" runat="server" class="form-control" placeholder="ex. Taking the exclusive Ninja H2 ownership experience to a new level..."/>
        </div>

        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button runat="server" ID="btn_submit" type="submit" Text="Submit" OnClick="btn_add_Click" class="btn btn-success mt-3" />
    </div>


    <br />




</asp:Content>
