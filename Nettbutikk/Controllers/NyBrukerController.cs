﻿using Microsoft.AspNetCore.Mvc;
using Nettbutikk.Models;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Nettbutikk.Controllers
{
    public class NyBrukerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Bruker()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Bruker(NyBurkerM objBukerM)
        {

            string conStr = "Data Source=.\\SQLEXPRESS; Initial Catalog=Nettbutikkk_Amin; Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            //string qury = "insert into logininfo values ('" + objBukerM.Username + "', '" + objBukerM.Password + "')";
            SqlCommand cmd = new SqlCommand("spSaveLogininfo", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", objBukerM.Username);
            cmd.Parameters.AddWithValue("@password", objBukerM.Password);

            cmd.ExecuteNonQuery();

            return View(objBukerM);
        }


    }
}

    

