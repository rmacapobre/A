using System;
using System.Collections.Generic;

namespace A
{
	public class User
	{
		public int ID { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public User ()
		{
			ID = 0;
			Email = string.Empty;
			FirstName = string.Empty;
			LastName = string.Empty;
		}
	}

	public class Users
	{
		public List<User> This { get; set; }

		public Users ()
		{
			This = new List<User> ();
		}
	}
}

