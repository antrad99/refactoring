using BankingSystem.Services;
using BankingSystem.Models;

namespace UnitTests
{
    public class AccountServiceTests
    {
        [Fact]
        public void AddAccount()
        {         

            var account = new BankingSystem.Models.Account
            {
                Id = "12345",
                Name = "Test",
                Balance = 0
            };
                 
            var result = AccountService.AddAccount(account);

            Assert.Empty(result);

            var accounts = AccountService.GetAccounts();

            var addedAccount = accounts.FirstOrDefault(x => x.Id == "12345");

            Assert.NotNull(addedAccount);
            Assert.Equal("12345",  addedAccount.Id);
            Assert.Equal("Test", addedAccount.Name);
            Assert.Equal(0, addedAccount.Balance);

        }

        [Fact]
        public void AddAccountAlreadyExists()
        {
            var account = new BankingSystem.Models.Account
            {
                Id = "12346",
                Name = "Test",
                Balance = 0
            };

            var result = AccountService.AddAccount(account);

            Assert.Empty(result);

            var result1 = AccountService.AddAccount(account);

            Assert.NotEmpty(result1);

        }

        [Fact]
        public void DepositMoneyNonNumeric()
        {
            var account = new BankingSystem.Models.Account
            {
                Id = "12347",
                Name = "Test",
                Balance = 0
            };

            AccountService.AddAccount(account);

            var result = AccountService.DepositMoney("12347", "hi");

            Assert.NotEmpty(result);

        }

        [Fact]
        public void DepositMoneyNonPositive()
        {

            var account = new BankingSystem.Models.Account
            {
                Id = "12348",
                Name = "Test",
                Balance = 0
            };

            AccountService.AddAccount(account);

            var result = AccountService.DepositMoney("12347", "-2");

            Assert.NotEmpty(result);

        }

        [Fact]
        public void DepositMoneyOk()
        {
            var account = new BankingSystem.Models.Account
            {
                Id = "12349",
                Name = "Test",
                Balance = 0
            };

            AccountService.AddAccount(account);

            var result = AccountService.DepositMoney("12349", "20");

            Assert.Empty(result);

            var accounts = AccountService.GetAccounts();

            var addedAccount = accounts.FirstOrDefault(x => x.Id == "12349");

            Assert.NotNull(addedAccount);
            Assert.Equal("12349", addedAccount.Id);
            Assert.Equal("Test", addedAccount.Name);
            Assert.Equal(20, addedAccount.Balance);

            var result1 = AccountService.DepositMoney("12349", "40");
            Assert.Equal(60, addedAccount.Balance);
        }

        [Fact]
        public void WithdrawMoneyNonNumeric()
        {
            var account = new BankingSystem.Models.Account
            {
                Id = "1234701",
                Name = "Test",
                Balance = 0
            };

            AccountService.AddAccount(account);

            var result = AccountService.WithdrawMoney("1234701", "hi");

            Assert.NotEmpty(result);

        }

        [Fact]
        public void WithdrawMoneyNonPositive()
        {
            var account = new BankingSystem.Models.Account
            {
                Id = "1234702",
                Name = "Test",
                Balance = 0
            };

            AccountService.AddAccount(account);

            var result = AccountService.WithdrawMoney("1234702", "-2");

            Assert.NotEmpty(result);

        }

        [Fact]
        public void WithdrawMoneyOk()
        {
            var account = new BankingSystem.Models.Account
            {
                Id = "1234703",
                Name = "Test",
                Balance = 100
            };

            AccountService.AddAccount(account);

            var result = AccountService.WithdrawMoney("1234703", "20");

            Assert.Empty(result);

            var accounts = AccountService.GetAccounts();

            var addedAccount = accounts.FirstOrDefault(x => x.Id == "1234703");

            Assert.NotNull(addedAccount);
            Assert.Equal("1234703", addedAccount.Id);
            Assert.Equal("Test", addedAccount.Name);
            Assert.Equal(80, addedAccount.Balance);

            var result1 = AccountService.WithdrawMoney("1234703", "40");
            Assert.Equal(40, addedAccount.Balance);
        }


        [Fact]
        public void WithdrawMoneyInsuficientBalance()
        {
            var account = new BankingSystem.Models.Account
            {
                Id = "1234703A",
                Name = "Test",
                Balance = 10
            };

            AccountService.AddAccount(account);

            var result = AccountService.WithdrawMoney("1234703A", "20");

            Assert.NotEmpty(result);

        }

        [Fact]
        public void GetAccountById()
        {
            var account = new BankingSystem.Models.Account
            {
                Id = "1234704",
                Name = "Test",
                Balance = 100
            };

            AccountService.AddAccount(account);

            var result = AccountService.GetAccountById("1234704");


            var accounts = AccountService.GetAccounts();

            var addedAccount = accounts.FirstOrDefault(x => x.Id == "1234704");

            Assert.NotNull(addedAccount);
            Assert.Equal("1234704", addedAccount.Id);
            Assert.Equal("Test", addedAccount.Name);
            Assert.Equal(100, addedAccount.Balance);

        }


        [Fact]
        public void GetAccountByIdNotFOund()
        {
            var account = new BankingSystem.Models.Account
            {
                Id = "1234705",
                Name = "Test",
                Balance = 100
            };

            AccountService.AddAccount(account);

            var result = AccountService.GetAccountById("1234706");


            var accounts = AccountService.GetAccounts();

            var addedAccount = accounts.FirstOrDefault(x => x.Id == "1234704");

            Assert.Null(addedAccount);

        }

    }
}