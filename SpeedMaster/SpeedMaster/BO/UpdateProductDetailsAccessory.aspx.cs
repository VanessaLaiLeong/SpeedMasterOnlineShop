﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class UpdateProductDetailAccessory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID_Accessory"] = Convert.ToInt32(Request.QueryString["productId"]);

            if (!IsPostBack)
            {
                //tbox = Session["AccessoryName"].ToString()
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["productType"]) == "Accessory")
            {

                Connections.UpdateAccessoryInDB(
                    //aqui alterar tudo para tbox
                        ID_Accessory: Convert.ToInt32(Session["ID_Accessory"]),
                        AccessoryName: Session["AccessoryName"].ToString(),
                        Description: Session["AccessoryDescription"].ToString(),
                        Price: Convert.ToDouble(Session["AccessoryPrice"]),
                        Stock: Convert.ToInt32(Session["AccessoryStock"]),
                        Active: Convert.ToBoolean(Session["AccessoryActive"]),
                        ID_Category: Convert.ToInt32(Session["ID_AccessoryCategory"]),
                        img: (byte[])Session["AccessoryImage"]
                    );

                Response.Write("success!");
            }
        }
    }
}