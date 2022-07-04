using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount;

namespace BankLibrary.Services
{
    public class BankServices
    {

        public Account VerifyUser(Bank bank, string userName, string password)
        {
            string accountJsonPath = @"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Accounts.json";
            string accountJsonString = File.ReadAllText(accountJsonPath);
            var accountList = JsonConvert.DeserializeObject<List<Account>>(accountJsonString);

            foreach (var acc in accountList)
            {
                if (acc.BankID == bank.BankID)
                {
                    if (acc.UserName.Equals(userName) && acc.password.Equals(password))
                    {
                        return acc;
                    }
                }
                else
                {
                    Console.WriteLine("Access denied. User doesn't exist.");
                }

            }

            return null;
        }

        public static void DepositTransact(double amount, Account x)
        {
            string transactJsonPath = @"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Transactions.json";
            string transactJsonString = File.ReadAllText(transactJsonPath);
            var transactList = JsonConvert.DeserializeObject<List<Transaction>>(transactJsonString);


            Transaction t = new Transaction();

            t.Type = "Deposit";
            t.ID = "TXN" + x.BankID + x.ID + DateTime.Now.ToString();
            t.Amount = amount;
            t.From = x.ID;
            t.Time = DateTime.Now.ToLocalTime();

            transactList.Add(t);

            var transaction = JsonConvert.SerializeObject(transactList);
            File.WriteAllText(@"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Transactions.json", transaction);
        }

        public static void WithdrawTransact(double amount, Account x)
        {
            string transactJsonPath = @"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Transactions.json";
            string transactJsonString = File.ReadAllText(transactJsonPath);
            var transactList = JsonConvert.DeserializeObject<List<Transaction>>(transactJsonString);


            Transaction t = new Transaction();

            t.Type = "Withdraw";
            t.ID = "TXN" + x.BankID + x.ID + DateTime.Now.ToString();
            t.Amount = amount;
            t.From = x.ID;
            t.Time = DateTime.Now.ToLocalTime();

            transactList.Add(t);

            var transaction = JsonConvert.SerializeObject(transactList);
            File.WriteAllText(@"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Transactions.json", transaction);
        }

        public static void TransferTransact(double amount, Account x, Account y)
        {
            string transactJsonPath = @"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Transactions.json";
            string transactJsonString = File.ReadAllText(transactJsonPath);
            var transactList = JsonConvert.DeserializeObject<List<Transaction>>(transactJsonString);


            Transaction t = new Transaction();

            t.Type = "Transfer";
            t.ID = "TXN" + x.BankID + x.ID + DateTime.Now.ToString();
            t.Amount = amount;
            t.From = x.ID;
            t.To = y.ID;
            t.Time = DateTime.Now.ToLocalTime();

            transactList.Add(t);

            var transaction = JsonConvert.SerializeObject(transactList);
            File.WriteAllText(@"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Transactions.json", transaction);
        }

        public static double SameBankRtgsTransfer(double amount)
        {
            double rtgs = 0 * amount;
            return rtgs;
        }

        public static double SameBankImpsTransfer(double amount)
        {
            double imps = 0.05 * amount;
            return imps;
        }

        public static double DifferentBankRtgsTransfer(double amount)
        {
            double rtgs = 0.02 * amount;
            return rtgs;
        }

        public static double DifferentBankImpsTransfer(double amount)
        {
            double imps = 0.06 * amount;
            return imps;
        }



        public static double currencyConvert(double amount, string type)
        {

            switch (type)
            {
                case "INR":
                    amount *= 1;
                    break;
                case "USD":
                    amount *= 78.50;
                    break;
                case "AUD":
                    amount *= 54.30;
                    break;
                case "EUR":
                    amount *= 83.10;
                    break;
                case "PND":
                    amount *= 96.40;
                    break;
                default:
                    Console.WriteLine("Enter a valid currency type.");
                    break;
            }
            return amount;
        }

        public static void createUserAccount(Bank bank, List<Account> accountList, string name, string role, string userName, string password)
        {
         
            int count = accountList.Count();
            int id = accountList[count - 1].ID;

            Account a = new Account();
            a.Name = name;
            a.Role = role;
            a.UserName = userName;
            a.password = password;
            a.Balance = 0;
            a.BankID = 1;
            a.ID = ++id;
            a.AccountNumber = a.Name.Substring(0, 3) + DateTime.Now.ToString("yyyyMMdd");
            a.IfscCode = bank.IfscCode;

            accountList.Add(a);

            var newAccount = JsonConvert.SerializeObject(accountList);
            File.WriteAllText(@"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Accounts.json", newAccount);
        }

        public static bool updateOrDeleteUser(List<Account> accountList, int AccountId, string option, bool check)
        {


            if (option == "1")
            {   
                foreach (var acc in accountList)
                {
                    if (acc.ID == AccountId)
                    {
                        // accountList.Remove(acc);
                        Console.WriteLine("Enter new name to update: ");
                        acc.Name = Console.ReadLine();

                        check = true;

                    }

                }
            }

            else if (option == "2")
            {
                int index = 0, currentObjectCount = 0;
                if(AccountId == 1)
                {
                    Console.WriteLine("Warning: Admin Id. Can't be deleted.");
                }
                else
                {
                    foreach (var acc in accountList)
                    {
                        if (acc.ID == AccountId)
                        {
                            index = currentObjectCount;
                            check = true;

                        }
                        currentObjectCount++;
                    }

                    accountList.Remove(accountList[index]);
                }

            }
            

            else
                Console.WriteLine("Invalid input");

            var UpdatedAccount = JsonConvert.SerializeObject(accountList);
            File.WriteAllText(@"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Accounts.json", UpdatedAccount);

            return check;
        }

        public static void viewTransactionHistory(Transaction t)
        {
            if (t.Type == "Deposit")
            {
                Console.WriteLine("ID: " + t.ID);
                Console.WriteLine("Amount deposited: " + t.Amount);
                Console.WriteLine("Time: " + t.Time);
                Console.WriteLine("\n");
            }
            else if (t.Type == "Withdraw")
            {
                Console.WriteLine("ID: " + t.ID);
                Console.WriteLine("Amount withdrawn: " + t.Amount);
                Console.WriteLine("Time: " + t.Time);
                Console.WriteLine("\n");

            }
            else if (t.Type == "Transfer")
            {
                Console.WriteLine("ID: " + t.ID);
                Console.WriteLine("Amount transferred: " + t.Amount);
                Console.WriteLine("Transaction Made By: " + t.From);
                Console.WriteLine("Made To: " + t.To);
                Console.WriteLine("Time: " + t.Time);
                Console.WriteLine("\n");
            }

        }


    }


}