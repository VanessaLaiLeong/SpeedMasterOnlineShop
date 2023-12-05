﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster
{
    public partial class FrontOffice : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
            {
                string userName =  "Login";
            }
            else
            {
                string userName = Session["customer"].ToString();
            }
        }
    }
}