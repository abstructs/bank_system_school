using System;
namespace W17As1_Wilson
{
	public class Andrew_Bank
	{
		protected const decimal INTEREST_RATE = 0.01m; // constants defined by bank
		protected const decimal DEBIT_FEE = 5.0m; // use decimal for money to prevent rounding errors 
		const decimal ANNUAL_FEE = 60.00m;

		Andrew_Account[] accounts = new Andrew_Account[10]; // stores up to 10 accounts
		int accounts_size = 0;
		public Andrew_Bank()
		{
			
		}

		public void create_new_account() // create a new account with default values
		{
			accounts[accounts_size++] = new Andrew_Account(); // create a new account
			return;
		}

		public void create_new_account(string first_name, string last_name, string home_address, int s_i_n) // create a new account with default values
		{
			accounts[accounts_size++] = new Andrew_Account(first_name, last_name, home_address, s_i_n); // create a new account
			return;
		}

		public void list_of_accounts()
		{
			for (int i = 0; i < accounts_size - 1; i++)
			{
				Console.WriteLine("{0}: {1}", i + 1, accounts[i].client_info());
			}
		}

		public void get_accounts() // view list of accounts currently in bank
		{
			Console.WriteLine("Press 0 to go back\n");

			int decision = -1;

			while (true)
			{
				Console.WriteLine("Which account would you like to view/edit?\n");
				list_of_accounts(); // list all the current accounts
				decision = ask_for_int("");

				if (decision > 0 && decision <= accounts_size + 1)
				{
					Console.Clear();
					accounts[decision + 1].account_menu(); // get the menu for that account
					break;
				}
				else if (decision == 0)
				{
					return; // go back
				}
				else
				{
					Console.Clear();
					Console.WriteLine("Please choose a valid option");
				}
			}

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
				}	
				else
				{
					Console.WriteLine("Please enter an integer value");
				}
			}
		}

		public static void account_menu(Andrew_Account account) // menu for viewing and changing account information
		{
			int decision = -1;

			while (true)
			{
				Console.Clear();
				decision = ask_for_int("What would you like to do?\n1: Enter Client Information.\n2: View Client Information.\n3: View Greeting\n0: Back to bank menu.");

				switch (decision)
				{
					case (0):
						return;
					case (1):
						Console.Clear();
						account.account_menu();
						break;
					case (2):
						Console.Clear();
						Console.WriteLine(account + "\nPress any key to continue.");
						Console.ReadKey();
						break;
					default:
						Console.Clear();
						Console.WriteLine("Please choose a valid option");
						break;
				}
			}
		}

		public void bank_menu() // menu for interacting with the different accounts in the bank
		{
			int decision = -1;

			while (true)
			{
				Console.Clear();
				decision = ask_for_int("What would you like to do?\n1: Create a new account\n2: View existing accounts\n0: Exit the app.\n");

				switch (decision)
				{
					case (0):
						Console.WriteLine("Goodbye!");
						return;
					case (1):
						Console.Clear();
						//create_account_menu();
						break;
					case (2):
						Console.Clear();
						get_accounts(); // prints all accounts and allows user to view and edit them
						break;
					default:
						Console.Clear();
						Console.WriteLine("Please choose a valid option");
						break;
				}
			}
		}
	}
}
