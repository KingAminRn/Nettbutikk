using Microsoft.AspNetCore.Mvc;
using Nettbutikk.Models;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;


namespace Nettbutikk.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Products(List<ProductsModel> objProductsModel)
        {

            string conStr = "Data Source=.\\SQLEXPRESS; Initial Catalog=Nettbutikkk_Amin; Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            string qury = "select id, price from products";
            SqlCommand cmd = new SqlCommand(qury, con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var productModel = new ProductsModel();
                productModel.ProductId = Convert.ToInt32(dr.GetValue(0));
                productModel.ProductPrice = Convert.ToInt32(dr.GetValue(1));
                objProductsModel.Add(productModel);
                
                //MessageBox.Show("The user id is: " + dr.GetValue(0) + " and first name is: " + dr.GetValue(1));
            }
            return View(objProductsModel);


            /*            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("select * from products", con));
                        DataSet dataSet = new DataSet();
                        dataAdapter.Fill(dataSet);

                        if (dataSet.Tables[0].Rows.Count >= 1)
                        {
                            Byte[] data = new Byte[0];
                            data = (Byte[])(dataSet.Tables[0].Rows[0]["picture"]);
                            MemoryStream mem = new MemoryStream(data);

                            objProductsModel.ProductImage = Image.FromStream(mem);

                            objProductsModel.ProductPrice = Convert.ToInt32(dataSet.Tables[0].Rows[0]["price"]);
                            return View(objProductsModel);
                        }


                        return View(objProductsModel);
            */


        }

        public IActionResult GetImage(int id)
        {

            string conStr = "Data Source=.\\SQLEXPRESS; Initial Catalog=Nettbutikkk_Amin; Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("select picture from products where id = " + id, con));
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

                Byte[] data = new Byte[0];
                data = (Byte[])(dataSet.Tables[0].Rows[0]["picture"]);

            return File(data, "image/jpg");
        }


        [HttpPost]
        public IActionResult Products()
        {
            return View();
        }
    }
}
