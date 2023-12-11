﻿<%@ Page Title="" Language="C#" MasterPageFile="BOMaster.Master" AutoEventWireup="true" CodeBehind="InsertMotorcycle.aspx.cs" Inherits="SpeedMaster.BO.InsertMotorcycle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--string result = Connections.InsertMotorcycleIntoDB(
                ID_Motorcycle: id,
                ID_Brand: 1,
                Model: "ModelX",
                ManufactoringYear: 2023,
                EngineType: "V-Twin",
                EngineCapacity: 1500,
                ColorBike: "Red",
                Price: 20000.00,
                Condition: "New",
                Description: "Powerful motorcycle with great features",
                MotorcycleImage: new byte[0x0],
                MotorcycleImageType: "JPEG",
                Active: 1

            );--%>

    <div>
        <div class="form-group pb-2">
            <label for="lbl_Brand">Motorcycle Brand</label>
            <input type="text" class="form-control" id="MotorcycleBrand" placeholder="ex. Kawasaki">
        </div>
        <div class="form-group pb-2">
            <label for="lbl_Brand">Motorcycle Model</label>
            <input type="text" class="form-control" id="Motorcycle" placeholder="ex. Ninja H2">
        </div>
        <div class="form-group pb-2">
            <label for="lbl_Model">Motorcycle Year</label>
            <input type="text" class="form-control" id="year" placeholder="ex. 2023">
        </div>
        <div class="form-group pb-2">
            <label for="lbl_Engine">Motorcycle Engine</label>
            <input type="text" class="form-control" id="engine" placeholder="ex. V-Twin">
        </div>
        <div class="form-group pb-2">
            <label for="lbl_CC">Motorcycle CC</label>
            <input type="text" class="form-control" id="cc" placeholder="ex. 1500">
        </div>
        <div class="form-group pb-2">
            <label for="lbl_Color">Motorcycle Color</label>
            <input type="text" class="form-control" id="color" placeholder="ex. Green">
        </div>
        <div class="form-group pb-2">
            <label for="lbl_Price">Motorcycle Price</label>
            <input type="text" class="form-control" id="price" placeholder="ex. 20,000">
        </div>
        <div class="form-group pb-2">
            <label for="lbl_Condition">Motorcycle Condition</label>
            <input type="text" class="form-control" id="condition" placeholder="ex. New">
        </div>
        <div class="form-group pb-2">
            <label for="lbl_Description">Motorcycle Description</label>
            <input type="text" class="form-control" id="Description" placeholder="ex. Taking the exclusive Ninja H2 ownership experience to a new level...">
        </div>

        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btn_add" runat="server" class="btn btn-primary" Text="Upload" OnClick="btn_add_Click" />
        <br />
        <button type="submit" class="btn btn-primary mt-3">Submit</button>
    </div>


    <br />




</asp:Content>
