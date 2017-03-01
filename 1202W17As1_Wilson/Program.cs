using System;

namespace W17As1_Wilson
{
	class Andrew_MainClass
	{
		public static void greeting() 
		{
			string bank_name = "Bank of George Brown";
			string manager_first_name = "Andrew";
			string manager_last_name = "Wilson";

			Console.WriteLine("Welcome To {0} - <G><B><C>", bank_name);
			Console.WriteLine("___________________________________________\n");
			Console.WriteLine("Manager Name: {0} {1}\nStudent Number: 101069860", manager_first_name, manager_last_name);
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}

		public static int ask_for_int(string message)
		{
			int result;
			while (true) // run until user inputs a valid integer
			{
				Console.WriteLine(message); // write message
				if (Int32.TryParse(Console.ReadLine(), out result)) // make sure user inputs a number
				{
					return result; // return the number the user typed
				};
			}
		}

		public static void Main(string[] args)
		{
			greeting(); // greet the user
			Andrew_Bank bank = new Andrew_Bank();

			for (int i = 0; i < 6; i++)
			{
				bank.create_new_account();
			}

			bank.bank_menu();

		}
	}
}