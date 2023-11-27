using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SpeedMaster
{
    public class Connections
    {
        /*
         * Method to confirm credentials in database using SP login
         * password must be already encrpit
         * return 1 - Account is active
         * return 2 - Account not active	
         * return 0 - password or email are wrong	
         */
        public static int doLoginDB(string email, string password)
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
         * Methos do create a customer in DB using SP create_customer
         * if user dont insert address, phone, nif, lastName send empty string = ""
         * return 0  --'Email already exists!'
         * return 1  --'Check your email to activate the account'
         */
        public static int createCustomer(string email, string password, string firstName, string lastName, string phone, string address, string nif)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings
               ["SpeedMasterConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "create_customer";

            myCommand.Connection = myConn;

            myCommand.Parameters.AddWithValue("@email", email);
            myCommand.Parameters.AddWithValue("@password", password);
            myCommand.Parameters.AddWithValue("@firstName", firstName);
            myCommand.Parameters.AddWithValue("@lastName", lastName);
            myCommand.Parameters.AddWithValue("@phone", phone);
            myCommand.Parameters.AddWithValue("@address", address);
            myCommand.Parameters.AddWithValue("@nif", nif);


            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@activationStatus";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            myCommand.Parameters.Add(valor);


            myConn.Open();
            myCommand.ExecuteNonQuery();

            int result = Convert.ToInt32(myCommand.Parameters["@activationStatus"].Value);

            myConn.Close();

            return result;
        }


    }
}