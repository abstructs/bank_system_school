using System;
namespace W17As1_Wilson
{
	public class Andrew_Bank
	{
		protected const decimal INTEREST_RATE = 0.01m; // constants defined by bank
		protected const decimal DEBIT_FEE = 5.0m; // use decimal for money to prevent rounding errors 
		protected const decimal ANNUAL_FEE = 60.00m;

		private string bank_name;
		private string manager_first_name;
		private string manager_last_name;

		private static int account_limit = 4; // limit of accounts

		Andrew_Account[] accounts = new Andrew_Account[account_limit]; // stores up to 10 accounts in an array

		int accounts_size = 0;

		public Andrew_Bank()
		{
			this.bank_name = "Bank of George Brown";
			this.manager_first_name = "Andrew";
			this.manager_last_name = "Wilson";
		}

		public Andrew_Bank(string bank_name, string manager_first_name, string manager_last_name)
		{
			this.bank_name = bank_name;
			this.manager_first_name = manager_first_name;
			this.manager_last_name = manager_last_name;
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
			for (int i = 0; i < accounts_size; i++)
			{
				Console.Write("{0}: {1}", i + 1, accounts[i].client_info() + "");
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

				if (decision > 0 && decision < accounts_size + 1) // make sure the account number exists
				{
					Console.Clear();
					accounts[decision - 1].account_menu(); // get the menu for that account
					continue;
				}

				if (decision == 0)
				{
					return; // go back
				}

				// default

				Console.Clear();
				Console.WriteLine("Please choose a valid option.\nPress any key to continue...");
				Console.ReadKey();
				Console.Clear();

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
			int menu_decision = -1;

			Andrew_Account account;
			while (true)
			{

				decision = ask_for_int("Welcome to the account creation menu!\n\nHow would you like to create an account?" +
				                       "\n1: Create a new account with user defined values.\n2: Create a new account with" +
								  		" default values.\n0: Back");

				if (decision != 0 && accounts_size == account_limit) // if the user goes back, don't show error
				{
					Console.Clear();
					Console.WriteLine("Sorry! Account limit reached!\n\nPress any key to continue...");
					Console.ReadKey();
					return;
				}

				switch (decision)
				{
					case(0):
						return;
					case(1):
						string first, last, home;
						int sin;
							
						Console.Clear();	

						Console.WriteLine("Creating a new account, please enter appropriate values below.\n");

						Console.WriteLine("First Name: ");
						first = Console.ReadLine();

						Console.WriteLine("Last Name: ");
						last = Console.ReadLine();

						Console.WriteLine("Home Address: ");
						home = Console.ReadLine();

						sin = ask_for_int("Social Security Number: ");

						account = create_new_account(first, last, home, sin);

						Console.Clear();

						Console.WriteLine("Account created!");

						menu_decision = ask_for_int("Would you like to go to the account menu now?\n1: Yes \n2: No");

						if (menu_decision == 1)
						{
							Console.Clear();
							account.account_menu();	
						}

						return;
					case(2):
						Console.Clear();

						account = create_new_account();

						Console.WriteLine("Account created!");

						menu_decision = ask_for_int("Would you like to go to the account menu now?\n1: Yes\n2: No");
						if (menu_decision == 1)
						{
							Console.Clear();
							account.account_menu();
						}

						return;
					default:
						Console.Clear();
						Console.WriteLine("Please choose a valid option.\nPress any key to continue...");
						Console.ReadKey();
						Console.Clear();
						break;	
				}
			}
		}

		public void bank_menu() // menu for interacting with the different accounts in the bank, also entry menu to bank
		{
			greeting();

			int decision = -1;

			while (true)
			{
				Console.Clear();
				decision = ask_for_int("What would you like to do?\n1: Create a new account\n" +
				                       "2: View existing accounts\n3: View greeting again\n0: Exit the app.\n");

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
					case(3):
						greeting();
						break;
					default:
						Console.Clear();
						Console.WriteLine("Please choose a valid option.\nPress any key to continue...");
						Console.ReadKey();
						Console.Clear();
						break;
				}
			}
		}

		public void greeting()
		{
			Console.Clear();
			Console.WriteLine("Welcome To {0} - <G><B><C>", bank_name);
			Console.WriteLine("___________________________________________\n");
			Console.WriteLine("Manager Name: {0} {1}\nStudent Number: 101069860", manager_last_name, manager_first_name);
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}
	}
}
