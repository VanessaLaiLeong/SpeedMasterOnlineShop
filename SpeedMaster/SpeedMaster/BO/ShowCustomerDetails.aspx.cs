using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class ShowCustomerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["ID_Customer"] = (Convert.ToInt32(Request.QueryString["ID_Customer"]));
                int ID_Customer = Convert.ToInt32(Request.QueryString["ID_Customer"]);
                
                DataTable dt = Connections.GetDataTableFromQuery($"select * from customers where ID_customer = {ID_Customer}");
                tb_Email.Text = dt.Rows[0]["Email"].ToString();
                tb_FirstName.Text = dt.Rows[0]["firstName"].ToString();
                tb_LastName.Text = dt.Rows[0]["lastName"].ToString();
                tb_Address.Text = dt.Rows[0]["Address"].ToString();
                tb_Phone.Text = dt.Rows[0]["Phone"].ToString();
                tb_NIF.Text = dt.Rows[0]["nif"].ToString();
                Session["password"] = dt.Rows[0]["Password"].ToString();

                if (dt.Rows[0]["Active"].ToString() == "True")
                {
                    rd_active.SelectedValue = "yes";
                }
                else rd_active.SelectedValue = "no";
            }
            
           
            
        }

     
       

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int ID_Customer = Convert.ToInt32(Request.QueryString["ID_Customer"]);
            string Email = tb_Email.Text;
            string FirstName = tb_FirstName.Text;
            string LastName = tb_FirstName.Text;
            string Password = Session["password"].ToString();
            string Address = tb_Address.Text;
            string Phone = tb_Phone.Text;         
            string NIF = tb_NIF.Text;
            int active;

            if (rd_active.SelectedValue == "yes")
            {
                active = 1;
            }
            else active = 0;


            Response.Write(Connections.UpdateCustomerDB(
                ID_Customer,
                Email, 
                FirstName,
                LastName,
                Password,
                Address,
                Phone,
                active,
                NIF
                ));
           
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {

        }
    }
}