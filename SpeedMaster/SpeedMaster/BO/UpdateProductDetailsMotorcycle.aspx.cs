﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class UpdateProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID_Motorcycle"] = Convert.ToInt32(Request.QueryString["productId"]);
            //Session["ID_Brand"] = ;
            //Session["Model"] = "Novo modelo12";
            //Response.Write(Convert.ToString(Request.QueryString["productId"]));
            //Response.Write(Session["ID_Motorcycle"]);
            //Response.Write(Session["ManufactoringYear"]);
            //Session["ManufactoringYear"] = ;
            //Session["EngineType"] = ;
            //Session["EngineCapacity"] = ;
            //Session["Color"] = "blue" ;
            //Session["Price"] = ;
            //Session["Condition"] = ;
            //Session["Description"] = ;
            //Session["MotorcycleImage"] = ;
            //Session["MotorcycleImageType"] = ;
            //Session["Active"] =;



        }

        
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    byte[] img = Services.getImageInfo(FileUpload1);  

        //    if (Convert.ToString(Session["productType"]) == "Motorcycle")
        //    {
        //        int ID_Motorcycle = 16;
        //        int ID_Brand = 1;
        //        string Model = "SampleModel2";
        //        int ManufactoringYear = 2022;
        //        string EngineType = "V-Twin";
        //        int EngineCapacity = 1500;
        //        string Color = "amarelo";
        //        decimal Price = 20000.00m;
        //        string Condition = "New";
        //        string Description = "Powerful motorcycle with great features";
        //        byte[] MotorcycleImage = img; // Sample image bytes
        //        string MotorcycleImageType = "jpg";
        //        bool Active = true;

        //        // Call the UpdateMotorcycleInDB method with the sample data
        //        Connections.UpdateMotorcycleInDB(
        //            ID_Motorcycle, ID_Brand, Model, ManufactoringYear, EngineType,
        //            EngineCapacity, Color, Price, Condition, Description,
        //            MotorcycleImage, MotorcycleImageType, Active);
        //        Response.Write("sucess!");
        //    }
        //}

     

        protected void bnt_update_Click(object sender, EventArgs e)
        {
            byte[] img = Services.getImageInfo(fu_moto);

            int ID_Motorcycle = Convert.ToInt32(Request.QueryString["motor_id"]);
            int ID_Brand = dp_brand.SelectedIndex;
            string Model = tb_model.Text;
            int ManufactoringYear = Convert.ToInt32(tb_manuDate.Text);
            string EngineType = tb_engType.Text;
            int EngineCapacity = Convert.ToInt32(tb_engCap.Text);
            string Color = tb_color.Text;
            decimal Price = Convert.ToDecimal(tb_price.Text);
            string Condition = tb_condition.Text;
            string Description = tb_description.Text;
            byte[] MotorcycleImage = img; // Sample image bytes
            string MotorcycleImageType = "jpg";
            bool Active = true;

            // Call the UpdateMotorcycleInDB method with the sample data
            Response.Write(Connections.UpdateMotorcycleInDB(
                ID_Motorcycle, ID_Brand, Model, ManufactoringYear, EngineType,
                EngineCapacity, Color, Price, Condition, Description,
                MotorcycleImage, MotorcycleImageType, Active));
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {

        }
    }

    
}
