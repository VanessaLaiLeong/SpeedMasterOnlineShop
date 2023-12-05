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
                TextBox1.Text = Session["customerEmail"].ToString();
                //fazer as restantes
            }
           
        }

        private void btn()
        {
            int customerIDToUpdate = 3;
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
            string newEmail = TextBox1.Text;
            string newFirstName = Convert.ToString(Session["customerFirstName"]);
            string newLastName = Convert.ToString(Session["customerLastName"]);
            string newPassword = Convert.ToString(Session["customerPassword"]);
            string newAddress = Convert.ToString(Session["customerAddress"]);
            string newPhone = Convert.ToString(Session["customerPhone"]);
            bool isActive = Convert.ToBoolean(Session["customerActive"]);
            string newNIF = Convert.ToString(Session["customerNIF"]);



            string result = Connections.UpdateCustomerDB(customerIDToUpdate, newEmail, newFirstName, newLastName,
                    newPassword, newAddress, newPhone, isActive, newNIF);
        }
    }
}