using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace SpeedMaster.FO
{
    public partial class Billing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            DataTable invoiceData = Connections.GetShoppingCartItems(((Customer)Session["customer"]).email);

            // Start building the HTML content for the invoice
            StringBuilder invoiceHtml = new StringBuilder();
            invoiceHtml.Append(@"
                <!DOCTYPE html>
                <html lang='en'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title></title>         
                </head>
                <body>
                    <h1>Proforma Invoice</h1>
                        <div class='company-details'>
                        <p><b>Name:</b> " + "Blossom Brews ® " + @" </p>
                        <p><b>Adress:</b> " + "221B Baker Street, London " + @" </p>
                        <!-- Add more details as needed -->
                    </div>
                    <br/><br/>
                    <div class='invoice-details'>
                        <p><b>Name:</b> " + tb_nome.Text + @"</p>
                        <p><b>Address:</b> " + tb_morada.Text + @"</p>
                        <p><b>Email:</b> " + tb_email.Text + @"</p>
                        <!-- Add more details as needed -->
                    </div>
                    <br/><br/>                    
                    <table>
                        <thead>
                            <tr>
                                <th>Item</th>
                                <th>Unit Price</th>
                                <th>Quantity</th>                        
                                <th>Total</th>
                            </tr>
                        </thead>
                        <tbody>");

            // Declare totalPrice outside the loop
            decimal totalPrice = 0;

            // Iterate through the rows in the DataTable and add them to the HTML
            foreach (DataRow row in invoiceData.Rows)
            {
                invoiceHtml.AppendFormat(@"
                        <tr>
                            <td>{0}</td>
                            <td>€{1}</td>
                            <td>{2}</td>
                            <td>€{3}</td>
                        </tr>",
                            row["name"],  // Adjust column names as needed
                            row["price"],
                            row["quantity"],
                            row["ItemTotalPrice"]
                        );

                // Update totalPrice within the loop
                totalPrice += Convert.ToDecimal(row["price"]) * Convert.ToInt32(row["quantity"]);
            }

            // Add the closing tags for the HTML
            invoiceHtml.Append(@"                
                            </tbody>               
                        </table>
        ---------------------------------------------------------------------------------------------------------------------

                        <p class='total'>Total: €" + totalPrice.ToString("0.00") + @"</p>
                ");

            // Add a new section for payment reference
            invoiceHtml.AppendFormat(@"
                <div class='payment-reference'>
                    <p><b>Faça o pagamento para a seguinte referencia:</b> " + "PT50 1234 5678 9012 3456 7890 12" + @"</p>
                    <!-- Add more details as needed -->
                </div>
                ");

            // Add the closing tags for the HTML
            invoiceHtml.Append(@"                
            </body>
            </html>
            ");

            string pdfName = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "") + ".pdf";

            // Specify the virtual path where you want to save the PDF inside the project
            string relativePath = "/FO/PDFs/" + pdfName;

            // Get the physical path corresponding to the virtual path
            string absolutePath = Server.MapPath(relativePath);

            using (StringReader sr = new StringReader(invoiceHtml.ToString()))
            {
                // Create a MemoryStream to store the PDF content
                using (MemoryStream ms = new MemoryStream())
                {
                    // Initialize the PDF document
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

                    // Create a PdfWriter and associate it with the MemoryStream
                    PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, ms);

                    // Open the PDF document for writing
                    pdfDoc.Open();

                    // Create an HTMLWorker to parse the HTML content
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    htmlparser.Parse(sr);

                    // Close the PDF document
                    pdfDoc.Close();

                    // Get the PDF content from the MemoryStream
                    byte[] pdfBytes = ms.ToArray();

                    // Save the PDF content to the specified file path
                    File.WriteAllBytes(absolutePath, pdfBytes);
                }
            }

            string newURL = "https://localhost:44389/" + relativePath;
            string script = "<script>window.open('" + newURL + "', '_black';</script>)";
            ClientScript.RegisterStartupScript(this.GetType(), "OpenPdfInNewTab", script);

            Session["pdfGenerated"] = absolutePath;

            string pdfGerado = Session["pdfGenerated"] as string;

            //if (string.IsNullOrEmpty(pdfGerado))
            //{
            //    return;
            //}

            MailMessage mail = new MailMessage();
            SmtpClient servidor = new SmtpClient();


            string smtpUtilizador = ConfigurationManager.AppSettings["SMTP_USER"];

            mail.From = new MailAddress(smtpUtilizador);
            mail.To.Add(new MailAddress(tb_email.Text));
            mail.Subject = $"Thank you for your purchase Speed Master 🏍️🔥";
            mail.IsBodyHtml = true;




            Attachment anexo = new Attachment(pdfGerado);

            mail.Attachments.Add(anexo);



            mail.Body = $"Attached invoice" + DateTime.Now.ToString();

            servidor.Host = ConfigurationManager.AppSettings["SMTP_HOST"];
            servidor.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);

            
            string smtpPassword = ConfigurationManager.AppSettings["SMTP_PASS"];

            servidor.Credentials = new NetworkCredential(smtpUtilizador, smtpPassword);
            servidor.EnableSsl = true;

            servidor.Send(mail);

            Customer customer = (Customer)Session["customer"];
            Services.createOrder(customer, Convert.ToInt32(Session["totalprice"]));
        }
    }
}