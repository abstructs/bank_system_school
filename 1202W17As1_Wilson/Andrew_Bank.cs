using System;
namespace W17As1_Wilson
{
	public class Andrew_Bank
	{
		protected const decimal INTEREST_RATE = 0.01m; // constants defined by bank
		protected const decimal DEBIT_FEE = 5.0m; // use decimal for money to prevent rounding errors 
		protected const decimal ANNUAL_FEE = 60.00m;

		Andrew_Account[] accounts = new Andrew_Account[10]; // stores up to 10 accounts

		int accounts_size = 0;

		public Andrew_Bank()
		{
			
		}

		public Andrew_Account create_new_account() // create a new account with default values 
		{
			accounts[accounts_size] = new Andrew_Account(); // create a new account

			return accounts[accounts_size++];
		}

		public Andrew_Account create_new_account(string first_name, string last_name, string home_address, int s_i_n) // create a new account with default values
		{
			accounts[accounts_size] = new Andrew_Account(first_name, last_name, home_address, s_i_n); // create a new account
			return accounts[accounts_size++];
		}

		public void list_of_accounts() // lists all accounts by name who owns the account and index number + 1
		{
			for (int i = 0; i < accounts_size - 1; i++)
			{
				Console.WriteLine("{0}: {1}", i + 1, accounts[i].client_info());
			}
		}

		public void bank_accounts_menu() // view list of accounts currently in bank
		{
			int decision = -1;

			while (true)
			{
				Console.WriteLine("Which account would you like to view/edit?\n");

				Console.WriteLine("0: Back\n");

				list_of_accounts(); // list all the current accounts

				decision = ask_for_int("");

				if (decision > 0 && decision < accounts_size) // make sure the account number exists
				{
					Console.Clear();
					accounts[decision - 1].account_menu(); // get the menu for that account
					continue;
				}

				if (decision == 0)
				{
					return; // go back
				}

				Console.Clear();
				Console.WriteLine("Please choose a valid option\n");

			}

		}

		public static int ask_for_int(string message) // method for allowing us to get an integer number from user
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

		public void create_account_menu()
		{	
			int decision = -1;

			while (true)
			{

				decision = ask_for_int("1: Create a new account with user defined values.\n2: Create a new account with" +
								  		" default values.\n0: Back");

				switch (decision)
				{
					case(0):
						return;
					case(1):
						// TODO: get user info, save it
						string first, last, home;
						int sin;
						Console.Clear();
						Console.WriteLine("First Name: ");
						first = Console.ReadLine();

						Console.WriteLine("Last Name: ");
						last = Console.ReadLine();

						Console.WriteLine("Home Address: ");
						home = Console.ReadLine();

						sin = ask_for_int("Social Security Number: ");

						Andrew_Account acc1 = create_new_account(first, last, home, sin);

						Console.WriteLine("Account created!");

						acc1.account_menu();

						Console.ReadKey();

						return;
					case(2):
						Console.Clear();
						Andrew_Account acc2 = create_new_account();

						Console.WriteLine("Account created!");

						acc2.account_menu();
						return;
					default:
						Console.WriteLine("Invalid option");
						Console.ReadKey();
						break;	
				}

				Console.Clear();
				Console.WriteLine("Please choose a valid option\n");

			}
		}

		public void bank_menu() // menu for interacting with the different accounts in the bank, also entry menu to bank
		{
			int decision = -1;

			while (true)
			{
				Console.Clear();
				decision = ask_for_int("What would you like to do?\n1: Create a new account\n" +
				                       "2: View existing accounts\n0: Exit the app.\n");

				switch (decision)
				{
					case (0):
						Console.WriteLine("Goodbye!");
						return;
					case (1):
						Console.Clear();
						create_account_menu();
						break;
					case (2):
						Console.Clear();
						bank_accounts_menu(); // prints all accounts and allows user to view and edit them
						break;
					default:
						Console.Clear();
						Console.WriteLine("Please choose a valid option");
						Console.ReadKey();
						break;
				}
			}
		}
	}
}
