using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            //string res = Services.doCreateCustomer("jerdebastu@gufum.com", "P@ssw0rd", "Nome1", "", "", "", "", "P@ssw0rd");
           
            //Response.Write(res);

            //logica funciona
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (tb_address.Text == null)
            {
                tb_address.Text = "";
            }
            string result = Services.doCreateCustomer(tb_email.Text, tb_password.Text, tb_name.Text, tb_surname.Text, tb_phone.Text, tb_address.Text, tb_nif.Text, tb_otherPassword.Text);
            lbl_result.Text = result;
            lbl_result.Visible = true;
            Session["message"] = result;
            Response.Redirect("checkEmail.aspx");
        }
    }
}