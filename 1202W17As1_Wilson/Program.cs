using System;

namespace W17As1_Wilson
{
	class Andrew_MainClass
	{
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
			Andrew_Bank bank = new Andrew_Bank();

			bank.create_new_account("Diana", "William", "22 Authorn", 1234321); // create some accounts to populate the existing accounts
			bank.create_new_account("Kent", "Clarke", "17 Dupont", 32132121);
			bank.create_new_account("Zebbra", "Zlaire", "2 Weston", 98798798);

			bank.bank_menu(); // open up the bank menu

		}
	}
}