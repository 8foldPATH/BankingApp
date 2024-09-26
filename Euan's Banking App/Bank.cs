using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euan_s_Banking_App
{
    public class Bank //this is used to add accounts, remove accounts, and transfer money between them
    {

        private readonly List<Account> _accounts; //makes a list of accounts

        public Bank()
        {
            _accounts = new List<Account>();
        }

        protected List<Account> Accounts => _accounts; //uses encapsulation

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public void RemoveAccount(string accountNumber)
        {
            Account? accountToRemove = null; //initialises accountToRemove as an Account variable with no value yet

            foreach (Account account in Accounts) //iterates through all accounts in the list
            {
                if (account.AccountNumber == accountNumber) 
                {
                    accountToRemove = account;
                    break; //exits the loop if the account number for the account is the same as the number being searched for
                }
            }
            if (accountToRemove != null)
            {
                Accounts.Remove(accountToRemove); //removes the account once accountToRemove is no longer null
            }
        }

        public Account? GetAccount(string accountNumber)
        {
            foreach (var account in Accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }
            return null;
        }
    
        public bool Transfer(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            var fromAccount = GetAccount(fromAccountNumber);
            var toAccount = GetAccount(toAccountNumber);

            if (fromAccount == null || toAccount == null)
            {
                Console.WriteLine("One or more of the accounts could not be found.");
                return false;
            }

            if (fromAccount?.Balance < amount)
            {
                Console.WriteLine("There are not enough funds in the source account.");
                return false;
            }

            fromAccount?.Withdraw(amount);
            toAccount?.Deposit(amount);

            fromAccount?.AddTransaction($"Transferred {amount} to {toAccountNumber}.");
            toAccount?.AddTransaction($"Received {amount} from {fromAccountNumber}.");

            Console.WriteLine($"You have successfully transferred {amount} from your account {fromAccountNumber} to {toAccountNumber}.");
            return true;
        }
    }
}
