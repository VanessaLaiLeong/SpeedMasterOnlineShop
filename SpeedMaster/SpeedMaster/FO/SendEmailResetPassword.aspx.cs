using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class SendEmailResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_sendEmail_Click(object sender, EventArgs e)
        {
            string email = ((Customer)Session["customer"]).email;
            string subject = "Speed Master - Reset your password 🏍️🔥";
            string body = "<html>" +
             "<head>" +
             "<meta charset='UTF-8'>" +
             "<meta http-equiv='X-UA-Compatible' content='IE=edge'>" +
             "<meta name='viewport' content='width=device-width, initial-scale=1.0'>" +
             "<title>Reset Your Speed Master Account Password</title>" +
             "</head>" +
             "<body style='font-family: Arial, sans-serif;'>" +
             "<p>Dear [Customer's Name],</p>" +
             "<p>We trust that you're having an exhilarating day! It seems that you've requested to reset your password for your Speed Master account. No worries, we're here to assist you in revving up your motorcycle journey!</p>" +
             "<p>To reset your password, simply click on the link below:</p>" +
             "<p><a href='https://localhost:44389/FO/Activation.aspx?email=" + Services.EncryptString(tb_email.Text) + "'>here</a><br><br>" +
             "<p>Please be aware that this link is valid for the next 24 hours. If you did not initiate this password reset, or if you've changed your mind, you can ignore this email.</p>" +
             "<p>If you encounter any difficulties or have inquiries, feel free to respond to this email, and our team will assist you promptly.</p>" +
             "<p>Thank you for being a part of Speed Master. We're dedicated to ensuring your motorcycle experience is as thrilling as it can be!</p>" +
             "<p>Ride on,</p>" +
             "<p>The Speed Master Team</p>" +
             "</body>" +
             "</html>";

            Services.sendEmail(email, subject, body);
        }
    }
}