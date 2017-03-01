using System;
namespace W17As1_Wilson
{
	public class Andrew_Account : Andrew_Client
	{


		string month_of_report; // date report was made for
		int year_of_report;

		public decimal opening_balance = 0m; // information about state of bank account
		public decimal monthly_deposit = 0m;
		public decimal monthly_withdrawal = 0m;
		public int debit_transactions = 0;

		// constructors

		public Andrew_Account(string first_name, string last_name, string home_address, int s_i_n)
		{
			this.first_name = first_name;
			this.last_name = last_name;
			this.home_address = home_address;
			this.s_i_n = s_i_n;
			this.year_of_report = DateTime.Now.Year;
			this.month_of_report = new DateTime(this.year_of_report, DateTime.Now.Month, 1).ToString("MMM");
		}

		public Andrew_Account() // default values
		{
			this.year_of_report = DateTime.Now.Year;
			this.month_of_report = new DateTime(this.year_of_report, DateTime.Now.Month, 1).ToString("MMM");
			this.first_name = "Default_Name";
			this.last_name = "Default_Name";
			this.home_address = "Default_Address";
			this.s_i_n = 12345678;
		}

		public void account_menu()
		{
			int decision = -1;

			while (true)
			{
				Console.WriteLine("What would you like to do?");
				decision = ask_for_int("1: View client information.\n2: Enter Client Information.\n3: Enter Bank Information.\n0: Back.");

				switch (decision)
				{
					case (0): // go back
						Console.Clear();
						return;
					case(1): // show user info
						Console.WriteLine(client_info() + "\n" + bank_info()); // uses this classes overridden tostring method
						Console.ReadKey();
						break;
					case (2):
						set_user_info(); // user can input values for client information
						break;
					case (3):
						set_bank_info(); // user can input values for bank information
						break;
					default:
						Console.Clear();
						Console.WriteLine("Please choose a valid option");
						Console.ReadKey();
						break;
				}

				Console.Clear();
			}
		}

		private static decimal ask_for_decimal(string message) // prompts the user for a decimal ensuring the right number is returned
		{
			decimal result;

			while (true)
			{
				Console.WriteLine(message); // write message
				if (Decimal.TryParse(Console.ReadLine(), out result)) // make sure user inputs a decimal number
				{
					if (result < 0)
					{
						Console.WriteLine("Please enter a positive value.");
						continue;
					}
					return result; // return result to the user
				}
				else
				{
					Console.WriteLine("Please enter a positive decimal value.");
				}
			}
		}

		private void set_bank_info() // allows the user to change information about an account
		{
			Console.Clear();
			int decision = -1;

			while (true) // run until user types 0
			{
				Console.WriteLine("Filing monthly report.");
				Console.WriteLine("What would you like to input?\n1: Opening Balance. Currently: {0:N}.\n" +
				                  "2: Monthly Deposit. Currently: {1:N}.\n3: Monthly Withdrawal. Currently: {2:N}.\n" +
				                  "4: Debit Transaction Count. Currently: {3:N0}.\n5: Month of Report: {4}\n" +
				                  "6: Year of Report. Currently: {5}\n0: Back", opening_balance, monthly_deposit,
				                  monthly_withdrawal, debit_transactions, month_of_report, year_of_report);
				
				decision = ask_for_int("");

				Console.Clear();

				switch (decision)
				{
					case(0): // finish entering data
						return;
					case(1):
						opening_balance = ask_for_decimal("What was the opening balance for the month?");
						break;
					case (2):
						monthly_deposit = ask_for_decimal("How much money has been deposited?");
						break;
					case (3):
						monthly_withdrawal = ask_for_decimal("How much money has been withdrawn?");
						break;
					case (4):
						debit_transactions = ask_for_int("How many transactions has there been?");
						break;
					case (5):
						while (true) // force user to input a value between 1 and 12
						{
							int month;
							if (year_of_report == DateTime.Now.Year) // if the report year is the current year we only want to allow months up to the current month
							{
								month = ask_for_int(string.Format("What month is the report for? Enter a number from 1-{0}", DateTime.Now.Month));
							}
							else
							{
								month = ask_for_int("What month is the report for? Enter a number 1-12");
							}

							if (month > 0 && month <= 12)
							{
								// make sure month entered is less than current month if year is the same
								if (year_of_report == DateTime.Now.Year && DateTime.Now.Month < month)  
								{
									string error_month= new DateTime(year_of_report, month, 1).ToString("MMM");
									Console.Clear();
									Console.WriteLine("Cannot make reports ahead of the current date.\n" +
									                  "You entered {0} {1}\nThe current date is: {2} {3}" +
									                  "\nPlease enter a valid month:", year_of_report, error_month,
									                  DateTime.Now.Year, DateTime.Now.ToString("MMM"));
								}
								else
								{
									month_of_report = new DateTime(year_of_report, month, 1).ToString("MMM");
									break;
								}
							}
							else
							{
								Console.WriteLine("Invalid number.");
							}
						}
						break;
					case(6):
						while (true) // force user to input a value between 1 and 12
						{
							int year = ask_for_int(string.Format("What year is the report for? Enter a number 2000-{0}", DateTime.Now.Year));

							if (year >= 2000 && year <= DateTime.Now.Year)
							{
								year_of_report = year;
								break;
							}
							else
							{
								Console.Clear();
								Console.WriteLine("Invalid year. Please input a valid year:");
							}
						}
						break;
					default:
						Console.WriteLine("Something went wrong :-( !");
						Console.ReadKey();
						return;
				}

				Console.Clear();
			}
		}



