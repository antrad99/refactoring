using BankingSystem.Models;
using BankingSystem.Services;
using System.Security.Principal;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Add Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Display Account Details");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAccount();
                        break;
                    case "2":
                        DepositMoney();
                        break;
                    case "3":
                        WithdrawMoney();
                        break;
                    case "4":
                        DisplayAccountDetails();
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void AddAccount()
        {
            Console.WriteLine("Enter Account ID:");
            var id = Console.ReadLine();

            Console.WriteLine("Enter Account Holder Name:");
            //Changed to ReadLine, otherwise it saves numbers rather than the actual string
            var name = Console.ReadLine();

            var account = new Account { Id = id, Name = name, Balance = 0 };

            //var accountService = new AccountService();
            var result = AccountService.AddAccount(account);

            if (result.Count == 0) 
                Console.WriteLine("Account added successfully.");
            else
                Console.WriteLine(string.Join(";", result));
        }

        static void DepositMoney()
        {
            Console.WriteLine("Enter Account ID:");
            string? id = Console.ReadLine();

            Console.WriteLine("Enter Amount to Deposit:");
            string? amount = Console.ReadLine();

            var result = AccountService.DepositMoney(id, amount);

            if (result.Count == 0)
                Console.WriteLine("Deposit successful.");
            else
                Console.WriteLine(string.Join(";", result));

        }

        //The bugs with incorrect transactions was when negative value was added.
        static void WithdrawMoney()
        {
            Console.WriteLine("Enter Account ID:");
            string? id = Console.ReadLine();

            Console.WriteLine("Enter Amount to Withdraw:");
            string? amount = Console.ReadLine();

            var result = AccountService.WithdrawMoney(id, amount);

            if (result.Count == 0)
                Console.WriteLine("Withdrawal successful.");
            else
                Console.WriteLine(string.Join(";", result));

        }

        static void DisplayAccountDetails()
        {
            Console.WriteLine("Enter Account ID:");
            string? id = Console.ReadLine();

            if (id == null)
            {
                Console.WriteLine("Id cannot be null.");
                return;
            }

            var account = AccountService.GetAccountById(id);

            if (account == null)
            {
                Console.WriteLine("Account not found.");
            }
            else
            {
                Console.WriteLine($"Account ID: {account.Id}");
                Console.WriteLine($"Account Holder: {account.Name}");
                Console.WriteLine($"Balance: {account.Balance}");
            }
        }
    }

    /* Refacted, moved into its own file
    class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }
    */
}

