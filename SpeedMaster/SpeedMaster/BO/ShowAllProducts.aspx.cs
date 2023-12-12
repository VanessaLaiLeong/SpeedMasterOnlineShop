using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;

namespace SpeedMaster.BO
{
    public partial class ShowAllProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                div_motor.Visible = true;
                div_access.Visible = false;
            }
        }

        protected void rp_motocycles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            ((Label)e.Item.FindControl("lbl_motorId")).Text = dr["ID_Motorcycle"].ToString();
            ((Label)e.Item.FindControl("lbl_brand")).Text = dr["BrandName"].ToString();
            ((Label)e.Item.FindControl("lbl_model")).Text = dr["Model"].ToString();
            ((Label)e.Item.FindControl("lbl_manYear")).Text = dr["ManufactoringYear"].ToString();
            ((Label)e.Item.FindControl("lbl_engType")).Text = dr["EngineType"].ToString();
            ((Label)e.Item.FindControl("lbl_engCap")).Text = dr["EngineCapacity"].ToString();
            ((Label)e.Item.FindControl("lbl_color")).Text = dr["Color"].ToString();
            ((Label)e.Item.FindControl("lbl_price")).Text = dr["Price"].ToString();
            ((Label)e.Item.FindControl("lbl_condition")).Text = dr["Condition"].ToString();

        }

        protected void rp_accessories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            ((Label)e.Item.FindControl("lbl_accessId")).Text = dr["ID_Accessory"].ToString();
            ((Label)e.Item.FindControl("lbl_accessName")).Text = dr["AccessoryName"].ToString();
            ((Label)e.Item.FindControl("lbl_accessPrice")).Text = dr["Price"].ToString();
            ((Label)e.Item.FindControl("lbl_accessStock")).Text = dr["Stock"].ToString();
        }

        protected void btn_motorDetails_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string motor_id = button.CommandArgument.ToString();
            Response.Redirect($"UpdateProductDetailsMotorcycle.aspx?motor_id={motor_id}");
        }

        protected void btn_accessDetails_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string access_id = button.CommandArgument.ToString();
            Response.Redirect($"UpdateProductDetailsAccessory.aspx?access_id={access_id}");
        }

        protected void ddl_productType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            if (ddl.SelectedIndex == 0)
            {
                return;
            }
            else if (ddl.SelectedIndex == 1)
            {
                div_access.Visible = false;
                div_motor.Visible = true;
            }
            else if(ddl.SelectedIndex == 2)
            {
                div_access.Visible = true;
                div_motor.Visible = false;
            }
        }

       

        protected void btn_insert_motorcycles_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertProducts.aspx");
        }
    }
}