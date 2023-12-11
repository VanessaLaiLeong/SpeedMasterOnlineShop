using System;
using System.Collections.Generic;
using System.Data;
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
            if (!IsPostBack)
            {
                Session["ID_Motorcycle"] = Convert.ToInt32(Request.QueryString["motor_id"]);
                int motor_id = Convert.ToInt32(Request.QueryString["motor_id"].ToString());

                DataTable dt = Connections.GetDataTableFromQuery($"select * from Motorcycles where ID_Motorcycle = {motor_id}");
                tb_color.Text = dt.Rows[0]["Color"].ToString();
                tb_model.Text = dt.Rows[0]["Model"].ToString();
                tb_engCap.Text = dt.Rows[0]["EngineCapacity"].ToString();
                tb_engType.Text = dt.Rows[0]["EngineType"].ToString();
                tb_manuDate.Text = dt.Rows[0]["ManufactoringYear"].ToString();
                tb_description.Text = dt.Rows[0]["Description"].ToString();
                tb_condition.Text = dt.Rows[0]["Condition"].ToString();
                tb_price.Text = dt.Rows[0]["Price"].ToString();
                ddl_Brand.SelectedValue = dt.Rows[0]["ID_Brand"].ToString();
            }
            
        }

        protected void bnt_update_Click(object sender, EventArgs e)
        {
            byte[] img = Services.getImageInfo(fu_moto);

            int ID_Motorcycle = Convert.ToInt32(Request.QueryString["motor_id"]);
            int ID_Brand = Convert.ToInt32(ddl_Brand.SelectedValue);
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
            Connections.DeleteMotorcycleAndGlobalProductsIDsFromDB(Convert.ToInt32(Request.QueryString["motor_id"]));
            Response.Redirect("ShowAllProducts.aspx");
        }
    }

    
}
