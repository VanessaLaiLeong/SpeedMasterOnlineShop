﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace SpeedMaster
{
    public class Connections
    {

        /*
         * Method to confirm credentials in database using SP login
         * password must be already encrpit
         * return ID - Account is active 
         * return -1 - Account not active	
         * return 0 - password or email are wrong	
         */
        public static int LoginCustomer(string email, string password)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings
               ["SpeedMasterConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "login_customer";

            myCommand.Connection = myConn;

            myCommand.Parameters.AddWithValue("@email", email);
            myCommand.Parameters.AddWithValue("@password", password);

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@return";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            myCommand.Parameters.Add(valor);

            myConn.Open();
            myCommand.ExecuteNonQuery();

            int result = Convert.ToInt32(myCommand.Parameters["@return"].Value);
            myConn.Close();
            return result;
        }

        /*
         * Method do create a customer in DB using SP create_customer
         * if user dont insert address, phone, nif, lastName send empty string = ""
         * return 0  --'Email already exists!'
         * return 1  --'Account created with sucess! Check your email to activate the account'
         */
        public static int insertCustomerDB(Customer customer)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings
               ["SpeedMasterConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "insert_customer";

            myCommand.Connection = myConn;

            myCommand.Parameters.AddWithValue("@email", customer.email);
            myCommand.Parameters.AddWithValue("@password", customer.password);
            myCommand.Parameters.AddWithValue("@firstName", customer.firstName);
            myCommand.Parameters.AddWithValue("@lastName", customer.lastName);
            myCommand.Parameters.AddWithValue("@phone", customer.phone);
            myCommand.Parameters.AddWithValue("@address", customer.address);
            myCommand.Parameters.AddWithValue("@nif", customer.nif);

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@activationStatus";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;
            myCommand.Parameters.Add(valor);
            myConn.Open();
            myCommand.ExecuteNonQuery();

            int result = Convert.ToInt32(myCommand.Parameters["@activationStatus"].Value);
            myConn.Close();

            InsertShoppingCartAfetrCustomerCreation(customer.email);
            return result;
        }

        public static Customer getCustomerById(int id)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.Text; // Change to CommandType.Text for a query
            myCommand.CommandText = $"select * from Customers where ID_customer = {id}"; // Replace with your query
            myCommand.Connection = myConn;
            myConn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();

            Customer customer = new Customer();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    customer.ID = dataReader.GetInt32(0);
                    customer.email = dataReader.GetString(1);
                    customer.firstName = dataReader.GetString(2);
                    customer.lastName = dataReader.GetString(3);
                    customer.password = dataReader.GetString(4);
                    customer.address = dataReader.GetString(5);
                    customer.phone = dataReader.GetString(6);
                    customer.active = dataReader.GetBoolean(7).ToString();
                    customer.nif = dataReader.GetString(8);
                }
                return customer;
            }
            else
            {
                return null;
            }
        }

        public static void activateCustomerAccount(string email)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings
                           ["SpeedMasterConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "activate_account";

            myCommand.Connection = myConn;

            myCommand.Parameters.AddWithValue("@email", email);

            myConn.Open();
            myCommand.ExecuteNonQuery();
            myConn.Close();
        }

        public static void resetPasswordDB(string email, string password)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings
                           ["SpeedMasterConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "reset_password";

            myCommand.Connection = myConn;

            myCommand.Parameters.AddWithValue("@email", email);
            myCommand.Parameters.AddWithValue("@password", password);

            myConn.Open();
            myCommand.ExecuteNonQuery();
            myConn.Close();
        }

        public static string DeleteCustomerDB(int ID_Customer)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("delete_customer", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Customer", ID_Customer);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No customer with ID {ID_Customer} found.";
                        }
                        else
                        {
                            return $"Customer with ID {ID_Customer} deleted successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error deleting customer: {ex.Message}";
                    }
                }
            }
        }

        public static string UpdateCustomerDB(int ID_Customer, string Email, string FirstName, string LastName,
                string Password, string Address, string Phone, int Active, string NIF)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("update_customer", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Customer", ID_Customer);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@LastName", LastName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        command.Parameters.AddWithValue("@Active", Active);
                        command.Parameters.AddWithValue("@NIF", NIF);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No customer with ID {ID_Customer} found.";
                        }
                        else
                        {
                            return $"Customer with ID {ID_Customer} updated successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error updating customer: {ex.Message}";
                    }
                }
            }
        }

        /*
         * From here CRUD for Accessories Table
         */
        public static string InsertAccessoryDB(int ID_Accessory, string AccessoryName, string Description,
                double Price, int Stock, int Active, int ID_Category, byte[] img)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("insert_accessory", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Accessory", ID_Accessory);
                        command.Parameters.AddWithValue("@AccessoryName", AccessoryName);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@Price", Price);
                        command.Parameters.AddWithValue("@Stock", Stock);
                        command.Parameters.AddWithValue("@Active", Active);
                        command.Parameters.AddWithValue("@ID_Category", ID_Category);
                        command.Parameters.AddWithValue("@Image", img);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return "Accessory inserted successfully.";
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error inserting accessory: {ex.Message}";
                    }
                }
            }
        }

        /*
         * Deletes in the table accessory as well in table of the global products ids
         */
        public static string DeleteAccessoryAndGlobalProductsIdsDB(int ID_Accessory)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("delete_accessory", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Accessory", ID_Accessory);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No accessory with ID {ID_Accessory} found.";
                        }
                        else
                        {
                            return $"Accessory with ID {ID_Accessory} deleted successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error deleting accessory: {ex.Message}";
                    }
                }
            }
        }

        public static string UpdateAccessoryInDB(
            int ID_Accessory,
            string AccessoryName,
            string Description,
            double Price,
            int Stock,
            int Active,
            int ID_Category,
            byte[] img)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("update_accessory", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Accessory", ID_Accessory);
                        command.Parameters.AddWithValue("@AccessoryName", AccessoryName);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@Price", Price);
                        command.Parameters.AddWithValue("@Stock", Stock);
                        command.Parameters.AddWithValue("@Active", Active);
                        command.Parameters.AddWithValue("@ID_Category", ID_Category);
                        command.Parameters.AddWithValue("@Image", img);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No accessory with ID {ID_Accessory} found.";
                        }
                        else
                        {
                            return $"Accessory with ID {ID_Accessory} updated successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error updating accessory: {ex.Message}";
                    }
                }
            }
        }

        /*From here CRUD for Brand Table
         */
        public static string InsertBrandIntoDB(string brandName, string countryOfOrigin)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("insert_brand", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BrandName", brandName);
                        command.Parameters.AddWithValue("@CountryOfOrigin", countryOfOrigin);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return $"Brand '{brandName}' inserted successfully.";
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error inserting result: {ex.Message}";
                    }
                }
            }
        }

        public static string UpdateBrandInDB(int ID_Brand, string brandName, string countryOfOrigin)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("update_brand", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Brand", ID_Brand);
                        command.Parameters.AddWithValue("@BrandName", brandName);
                        command.Parameters.AddWithValue("@CountryOfOrigin", countryOfOrigin);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No result with ID {ID_Brand} found.";
                        }
                        else
                        {
                            return $"Brand with ID {ID_Brand} updated successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error updating result: {ex.Message}";
                    }
                }
            }
        }

        public static string DeleteBrandFromDB(int ID_Brand)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            // Check if there are motorcycles associated with the result
            if (HasMotorcyclesForBrand(ID_Brand))
            {
                return $"Cannot delete result with ID {ID_Brand} because there are associated motorcycles.";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("delete_brand", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Brand", ID_Brand);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No result with ID {ID_Brand} found.";
                        }
                        else
                        {
                            return $"Brand with ID {ID_Brand} deleted successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error deleting result: {ex.Message}";
                    }
                }
            }
        }

        // Helper method to check if there are motorcycles associated with the result
        private static bool HasMotorcyclesForBrand(int ID_Brand)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [SpeedMaster].[dbo].[Motorcycles] WHERE [ID_Brand] = @ID_Brand", connection))
                {
                    command.Parameters.AddWithValue("@ID_Brand", ID_Brand);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        /*
         *From here CRUD for categories table
         */
        public static string InsertCategoryIntoDB(string categoryName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("insert_category", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryName", categoryName);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return $"Category '{categoryName}' inserted successfully.";
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error inserting category: {ex.Message}";
                    }
                }
            }
        }

        public static string UpdateCategoryInDB(int ID_Category, string categoryName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("update_category", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Category", ID_Category);
                        command.Parameters.AddWithValue("@CategoryName", categoryName);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No category with ID {ID_Category} found.";
                        }
                        else
                        {
                            return $"Category with ID {ID_Category} updated successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error updating category: {ex.Message}";
                    }
                }
            }
        }

        public static string DeleteCategoryFromDB(int ID_Category)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            // Check if there are accessories associated with the category
            if (HasAccessoriesForCategory(ID_Category))
            {
                return $"Cannot delete category with ID {ID_Category} because there are associated accessories.";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("delete_category", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Category", ID_Category);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No category with ID {ID_Category} found.";
                        }
                        else
                        {
                            return $"Category with ID {ID_Category} deleted successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error deleting category: {ex.Message}";
                    }
                }
            }
        }

        // Helper method to check if there are accessories associated with the category
        private static bool HasAccessoriesForCategory(int ID_Category)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [SpeedMaster].[dbo].[Accessories] WHERE [ID_Category] = @ID_Category", connection))
                {
                    command.Parameters.AddWithValue("@ID_Category", ID_Category);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        /*
        * Method creates a product int the globalProductIds
        */
        public static int insertGlobalProductsDB(string type)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings
                           ["SpeedMasterConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "insert_global_product";
            myCommand.Connection = myConn;
            myCommand.Parameters.AddWithValue("@type", type);

            SqlParameter val = new SqlParameter();
            val.ParameterName = "@insertedId";
            val.Direction = ParameterDirection.Output;
            val.SqlDbType = SqlDbType.Int;
            myCommand.Parameters.Add(val);

            myConn.Open();
            myCommand.ExecuteNonQuery();

            int result = Convert.ToInt32(myCommand.Parameters["@insertedId"].Value);
            myConn.Close();
            return result;
        }

        public static DataTable GetProductDetails(int productId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("get_productDetails", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@id", productId);

                        connection.Open();

                        // Use SqlDataAdapter to fill a DataTable with the results of the stored procedure
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable resultTable = new DataTable();
                        adapter.Fill(resultTable);
                        return resultTable;
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        Console.WriteLine($"Error executing get_productDetails: {ex.Message}");
                        return null;
                    }
                }
            }
        }



        /*
         *from here CRUD for motorcycle
         */
        public static string InsertMotorcycleIntoDB(
            int ID_Motorcycle,
            int ID_Brand,
            string Model,
            int ManufactoringYear,
            string EngineType,
            int EngineCapacity,
            string ColorBike,
            decimal Price,
            string Condition,
            string Description,
            byte[] MotorcycleImage,
            string MotorcycleImageType,
            int Active)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("insert_motorcycle", connection))
                {
                    try
                    {


                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Motorcycle", ID_Motorcycle);
                        command.Parameters.AddWithValue("@ID_Brand", ID_Brand);
                        command.Parameters.AddWithValue("@Model", Model);
                        command.Parameters.AddWithValue("@ManufactoringYear", ManufactoringYear);
                        command.Parameters.AddWithValue("@EngineType", EngineType);
                        command.Parameters.AddWithValue("@EngineCapacity", EngineCapacity);
                        command.Parameters.AddWithValue("@Color", ColorBike);
                        command.Parameters.AddWithValue("@Price", Price);
                        command.Parameters.AddWithValue("@Condition", Condition);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@MotorcycleImage", MotorcycleImage);
                        command.Parameters.AddWithValue("@MotorcycleImageType", MotorcycleImageType);
                        command.Parameters.AddWithValue("@Active", Active);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return "Motorcycle inserted successfully.";
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error inserting motorcycle: {ex.Message}";
                    }
                }
            }
        }

        public static string UpdateMotorcycleInDB(
            int ID_Motorcycle,
            int ID_Brand,
            string Model,
            int ManufactoringYear,
            string EngineType,
            int EngineCapacity,
            string Color,
            decimal Price,
            string Condition,
            string Description,
            byte[] MotorcycleImage,
            string MotorcycleImageType,
            int Active)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("update_motorcycle", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Motorcycle", ID_Motorcycle);
                        command.Parameters.AddWithValue("@ID_Brand", ID_Brand);
                        command.Parameters.AddWithValue("@Model", Model);
                        command.Parameters.AddWithValue("@ManufactoringYear", ManufactoringYear);
                        command.Parameters.AddWithValue("@EngineType", EngineType);
                        command.Parameters.AddWithValue("@EngineCapacity", EngineCapacity);
                        command.Parameters.AddWithValue("@Color", Color);
                        command.Parameters.AddWithValue("@Price", Price);
                        command.Parameters.AddWithValue("@Condition", Condition);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@MotorcycleImage", MotorcycleImage);
                        command.Parameters.AddWithValue("@MotorcycleImageType", MotorcycleImageType);
                        command.Parameters.AddWithValue("@Active", Active);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No motorcycle with ID {ID_Motorcycle} found.";
                        }
                        else
                        {
                            return $"Motorcycle with ID {ID_Motorcycle} updated successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error updating motorcycle: {ex.Message}";
                    }
                }
            }
        }

        public static string DeleteMotorcycleAndGlobalProductsIDsFromDB(int ID_Motorcycle)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("delete_motorcycle", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Motorcycle", ID_Motorcycle);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No motorcycle with ID {ID_Motorcycle} found.";
                        }
                        else
                        {
                            return $"Motorcycle with ID {ID_Motorcycle} deleted successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error deleting motorcycle: {ex.Message}";
                    }
                }
            }
        }

        /*
         *from here CRUD for Orders
         */
        public static string InsertOrderIntoDB(
        int shoppingCartId,
        DateTime orderDate,
        string shippingDate,
        decimal totalAmount,
        int statusId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("insert_order", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_ShoppingCart", shoppingCartId);
                    command.Parameters.AddWithValue("@OrderDate", orderDate);
                    command.Parameters.AddWithValue("@ShippingDate", shippingDate);
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    command.Parameters.AddWithValue("@ID_Status", statusId);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return "Order inserted successfully.";

                }
            }
        }

        public static string UpdateOrderInDB(
        int orderId,
        int shoppingCartId,
        DateTime orderDate,
        string shippingDate,
        decimal totalAmount,
        int statusId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("update_order", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Order", orderId);
                        command.Parameters.AddWithValue("@ID_ShoppingCart", shoppingCartId);
                        command.Parameters.AddWithValue("@OrderDate", orderDate);
                        command.Parameters.AddWithValue("@ShippingDate", shippingDate);
                        command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                        command.Parameters.AddWithValue("@ID_Status", statusId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No order with ID {orderId} found.";
                        }
                        else
                        {
                            return $"Order with ID {orderId} updated successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error updating order: {ex.Message}";
                    }
                }
            }
        }

        public static string DeleteOrderInDB(int orderId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("delete_order", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Order", orderId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No order with ID {orderId} found.";
                        }
                        else
                        {
                            return $"Order with ID {orderId} deleted successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error deleting order: {ex.Message}";
                    }
                }
            }
        }

        /*
         *from here CRUD for OrdersStatus
         */
        public static string InsertOrderStatusIntoDB(string statusName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("insert_order_status", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StatusName", statusName);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return "Order status inserted successfully.";
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error inserting order status: {ex.Message}";
                    }
                }
            }
        }

        public static string UpdateOrderStatusInDB(int orderStatusId, string statusName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("update_order_status", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_OrderStatus", orderStatusId);
                        command.Parameters.AddWithValue("@StatusName", statusName);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No order status with ID {orderStatusId} found.";
                        }
                        else
                        {
                            return $"Order status with ID {orderStatusId} updated successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error updating order status: {ex.Message}";
                    }
                }
            }
        }

        /*
         *from here CRUD for ShoppingCarts
         */
        //Method that is used to create the cart automatically after creating a customer
        private static string InsertShoppingCartAfetrCustomerCreation(string email)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("insert_shopping_cart", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@email", email);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return "Shopping cart inserted successfully.";
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error inserting shopping cart: {ex.Message}";
                    }
                }
            }
        }

        public static string InsertShoppingCartIntoDB(int customerId, int cartStatus, DateTime createdDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("insert_shopping_cart_manager", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_Customer", customerId);
                    command.Parameters.AddWithValue("@CartStatus", cartStatus);
                    command.Parameters.AddWithValue("@CreatedDate", createdDate);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return "Shopping cart inserted successfully.";
                }

            }
        }


        public static string UpdateShoppingCartInDB(int shoppingCartId, int customerId, int cartStatus, DateTime createdDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("update_shopping_cart", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_ShoppingCart", shoppingCartId);
                        command.Parameters.AddWithValue("@ID_Customer", customerId);
                        command.Parameters.AddWithValue("@CartStatus", cartStatus);
                        command.Parameters.AddWithValue("@CreatedDate", createdDate);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No shopping cart with ID {shoppingCartId} found.";
                        }
                        else
                        {
                            return $"Shopping cart with ID {shoppingCartId} updated successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error updating shopping cart: {ex.Message}";
                    }
                }
            }
        }

        public static string DeleteShoppingCartInDB(int shoppingCartId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("delete_shopping_cart", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_ShoppingCart", shoppingCartId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No shopping cart with ID {shoppingCartId} found.";
                        }
                        else
                        {
                            return $"Shopping cart with ID {shoppingCartId} deleted successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error deleting shopping cart: {ex.Message}";
                    }
                }
            }
        }

        /*
         *from here CRUD for Reviews
         */
        public static string InsertReviewIntoDB(int shoppingCartId, int productId, int rating, string description, int orderId, int customerId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("insert_review", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_ShoppingCart", shoppingCartId);
                        command.Parameters.AddWithValue("@ID_Product", productId);
                        command.Parameters.AddWithValue("@Rating", rating);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@ID_Order", orderId);
                        command.Parameters.AddWithValue("@ID_Customer", customerId);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return "Review inserted successfully.";
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error inserting review: {ex.Message}";
                    }
                }
            }
        }


        public static string UpdateReviewAllColumns(int reviewId, int shoppingCartId, int productId, int rating, string description)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("update_review", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Review", reviewId);
                        command.Parameters.AddWithValue("@ID_ShoppingCart", shoppingCartId);
                        command.Parameters.AddWithValue("@ID_Product", productId);
                        command.Parameters.AddWithValue("@Rating", rating);
                        command.Parameters.AddWithValue("@Description", description);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No review with ID {reviewId} found.";
                        }
                        else
                        {
                            return $"Review with ID {reviewId} updated successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error updating review: {ex.Message}";
                    }
                }
            }
        }

        public static string DeleteReview(int reviewId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("delete_review", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Review", reviewId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No review with ID {reviewId} found.";
                        }
                        else
                        {
                            return $"Review with ID {reviewId} deleted successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error deleting review: {ex.Message}";
                    }
                }
            }
        }

        /*
         *from here CRUD for Users of the back office
         */
        public static int loginUser(string email, string password)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings
               ["SpeedMasterConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "login_user";

            myCommand.Connection = myConn;

            myCommand.Parameters.AddWithValue("@email", email);
            myCommand.Parameters.AddWithValue("@password", password);

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@return";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            myCommand.Parameters.Add(valor);

            myConn.Open();
            myCommand.ExecuteNonQuery();

            int result = Convert.ToInt32(myCommand.Parameters["@return"].Value);
            myConn.Close();
            return result;
        }

        public static string InsertUserIntoDB(string userName, int roleTypeId, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("insert_user", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@ID_RoleType", roleTypeId);
                        command.Parameters.AddWithValue("@Password", password);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return "User inserted successfully.";
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error inserting user: {ex.Message}";
                    }
                }
            }
        }

        public static string UpdateUserInDB(int userId, string userName, int roleTypeId, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("update_user", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_User", userId);
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@ID_RoleType", roleTypeId);
                        command.Parameters.AddWithValue("@Password", password);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No user with ID {userId} found.";
                        }
                        else
                        {
                            return $"User with ID {userId} updated successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error updating user: {ex.Message}";
                    }
                }
            }
        }

        public static string DeleteUser(int userId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("delete_user", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_User", userId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No user with ID {userId} found.";
                        }
                        else
                        {
                            return $"User with ID {userId} deleted successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error deleting user: {ex.Message}";
                    }
                }
            }
        }

        //add to cart method
        public static string AddToCart(string email, int productId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("add_to_cart", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@ID_product", productId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No cart or product found for email {email} and product ID {productId}.";
                        }
                        else
                        {
                            return $"Product with ID {productId} added to the cart successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error adding product to cart: {ex.Message}";
                    }
                }
            }
        }

        public static string DeleteFromCart(string email, int productId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("delete_from_cart", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@productID", productId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return $"No cart item found for email {email} and product ID {productId}.";
                        }
                        else
                        {
                            return $"Product with ID {productId} removed from the cart successfully.";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error removing product from cart: {ex.Message}";
                    }
                }
            }
        }

        public static DataTable GetShoppingCartItems(string email)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("get_shoppingCart_items", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@email", email);

                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            return dataTable;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        Console.WriteLine($"Error getting shopping cart items: {ex.Message}");
                        return null;
                    }
                }
            }
        }

        public static string getBrandCountryOriginById(int id)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.Text; // Change to CommandType.Text for a query
            myCommand.CommandText = $"select b.CountryOfOrigin from Brands b  where b.ID_Brand = {id}"; // Replace with your query
            myCommand.Connection = myConn;
            myConn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();

            string brand = "";
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    brand = dataReader.GetString(0);

                }
                return brand;
            }
            else
            {
                return null;
            }
        }

        public static string getBrandById(int id)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.Text; // Change to CommandType.Text for a query
            myCommand.CommandText = $"select b.BrandName from Brands b  where b.ID_Brand = {id}"; // Replace with your query
            myCommand.Connection = myConn;
            myConn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();

            string brand = "";
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    brand = dataReader.GetString(0);

                }
                return brand;
            }
            else
            {
                return null;
            }
        }


        // Method for making queries to a database with sorting
        // returns a DataTable with the information retrieved from the database;
        public static DataTable getSortedTable(string tableName, string orderTarget, string orderType)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.Text;
            myCommand.CommandText = $"SELECT * FROM {tableName} ORDER BY {orderTarget} {orderType}"; // Adjusted SQL query
            myCommand.Connection = myConn;

            DataTable table = new DataTable();

            try
            {
                myConn.Open();
                SqlDataReader dataReader = myCommand.ExecuteReader();

                if (dataReader.HasRows)
                {
                    table.Load(dataReader); // Load data into DataTable directly from SqlDataReader
                }

                return table;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {

                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        public static string InsertCustomerReviewInDB(int orderId, int productId, int rating, string description)
        {
            string resultMessage = "";

            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("create_customer_review", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Order", orderId);
                    command.Parameters.AddWithValue("@ID_Product", productId);
                    command.Parameters.AddWithValue("@rating", rating);
                    command.Parameters.AddWithValue("@description", description);

                    try
                    {
                        connection.Open();
                        var outputParameter = command.Parameters.Add("@outputMessage", SqlDbType.VarChar, 1000);
                        outputParameter.Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();

                        resultMessage = outputParameter.Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        resultMessage = $"Error creating customer review: {ex.Message}";
                    }
                }
            }

            return resultMessage;
        }

        //changes the orderstatus in the table orders
        public static string UpdateStatusInOrder(int orderId, int orderStatusId)
        {
            string resultMessage = "";
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand($"UPDATE Orders SET ID_OrderStatus = {orderStatusId} WHERE ID_Order = {orderId}", connection))
                {

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            resultMessage = "Order status updated successfully.";
                        }
                        else
                        {
                            resultMessage = "No order found for the specified order ID.";
                        }
                    }
                    catch (Exception ex)
                    {
                        resultMessage = $"Error updating order status: {ex.Message}";
                    }
                }
            }

            return resultMessage;
        }


        public static DataTable GetShoppingCart(Customer customer)
        {
            DataTable shoppingCartData = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand selectCommand = new SqlCommand($"SELECT * FROM ShoppingCarts WHERE ID_Customer = {customer.ID}", connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(selectCommand))
                        {
                            adapter.Fill(shoppingCartData);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception if necessary
                        Console.WriteLine($"Error fetching shopping cart: {ex.Message}");
                    }
                }
            }

            return shoppingCartData;
        }

        public static string UpdateShoppingCartStatus(int idShoppingCart, int status)
        {
            string resultMessage = "";
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand($"update ShoppingCarts set Cartstatus = {status} where ID_ShoppingCart = {idShoppingCart}", connection))
                {


                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        resultMessage = "ShoppingCarts status updated successfully.";
                    }
                    else
                    {
                        resultMessage = "No ShoppingCarts found for the specified ShoppingCarts ID.";
                    }

                }
            }

            return resultMessage;
        }

        public static string getEmailFromOrder(int orderId)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.Text; // Change to CommandType.Text for a query
            myCommand.CommandText = $"select c.Email from Orders o inner join ShoppingCarts sp on sp.ID_ShoppingCart = o.ID_ShoppingCart inner join Customers c on c.ID_Customer = sp.ID_Customer where o.ID_Order = {orderId}"; // Replace with your query
            myCommand.Connection = myConn;
            myConn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();

            string result = "";
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    result = dataReader.GetString(0);

                }
                return result;
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetShoppingCartItemsForReview(int orderId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("get_items_For_Review", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@orderId", orderId);

                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            return dataTable;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        Console.WriteLine($"Error getting shopping cart items: {ex.Message}");
                        return null;
                    }
                }
            }


        }

        public static string CreateCustomerReview(int orderId, int productId, int rating, string description)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("create_customer_review", connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_Order", orderId);
                        command.Parameters.AddWithValue("@ID_Product", productId);
                        command.Parameters.AddWithValue("@rating", rating);
                        command.Parameters.AddWithValue("@description", description);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return "Customer review created successfully.";
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception
                        return $"Error creating customer review: {ex.Message}";
                    }
                }
            }
        }

        public static DataTable GetDataTableFromQuery(string query)
        {
            DataTable dt = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand selectCommand = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(selectCommand))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception if necessary
                        Console.WriteLine($"Error fetching table: {ex.Message}");
                    }
                }
            }
            return dt;
        }
    }


    //public static void insertAccessories(int ID_Accessory, string AccessoryName, string Description, string Price,
    //    string Stock, string Active, string ID_Category)
    //{
    //    SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings
    //                   ["SpeedMasterConnectionString"].ConnectionString);
    //    SqlCommand myCommand = new SqlCommand();
    //    myCommand.CommandType = CommandType.StoredProcedure;
    //    myCommand.CommandText = "inset_accessories";
    //    myCommand.Connection = myConn;

    //    myCommand.Parameters.AddWithValue("@ID_Accessory", ID_Accessory);
    //    myCommand.Parameters.AddWithValue("@AccessoryName", AccessoryName);
    //    myCommand.Parameters.AddWithValue("@Description", Description);
    //    myCommand.Parameters.AddWithValue("@Price", Price);
    //    myCommand.Parameters.AddWithValue("@Stock", Stock);
    //    myCommand.Parameters.AddWithValue("@Active", Active);
    //    myCommand.Parameters.AddWithValue("@ID_Category", ID_Category);

    //    myConn.Open();
    //    myCommand.ExecuteNonQuery();
    //    myConn.Close();


    //}

}