		public void set_monthly_report(decimal opening_balance, decimal monthly_deposit,  // default constructor
		                               decimal monthy_withdrawal, int debit_transactions) // sets date values for current month
		{
			this.year_of_report = DateTime.Now.Year;
			this.month_of_report = new DateTime(this.year_of_report, DateTime.Now.Month, 1).ToString("MMM");
			this.opening_balance = opening_balance;
			this.monthly_deposit = monthly_deposit;
			this.monthly_withdrawal = monthy_withdrawal;
			this.debit_transactions = debit_transactions;
			return;
		}

		public void set_monthly_report(decimal opening_balance, decimal monthly_deposit,
		                               decimal monthly_withdrawal, int debit_transactions, int year, int month) // overloaded constructor that also sets date values
		{
			this.year_of_report = year;
			this.month_of_report = new DateTime(year, month, 1).ToString("MMM");
			this.opening_balance = opening_balance;
			this.monthly_deposit = monthly_deposit;
			this.monthly_withdrawal = monthly_withdrawal;
			this.debit_transactions = debit_transactions;
			return;
		}

		public void set_monthly_report(int opening_balance, int monthly_deposit,
		                               int monthly_withdrawal, int debit_transactions, int year, int month) // overloaded constructor to deal with integer values for money
		{
			this.year_of_report = year;
			this.month_of_report = new DateTime(year, month, 1).ToString("MMM");
			this.opening_balance = (decimal) opening_balance;
			this.monthly_deposit = (decimal) monthly_deposit;
			this.monthly_withdrawal = (decimal) monthly_withdrawal;
			this.debit_transactions = debit_transactions;
			return;
		}

		// methods that calculate a value and return another value

		private decimal calculate_interest_amount(decimal balance) // calculates the amount of interest the client as earned for the month
		{
			decimal interest_amount = balance * INTEREST_RATE;

			return interest_amount;
		}

		private decimal calculate_monthly_fees() // calculates the amount of fees for the account
		{
			decimal fees = DEBIT_FEE * debit_transactions;

			if (month_of_report.Equals("Jan")) // charge annual fee in first month of the year
			{ 
				fees += ANNUAL_FEE;
			}

			return fees;
		}

		private decimal calulate_closing_balance() // calculates the closing balance of the account for the month
		{
			decimal transaction_amount = monthly_deposit - monthly_withdrawal; // calculate the amount of all withdrawals and deposits

			decimal new_balance = opening_balance - calculate_monthly_fees() + transaction_amount; // deduct fees 

			new_balance += calculate_interest_amount(new_balance); // calculate interest amount on net balance of the month

			return new_balance; // return the new balance
		}

		// class overrides

		protected string bank_info()
		{
			return string.Format("Opening balance is: {0:N}\nDeposit amount is: {1:N}\nWithdrawal " +
										 "amount is {2:N}\nFees for the month are: {3:N}\nClosing balance is: {4:N}\n",
										 opening_balance, monthly_deposit, monthly_withdrawal, calculate_monthly_fees(), calulate_closing_balance());
		}

		public override string ToString() // returns a string of all the values for the account class
		{
			return client_info() + bank_info();
		}
	}
}
