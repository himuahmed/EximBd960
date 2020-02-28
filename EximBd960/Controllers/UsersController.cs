using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using EximBd960.Models;

namespace EximBd960.Controllers
{

    public class UsersController : Controller
    {
        
        private String connectionString = WebConfigurationManager.ConnectionStrings["Eximbd960DbContext"].ConnectionString;
        
        public ActionResult LogIn()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(User user)
        {
            bool result = Loggedin(user);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index", "Applicants");
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View();

        }


        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User model)
        {
            bool result = AddUser(model);

            if (result)
            {
                return RedirectToAction("LogIn", "Users");
            }
            else
            {
                return RedirectToAction("SignUp", "Users");
            }

            //return View();
        }

        public bool AddUser(User user)
        {
            
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Users (UserName,Password) VALUES (@Username,@Password)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.Add("Username", SqlDbType.VarChar);
            cmd.Parameters["Username"].Value = user.UserName;

            cmd.Parameters.Add("Password", SqlDbType.VarChar);
            cmd.Parameters["Password"].Value = user.Password;
            connection.Open();
            int isSaved = cmd.ExecuteNonQuery();
            connection.Close();
            if (isSaved > 0)
            {
                ModelState.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Loggedin(User user)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Users WHERE (UserName = @Username  AND Password = @Password)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.Add("Username", SqlDbType.VarChar);
            cmd.Parameters["Username"].Value = user.UserName;

            cmd.Parameters.Add("Password", SqlDbType.VarChar);
            cmd.Parameters["Password"].Value = user.Password;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn", "Users");
        }
    }
}