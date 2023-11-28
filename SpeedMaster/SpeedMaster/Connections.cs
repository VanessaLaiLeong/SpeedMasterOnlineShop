using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.ComponentModel;

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
        public static int Login(string email, string password)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings
               ["SpeedMasterConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "login";

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
        public static int createCustomerDB(Customer customer)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings
               ["SpeedMasterConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "create_customer";

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

            createCart(customer.email);
            return result;
        }

        /*
         * Method to create cart that is used inside createCustomer()
         */
        private static void createCart(string email)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings
                           ["SpeedMasterConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "create_cart";

            myCommand.Connection = myConn;

            myCommand.Parameters.AddWithValue("@email", email);

            myConn.Open();
            myCommand.ExecuteNonQuery();
            myConn.Close();
        }

        public static Customer getCustomer(int id)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.Text; // Change to CommandType.Text for a query
            myCommand.CommandText = $"select * from Customers where ID_customer = {id}"; // Replace with your query
            myCommand.Connection = myConn;
            myConn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();

            Customer customer = new Customer();            
            while (dataReader.Read())
            {
                customer.email = dataReader.GetString(1);
                customer.firstName = dataReader.GetString(2);
                customer.lastName = dataReader.GetString(3);                
                customer.password = dataReader.GetString(4);
                customer.address = dataReader.GetString(5);
                customer.phone = dataReader.GetString(6);
                customer.active = dataReader.GetBoolean(7).ToString();
                customer.nif = dataReader.GetString(8);
            }
            myConn.Close();

            return customer;
        }

    }
}