using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services.Description;


namespace SpeedMaster
{
    public class Services
    {
        /*
         * Method to encrip strings
         */
        public string EncryptString(string Message)
        {
            string Passphrase = "atec";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();



            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below



            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));



            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();



            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;



            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);



            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }



            // Step 6. Return the encrypted string as a base64 encoded string



            string enc = Convert.ToBase64String(Results);
            enc = enc.Replace("+", "KKK");
            enc = enc.Replace("/", "JJJ");
            enc = enc.Replace("\\", "III");
            return enc;
        }

        /*
         * Method
         */
        public Customer getCustomer(int id) 
        {
           Customer customer = Connections.getCustomer(id);
           return customer;
           
        }

        /*
         * Method works
         */
        public Customer createCustomer(string email, string password, string firstName, string lastName, string phone, string address, string nif) 
        {
            Customer customer = new Customer();
            customer.email = email;
            customer.password = password;
            customer.firstName = firstName;
            customer.lastName = lastName;
            customer.phone = phone;
            customer.address = address;
            customer.nif = nif;
            
            return customer;
        }

        public void doLogin()
        {

        }



        public string checkPassword(string password)
        {
            Regex upper = new Regex("[A-Z]");
            Regex lower = new Regex("[a-z]");
            Regex num = new Regex("[0-9]");
            Regex special = new Regex("[^a-zA-Z0-9]");
            Regex plica = new Regex("");

            string situation = "strong";

            if (password.Length < 6) situation = "weak";

            if (upper.Matches(password).Count < 1)
            {
                situation = "weak";
            }
            if (lower.Matches(password).Count < 1)
            {
                situation = "weak";
            }
            if (num.Matches(password).Count < 1)
            {
                situation = "weak";
            }
            if (special.Matches(password).Count < 1)
            {
                situation = "weak";
            }
            if (plica.Matches(password).Count < 1)
            {
                situation = "weak";
            }


            return situation;
        }

        public string doCreateCustomer(Customer customer, string otherPassowrd)
        {
            if (customer.password != otherPassowrd)
            {
                return "Password does not match";
            }
            if (checkPassword(customer.password) == "weak")
            {
                return "Please insert a stronger password";
            }
            else
            {
                int result = Connections.createCustomerDB(customer);
                if (result == 0)
                {
                    return "Email already exists";
                }
                else 
                {
                    customer.password = EncryptString(customer.password);
                    Connections.createCustomerDB(customer);
                    string email = customer.email;
                    string subject = "Welcome to Speed Master - Your Ultimate Destination for Motorcycle Enthusiasts 🏍️🔥";
                    // no link pode ser capaz de cada um ter de por o seu?? id
                    // Pelo menos para mim, o meu localhost é igual ao teu, acho que o IIS usa sempre o mesmo
                    string body = "Welcome to Speed Master!<br><br>" +
                                    "We are thrilled to welcome you to our motorcycle-loving community.<br><br>" +
                                    "At Speed Master, we offer a diverse range of high-performance motorcycles and gear, curated for true enthusiasts like yourself.<br><br>" +
                                    "Start your thrilling journey with us by exploring our website and discovering the latest in motorcycle technology and style.<br><br>" +
                                    "Should you have any inquiries or require assistance, feel free to reply to this email. We're here to ensure your motorcycle experience is extraordinary.<br><br>" +
                                    "Rev up your engines and embrace the spirit of Speed Master!<br><br>" +
                                    "<br>" +
                                    "Account created. Click <a href='https://localhost:44389/FO/Activation.aspx?email=" + EncryptString(email) + "'>here</a> to activate your account.<br><br>" +
                                    "<br>" +
                                    "Best Regards,<br>" +
                                    "The Speed Master Team";                
                    sendEmail(customer.email, subject, body);
                    return "Account created with sucess! Check your email to activate the account.";
                }              

            }

        }

        public void sendEmail(string email, string subject, string body)
        {
            string smtpUtilizador = ConfigurationManager.AppSettings["SMTP_USER"];
            string smtpPassword = ConfigurationManager.AppSettings["SMTP_PASS"];
            MailMessage mail = new MailMessage();
            SmtpClient servidor = new SmtpClient();

            mail.From = new MailAddress(smtpUtilizador);
            mail.To.Add(new MailAddress(email));
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body;
            servidor.Host = ConfigurationManager.AppSettings["SMTP_HOST"];
            servidor.Port = int.Parse(ConfigurationManager.AppSettings["SMTP_PORT"]);

            servidor.Credentials = new NetworkCredential(smtpUtilizador, smtpPassword);
            servidor.EnableSsl = true;

            servidor.Send(mail);
        }
    }
}
