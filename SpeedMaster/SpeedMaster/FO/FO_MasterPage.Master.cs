﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class FO_MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            string selectedValue = ddl.SelectedValue;

            // Redirect based on the selected value
            switch (selectedValue)
            { 
                case "Redirect_motas":
                    Response.Redirect(".aspx");
                    break;

                case "Redirect_acessorios":
                    Response.Redirect(".aspx");
                    break;

                default:
                    
                    break;
            }
        }
    }
}