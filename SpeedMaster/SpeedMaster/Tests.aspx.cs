using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Services s = new Services();            
            //Session["customer"]= s.getCustomer(1);
            //lbl_name.Text = ((Customer)Session["customer"]).firstName;
            //Customer customer = s.createCustomer("coydecerta@gufum.com", "P@ssw0rd", "Ana", "Pires", "", "", "");
            //int result;
            //string v = s.doCreateCustomer(customer, "P@ssw0rd");
            //Response.Write(v);
            //Response.Write(Connections.DeleteCustomerDB());
            //string resultMessage = Connections.UpdateCustomerDB(2, "newemail@example.com", "NewFirstName", "NewLastName", "NewPassword",
            //"NewAddress", "NewPhone", true, "NewNIF");

            //string resultMessage = Connections.InsertAccessoryDB("A123", "AccessoryName", "Description", "50.00", "10", "true", "C001");
            //string resultMessage = Connections.DeleteAccessoryAndGlobalProductsIdsDB(7);

            //int accessoryIdToUpdate = 7;
            //string updatedAccessoryName = "Updated Accessory";
            //string updatedDescription = "Updated Description";
            //double updatedPrice = 49.99;
            //int updatedStock = 100;
            //bool updatedActive = true;
            //int updatedCategoryId = 2;

            //// Call the UpdateAccessoryInDB method
            //string result = Connections.UpdateAccessoryInDB(
            //    accessoryIdToUpdate,
            //    updatedAccessoryName,
            //    updatedDescription,
            //    updatedPrice,
            //    updatedStock,
            //    updatedActive,
            //    updatedCategoryId
            //);

            //int brandIdToUpdate = 1;
            //string updatedBrandName = "Updated Brand";
            //string updatedCountryOfOrigin = "Updated Country";

            //// Call the UpdateBrandInDB method
            //string result = Connections.UpdateBrandInDB(brandIdToUpdate, updatedBrandName, updatedCountryOfOrigin);

            //string result = Connections.DeleteBrandFromDB(1);

            //string categoryName = "Example Category";

            //// Call the InsertCategoryIntoDB method
            //string result = Connections.InsertCategoryIntoDB(categoryName);

            //int categoryIdToUpdate = 1;
            //string updatedCategoryName = "Updated Category";

            //// Call the UpdateCategoryInDB method
            //string result = Connections.UpdateCategoryInDB(categoryIdToUpdate, updatedCategoryName);

            //string result = Connections.DeleteCategoryFromDB(2);

            // Replace these values with actual data for testing

            //int existingMotorcycleID = 31;

            //// Replace the following values with the updated values you want to test
            //int updatedBrandID = 1;
            //string updatedModel = "UpdatedModelX";
            //int updatedManufacturingYear = 2024;
            //string updatedEngineType = "UpdatedEngineType";
            //int updatedEngineCapacity = 1800;
            //string updatedColor = "Blue";
            //decimal updatedPrice = 25000.00m;
            //string updatedCondition = "Used";
            //string updatedDescription = "Updated description";
            //byte[] updatedMotorcycleImage = new byte [0x0];  // Update with actual image bytes if needed
            //string updatedMotorcycleImageType = "PNG";
            //bool updatedActive = true;

            //string result = Connections.UpdateMotorcycleInDB(
            //    ID_Motorcycle: existingMotorcycleID,
            //    ID_Brand: updatedBrandID,
            //    Model: updatedModel,
            //    ManufacturingYear: updatedManufacturingYear,
            //    EngineType: updatedEngineType,
            //    EngineCapacity: updatedEngineCapacity,
            //    Color: updatedColor,
            //    Price: updatedPrice,
            //    Condition: updatedCondition,
            //    Description: updatedDescription,
            //    MotorcycleImage: updatedMotorcycleImage,
            //    MotorcycleImageType: updatedMotorcycleImageType,
            //    Active: updatedActive
            //);

            //string result = Connections.DeleteMotorcycleAndGlobalProductsIDsFromDB(31);

            //    string result = Connections.UpdateOrderInDB(
            //    orderId: 1,   // Replace with the actual order ID
            //    shoppingCartId: 2,   // Replace with the actual shopping cart ID
            //    orderDate: DateTime.Now,   // Replace with the actual order date
            //    shippingDate: DateTime.Now.AddDays(5),   // Replace with the actual shipping date
            //    totalAmount: 150.00m,  // Replace with the actual total amount
            //    statusId: 2  // Replace with the actual ID from the Status table
            //);

            int userIdToDelete = 1; // Replace with an actual user ID

            string result = Connections.DeleteUser(userIdToDelete);

            Response.Write(result);
        }

        
    }
}