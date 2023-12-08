using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class UpdateCustomerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID_Customer"] = Convert.ToInt32(Request.QueryString["customerId"]);

            if (!IsPostBack)
            {
                tb_email.Text     = Session["customerEmail"].ToString();
                tb_firstname.Text = Session["customerFirstName"].ToString();
                tb_lastname.Text  = Session["customerLastname"].ToString();
                tb_password.Text  = Session["customerPassword"].ToString();
                tb_adress.Text    = Session["customerAdress"].ToString();
                tb_phone.Text     = Session["customerPhone"].ToString();
                tb_nif.Text       = Session["customerNIF"].ToString();
            }
           
        }

        private void btn()
        {
            int customerIDToUpdate = Convert.ToInt32(Request.QueryString["customerId"]);
            string newEmail = "teste@teste.com";
            string newFirstName = "NewFirstName123";
            string newLastName = "NewLastName";
            string newPassword = "NewPassword";
            string newAddress = "NewAddress";
            string newPhone = "NewPhone";
            bool isActive = true;
            string newNIF = "NewNIF";


            string result = Connections.UpdateCustomerDB(customerIDToUpdate, newEmail, newFirstName, newLastName,
                    newPassword, newAddress, newPhone, isActive, newNIF);
        }

        protected void update_Click(object sender, EventArgs e)
        {
            //Session["customerEmail2"] = TextBox1.Text;

            //todos mudar tbox
            int customerIDToUpdate = Convert.ToInt32(Session["ID_Customer"]);
            string newEmail = tb_email.Text;
            string newFirstName = tb_firstname.Text;
            string newLastName = tb_lastname.Text;
            string newPassword = tb_password.Text;
            string newAddress = tb_adress.Text;
            string newPhone = tb_phone.Text;
            bool isActive = Convert.ToBoolean(Session["customerActive"]);
            string newNIF = tb_nif.Text;



            string result = Connections.UpdateCustomerDB(customerIDToUpdate, newEmail, newFirstName, newLastName,
                    newPassword, newAddress, newPhone, isActive, newNIF);
        }
    }
}