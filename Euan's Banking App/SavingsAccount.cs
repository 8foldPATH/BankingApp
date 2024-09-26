using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euan_s_Banking_App
{
    public class SavingsAccount : Account
    {
        private readonly decimal _interestRate;

        public SavingsAccount(string accountNumber, string accountHolder, decimal balance, decimal interestRate)
            : base(accountNumber, accountHolder, balance)
        {
            _interestRate = interestRate;
        }
        public decimal InterestRate => _interestRate;

        public void ApplyInterest()
        {
            decimal interest = (Balance * InterestRate / 100); //need to find if InterestRate or _interestRate is better
            Deposit(interest);
        }
        public override void DisplayBalance()
        {
            base.DisplayBalance();
            Console.WriteLine($"Your current interest rate is {InterestRate}");
        }

        public override void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine($"You cannot withdraw that amount because your balance is {Balance}");
            }
            else
            {
                base.Withdraw(amount);
                Console.WriteLine($"You have withdrawn {amount}. Your new balance is {Balance}.");
            }
        }
    }
}