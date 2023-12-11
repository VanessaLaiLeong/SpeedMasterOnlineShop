using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class home : System.Web.UI.Page
    {
        int[] productIds;
        int shownProductsnumber = 3;
        protected void Page_Load(object sender, EventArgs e)
        {
          

            if (!IsPostBack)
            {
                productIds = new int[shownProductsnumber];
                getProductId2(shownProductsnumber);
                LoadProductDetails(productIds[0], lbl_productName, lbl_productDescription, lbl_productPrice, Image3);
                LoadProductDetails(productIds[1], lbl_productName2, lbl_productDescription2, lbl_productPrice2, Image4);
                LoadProductDetails(productIds[2], lbl_productName3, lbl_productDescription3, lbl_productPrice3, Image5);
                Session["productId1"] = productIds[0];
                Session["productId2"] = productIds[1];
                Session["productId3"] = productIds[2];


            }
        }
        private void LoadProductDetails(int productID, Label lbl_productName, Label lbl_productDescription, Label lbl_productPrice, Image image)
        {
            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString);

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "get_productDetails";
            myCommand.Connection = myConn;

            myCommand.Parameters.AddWithValue("@id", productID);

            myConn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();

            if (dataReader.Read())
            {
                byte[] imageData = dataReader["MotorcycleImage"] as byte[];
                if (imageData != null && imageData.Length > 0)
                {
                    image.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])dataReader["MotorcycleImage"]);
                }

                lbl_productName.Text = dataReader["BrandName"].ToString() + dataReader["Model"].ToString();

                lbl_productDescription.Text = dataReader["Description"].ToString();

                lbl_productPrice.Text = dataReader["Price"].ToString();

                myConn.Close();


            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        //private void PrintProductDetails(DataTable productDetails)
        //{
        //    foreach (DataRow row in productDetails.Rows)
        //    {

        //        Session["ID_Motorcycle"] = row["ID_Motorcycle"];
        //        lbl_marca.Text = row["BrandName"].ToString();
        //        lbl_modelo.Text = row["Model"].ToString();
        //        lbl_ano.Text = row["ManufactoringYear"].ToString();
        //        lbl_TipoMotor.Text = row["EngineType"].ToString();
        //        lbl_Capacity.Text = row["EngineCapacity"].ToString();
        //        lbl_cor.Text = row["Color"].ToString();
        //        lbl_preco.Text = row["Price"].ToString();
        //        lbl_condicao.Text = row["Condition"].ToString();
        //        lbl_productDescription.Text = row["Description"].ToString();
        //        byte[] imageData = row["MotorcycleImage"] as byte[];

        //        if (imageData != null && imageData.Length > 0)
        //        {
        //            ImagemProduto.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(imageData);
        //        }
        //    }
        //}
        private void getProductId2(int count)
        {

            SqlConnection myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SpeedMasterConnectionString"].ConnectionString);
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandType = CommandType.Text; // Change to CommandType.Text for a query
            myCommand.CommandText = "select ID_motorcycle from Motorcycles"; ; // Replace with your query
            myCommand.Connection = myConn;
            myConn.Open();
            SqlDataReader dataReader = myCommand.ExecuteReader();
            List<int> dataList = new List<int>();
            while (dataReader.Read())
            {
                dataList.Add(Convert.ToInt32(dataReader.GetValue(0)));
            }
            myConn.Close();
            Random random = new Random();
            for (int i = 0; i < productIds.Count(); i++)
            {
                int aux = random.Next(0, dataList.Count - 1);
                productIds[i] = dataList[aux];
            }
        }

    }
}