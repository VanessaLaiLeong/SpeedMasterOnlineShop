<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="InsertMotorcycle.aspx.cs" Inherits="SpeedMaster.BO.InsertMotorcycle" %>
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

    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btn_add" runat="server" Text="Button" OnClick="btn_add_Click" />


</asp:Content>
