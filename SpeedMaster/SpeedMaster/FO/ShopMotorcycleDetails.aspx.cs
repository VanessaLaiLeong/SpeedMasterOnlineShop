using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class ShopMotorcycleDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable productDetails = Connections.GetProductDetails(Convert.ToInt32(Request.QueryString["productId"]));
            //PrintProductDetails(productDetails);
            //Response.Write(Session["Model"]);
        }
        private void PrintProductDetails(DataTable productDetails)
        {
            foreach (DataRow row in productDetails.Rows)
            {

                Session["ID_Motorcycle"] = row["ID_Motorcycle"];
                Session["ID_Brand"] = row["ID_Brand"];
                Session["Model"] = row["Model"];
                Session["ManufactoringYear"] = row["ManufactoringYear"];
                Session["EngineType"] = row["EngineType"];
                Session["EngineCapacity"] = row["EngineCapacity"];
                Session["Color"] = row["Color"];
                Session["Price"] = row["Price"];
                Session["Condition"] = row["Condition"];
                Session["Description"] = row["Description"];
                Session["MotorcycleImage"] = row["MotorcycleImage"];
                Session["MotorcycleImageType"] = row["MotorcycleImageType"];
                Session["Active"] = row["Active"];




            }
        }
    }
}