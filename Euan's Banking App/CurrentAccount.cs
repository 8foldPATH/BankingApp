using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euan_s_Banking_App
{
    public class CurrentAccount : Account
    {
        private readonly decimal _overdraftLimit;
        public CurrentAccount(string accountNumber, string accountHolder, decimal balance, decimal overdraftLimit)
            : base(accountNumber, accountHolder, balance) 
        { 
            _overdraftLimit = Math.Abs(overdraftLimit); //e.g. 1000
        }

        public decimal OverdraftLimit  => _overdraftLimit; 

        public override void Withdraw(decimal amount)
        {
            //e.g. balance is 100, amount is 500, overdraft is 1000
            if (Math.Abs((Balance - amount)) > OverdraftLimit)
            {
                Console.WriteLine($"You cannot withdraw this amount. Your overdraft limit is {OverdraftLimit}.");
            } 
            else
            {
                base.Withdraw(amount);
                Console.WriteLine($"You have just withdrawn {amount}.");
            }
        }

        public override void DisplayBalance()
        {
            base.DisplayBalance();
            Console.WriteLine($"Your current overdraft limit is {OverdraftLimit}.");
        }
    }
}