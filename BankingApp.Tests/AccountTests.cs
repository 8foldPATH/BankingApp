using Xunit;
using Euan_s_Banking_App;

namespace BankingApp.Tests
{
    public class AccountTests
    {
        [Fact]
        public void Deposit_PositiveAmount_IncreasesBalance()
        {
            // Arrange
            var account = new SavingsAccount("00001", "Euan", 1000m, 0.05m);

            // Act
            account.Deposit(200m);

            Assert.Equal(1200m, account.Balance);
        }
    }
}