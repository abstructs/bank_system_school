using System;
namespace W17As1_Wilson
{
	public class Andrew_Client : Andrew_Bank
	{
		public string first_name; // information about account holder
		public string last_name;
		public string home_address;
		public int s_i_n;

		public Andrew_Client(string first_name, string last_name, string home_address, int s_i_n)
		{
			this.first_name = first_name;
			this.last_name = last_name;
			this.home_address = home_address;
			this.s_i_n = s_i_n;
		}

		public Andrew_Client()
		{
			this.first_name = "Default_Name";
			this.last_name = "Default_Name";
			this.home_address = "Default_Address";
			this.s_i_n = 12345678;
		}

		public void set_user_info() // get the information from the user
		{
			Console.Clear();
			int decision = -1;

			while (true) // run until user types 0
			{
				Console.WriteLine("What values would you like to enter?\n1: First Name. Currently: {0} \n" +
								  "2: Last Name. Currently: {1}\n3: Home Address. Currently: {2}\n" +
								  "4: Social Security Number. Currently: {3}\n0: Back", first_name, last_name,
				                  home_address, s_i_n);
				decision = ask_for_int("Please enter a number from 0-4");

				Console.Clear();

				switch (decision)
				{
					case (0): // finish entering data
						return;
					case (1):
						Console.WriteLine("Please enter the client's First Name: ");
						first_name = Console.ReadLine();
						break;
					case (2):
						Console.WriteLine("Please enter the client's Last Name: ");
						last_name = Console.ReadLine();
						break;
					case (3):
						Console.WriteLine("Please enter the client's Home Address: ");
						home_address = Console.ReadLine();
						break;
					case (4):
						s_i_n = ask_for_int("Please enter the client's Social Security Number");
						break;
					default:
						Console.WriteLine("Something went wrong :-( !");
						return;
				}

				Console.Clear();
			}
		}

		public string client_info()
		{
			string client_string = string.Format("Name: {0} {1} | " +
												 "Home: {2} | Sin: {3} |\n",
			                                     first_name, last_name, home_address, s_i_n);
			
			return client_string;
		}
	}
}
