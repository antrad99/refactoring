using BankingSystem.Models;

namespace BankingSystem.Services
{
    public static class AccountService
    {
        //Service to manage the Bank Accounts

        //local list of accounts
        private static List<Account> _accounts = new List<Account>();


        //return the list of accounts
        public static List<Account> GetAccounts() {  return _accounts; }

        //Add an account to the local list and return the list of errors
        public static List<string> AddAccount(Account account)
        {
            var errors = new List<string>();

            if (account == null)
            {
                errors.Add("Account cannot be null.");
                return errors;
            }

            if (_accounts.FirstOrDefault(x => x.Id == account.Id) != null)
                errors.Add("This account already exists.");

            if (string.IsNullOrEmpty(account.Id))
                errors.Add("Id cannot be empty.");

            if (string.IsNullOrEmpty(account.Name))
                errors.Add("Name cannot be empty");

            if (errors.Count > 0)
                return errors;

            _accounts.Add(account);
            return errors;
        }

        //deposit money to the account id and return the list of errors
        public static List<string> DepositMoney(string? id, string? amount)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(id) || (string.IsNullOrEmpty(amount)))
            {
                errors.Add("Id and/or amount cannot be null.");
                return errors;
            }

            double _amount;
            bool isDouble = Double.TryParse(amount, out _amount);
            if (!isDouble)
            {
                errors.Add("Amount must be numeric.");
                return errors;
            }

            if (_amount < 0)
            {
                errors.Add("Amount must be greater than zero.");
                return errors;
            }

            var account = _accounts.FirstOrDefault(x => x.Id == id);
            if (account == null)
            {
                errors.Add("Account not found.");
                return errors;
            }

            account.Balance += _amount;

            return errors;
        }

        //withdraw money to the account id and return the list of errors
        public static List<string> WithdrawMoney(string? id, string? amount)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(id) || (string.IsNullOrEmpty(amount)))
            {
                errors.Add("Id and/or amount cannot be null.");
                return errors;
            }

            double _amount;
            bool isDouble = Double.TryParse(amount, out _amount);
            if (!isDouble)
            {
                errors.Add("Amount must be numeric.");
                return errors;
            }

            if (_amount < 0)
            {
                errors.Add("Amount must be greater than zero.");
                return errors;
            }

            var account = _accounts.FirstOrDefault(x => x.Id == id);
            if (account == null)
            {
                errors.Add("Account not found.");
                return errors;
            }

            if (account.Balance < _amount)
            {
                errors.Add("Insufficient balance.");
                return errors; 
            }

            account.Balance -= _amount;

            return errors;
        }

        //return null if account id not found
        public static Account? GetAccountById(string id)
        {
            return _accounts.FirstOrDefault(x => x.Id == id);
        }

    }
}
