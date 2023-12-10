using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Transactions;

namespace SpeedMaster
{
    public class Services
    {

        /*
         * Method to encrip strings
         */
        public static string EncryptString(string Message)
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
         * Method to desencrip strings
         */
        public static string DecryptString(string Message)
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

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            Message = Message.Replace("KKK", "+");
            Message = Message.Replace("JJJ", "/");
            Message = Message.Replace("III", "\\");

            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }

        /*
         * Method 
         */
        public static Customer getCustomer(int id) 
        {
           Customer customer = Connections.getCustomerById(id);
           return customer;
           
        }

        /*
         * Method to create the object customer
         */
        private static Customer createCustomer(string email, string password, string firstName, string lastName, string phone, string address, string nif) 
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

        /*
         * Method to check if password is strong 
         */
        public static string checkPassword(string password)
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

        /*
         * Method to create a customer and send to DB
         */
        public static string doCreateCustomer(string email, string password, string firstName, string lastName, string phone, string address, string nif, string otherPassowrd)
        {
            Customer customer = createCustomer(email, Services.EncryptString(password),  firstName,  lastName,  phone,  address,  nif);

            if (password != otherPassowrd)
            {
                return "Password does not match";
            }
            if (checkPassword(password) == "weak")
            {
                return "Please insert a stronger password";
            }
            else
            {
                int result = Connections.insertCustomerDB(customer);
                if (result == 0)
                {
                    return "Email already exists";
                }
                else 
                {                                                      
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

        public static string doUpdateCustomer(int ID_Customer, string email, string password, string firstName, string lastName, string phone, string address,bool active, string nif, string otherPassowrd)
        {
            if (password != otherPassowrd)
            {
                return "Password does not match";
            }
            if (checkPassword(password) == "weak")
            {
                return "Please insert a stronger password";
            }
            else
            {
                string result = Connections.UpdateCustomerDB(ID_Customer, email, EncryptString(password), firstName, lastName, phone, address, active, nif);
                return result;
            }
        }

        /*
         * Method to send emails
         */
        public static void sendEmail(string email, string subject, string body)
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

        /*
         * Method to resetPassword
         */
        public static string resetPassword(string email, string password, string otherPassword)
        {
            
            if (password != otherPassword)
            {
                return "Password does not match";
            }
            if (checkPassword(password) == "weak")
            {
                return "Please insert a stronger password";
            }
            else
            {
                Connections.resetPasswordDB(email, EncryptString(password));
                return "Success! Password updated.";
            }
        }

        public static byte [] getImageInfo(FileUpload image)
        {
            Stream imgStream;
            int imgTamanho;
            string imgtype;
            byte[] imgBinary;            

            if (image.HasFile)
            {
                //imgStream = ImgUpload.PostedFile.InputStream;
                //imgTamanho = ImgUpload.PostedFile.ContentLength;
                //imgtype = ImgUpload.PostedFile.ContentType;
                //imgBinary = new byte[imgTamanho];
                //imgStream.Read(imgBinary, 0, imgTamanho);

                imgStream = image.PostedFile.InputStream;
                imgTamanho = image.PostedFile.ContentLength;
                imgtype = image.PostedFile.ContentType;

                // Compress the image before storing
                imgBinary = CompressImage(imgStream, imgTamanho);

            }
            else
            {
                imgtype = "";
                imgBinary = new byte[0];
            }
            return imgBinary;         

        }

        private static byte[] CompressImage(Stream imgStream, int imgTamanho)
        {
            using (Bitmap original = new Bitmap(imgStream))
            {
                // Set the compression level (adjust as needed)
                EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, 50L);

                // Get the JPEG codec
                ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

                if (jpegCodec != null)
                {
                    EncoderParameters encoderParams = new EncoderParameters(1);
                    encoderParams.Param[0] = qualityParam;

                    // Compress and return the image as a byte array
                    using (MemoryStream compressedStream = new MemoryStream())
                    {
                        original.Save(compressedStream, jpegCodec, encoderParams);
                        return compressedStream.ToArray();
                    }
                }
            }

            // Return an empty byte array if compression fails
            return new byte[0];
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType == mimeType)
                {
                    return codec;
                }
            }

            return null;
        }

        
        public static string addCustomerReview(int orderId, int productId, int rating, string description)
        {
            if (rating > 0 && rating < 5)
            {
                Connections.InsertCustomerReviewInDB(orderId, productId, rating, description);
                return "Thank you for the review!";
            }
            else return "Insert a valid rating";            
        }

        public static void createOrder(Customer customer, decimal totalAmount)
        {
            using (TransactionScope scope = new TransactionScope())
            { 
                try
                {
                    int shoppingCartId;
                    DateTime dateTime = DateTime.Now;

                    if (customer != null)
                    {
                        DataTable shoppingCartData = Connections.GetShoppingCart(customer);

                        // Check if the DataTable has data
                        if (shoppingCartData != null && shoppingCartData.Rows.Count > 0)
                        {
                            DataRow row = shoppingCartData.Rows[0];
                            shoppingCartId = Convert.ToInt32(row["ID_ShoppingCart"]);

                            Connections.InsertOrderIntoDB(shoppingCartId, dateTime, "A confirmar", totalAmount, 1);
                            Connections.UpdateShoppingCartStatus(shoppingCartId, 0);//inactivate cart                   
                        }

                        Connections.InsertShoppingCartIntoDB(customer.ID, 1, dateTime);//new shopping cart

                    }
                    scope.Complete();
                }
                catch (Exception e) {
                    scope.Dispose();
                    throw e;
                }
            }
            
        }

        public static void setOrderStatusDelivered(int orderId, int orderStatus)
        {
            if (orderStatus == 4)
            {
                Connections.UpdateStatusInOrder(orderId, orderStatus);

                //send mail

                string subject = "Welcome to Speed Master - Your Ultimate Destination for Motorcycle Enthusiasts 🏍️🔥";
                string body = "Welcome to Speed Master!<br><br>" +
                              "We are thrilled to welcome you to our motorcycle-loving community.<br><br>" +
                              "At Speed Master, we offer a diverse range of high-performance motorcycles and gear, curated for true enthusiasts like yourself.<br><br>" +
                              "Start your thrilling journey with us by exploring our website and discovering the latest in motorcycle technology and style.<br><br>" +
                              "Should you have any inquiries or require assistance, feel free to reply to this email. We're here to ensure your motorcycle experience is extraordinary.<br><br>" +
                              "Rev up your engines and embrace the spirit of Speed Master!<br><br>" +
                              "<br>" +
                              "Thank you for choosing Speed Master! We value your feedback and would love to hear about your experience with our products. Share your thoughts by writing a review.<br><br>" +
                              "Click <a href='https://localhost:44389/FO/ReviewPage.aspx?email=" + EncryptString(email) + "'>here</a> to write a review.<br><br>" +
                              "<br>" +
                              "Best Regards,<br>" +
                              "The Speed Master Team";

            }

        }

    }

}
