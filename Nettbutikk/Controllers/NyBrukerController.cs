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
        public IActionResult NyBruker(NyBurkerM objBukerM)
        {

            string conStr = "Data Source=.\\SQLEXPRESS; Initial Catalog=Nettbutikkk_Amin; Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            string qury = "insert into logininfo values brukernavn = '" + objBukerM.Username + "', passord = '" + objBukerM.Password + "'";
            SqlCommand cmd = new SqlCommand(qury, con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (Convert.ToInt32(dr.GetValue(0)) >= 1)
                {
                    ViewBag.msg = "<script>alert('Login er korrekt')</script>";

                    return View();
                }
                else
                {
                    ViewBag.msg = ("<script>alert('Login er korrekt')</script>");
                    //ViewBag.msg = "loginn feilet";
                }
            }

            return View();
        }


    }
}

    

