using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

// using Kendo.Mvc.Extensions;
// using Kendo.Mvc.UI;

namespace A.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index ()
		{
			string connectionString =
				"Server=localhost;Database=Paluwagan;User ID=root;Password=a;Pooling=false";

			IDbConnection conn;
			conn = new MySqlConnection(connectionString);
			conn.Open();
			IDbCommand cmd = conn.CreateCommand();

			string sql = @"
				SELECT FirstName, LastName, Email 
				FROM Users";
			cmd.CommandText = sql;

			IDataReader reader = cmd.ExecuteReader();
			// cmd.ExecuteNonQuery
			// cmd.ExecuteScalar

			Users users = new Users ();
			while(reader.Read()) {
				users.This.Add (new User () {
					FirstName = (string)reader ["FirstName"],
					LastName = (string)reader ["LastName"],
					Email = (string)reader ["Email"]
				});
			}

			// clean up
																																		reader.Close();
			reader = null;

			cmd.Dispose();
			cmd = null;

			conn.Close();
			conn = null;

			var mvcName = typeof(Controller).Assembly.GetName ();
			var isMono = Type.GetType ("Mono.Runtime") != null;

			ViewData ["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			ViewData ["Runtime"] = isMono ? "Mono" : ".NET";

			return View (users.This);
		}
	}
}

