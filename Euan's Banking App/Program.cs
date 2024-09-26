using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euan_s_Banking_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank myBank = new Bank(); // creates a bank

            SavingsAccount mySavings = new SavingsAccount("00001", "Euan", 1000m, 20.5m); //creates both accounts
            CurrentAccount myCurrent = new CurrentAccount("00002", "Euan", 200m, 500m);

            myBank.AddAccount(mySavings); //adds the accounts to the bank
            myBank.AddAccount(myCurrent);

            mySavings.DisplayBalance();
            myCurrent.DisplayBalance();

            mySavings.Withdraw(100.5m);
            myCurrent.Deposit(50m);

            mySavings.ApplyInterest();

            myBank.Transfer("00001", "00002", 150m);

            // Display final balances
            mySavings.DisplayBalance();
            myCurrent.DisplayBalance();

            // Print transaction histories
            Console.WriteLine("\nSavings Account Transaction History:");
            mySavings.PrintTransactionHistory();

            Console.WriteLine("\nCurrent Account Transaction History:");
            myCurrent.PrintTransactionHistory();
        }
    }
}
