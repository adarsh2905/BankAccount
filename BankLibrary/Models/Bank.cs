using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Bank
    {
        public string Name { get; set; }
        public string IfscCode { get; set; }

        public int BankID { get; set; }

        //public Account VerifyUser(string userName, string password)
        //{
        //    string accountJsonPath = @"C:\Work\Training\DotNet\BankAccount\BankAccount\Data\Accounts.json";
        //    string accountJsonString = System.IO.File.ReadAllText(accountJsonPath);
        //    var accountList = JsonConvert.DeserializeObject<List<Account>>(accountJsonString);

        //    foreach (var acc in accountList)
        //    {
        //        if(acc.BankID == BankID)
        //        {
        //            if (acc.UserName.Equals(userName) && acc.password.Equals(password))
        //            {
        //                return acc;
        //            }                    
        //        }
        //        else
        //        {
        //            Console.WriteLine("Access denied. User doesn't exist.");
        //        }

        //    }
        //    return null;
        //}




        //public void Deposit(double amount, Account account)
        //{
        //    account.Balance += amount;

           
        //}



        //public void Withdraw(double amount, Account account)
        //{
         
        //    if(account.Balance < amount)
        //    {
        //        Console.WriteLine("Insufficient balance in account to perform this transaction.");

        //    } else
        //    {
        //        account.Balance -= amount;
            
        //    }

        //}



        //public void Transfer(double amount, Account sourceAccount, Account destinationAccount)
        //{
        //    if (sourceAccount.BankID == destinationAccount.BankID)
        //    {
        //        if (amount < sourceAccount.Balance)
        //        {
        //            string input;
        //            do
        //            {
        //                Console.WriteLine("Press 'a' for RTGS, and 'b' for IMPS transfer");
        //                var x = Console.ReadLine()[0];

        //                destinationAccount.Balance += amount;

        //                if (x == 'a')
        //                {
        //                    double rtgs = SameBankRtgsTransfer(amount);
        //                    sourceAccount.Balance -= amount - rtgs;
        //                }
        //                else if (x == 'b')
        //                {
        //                    double imps = SameBankImpsTransfer(amount);
        //                    sourceAccount.Balance -= amount - imps;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid input.");
        //                }

        //                Console.WriteLine("Press '1' to continue, or press any other key to exit.");
        //                input = Console.ReadLine();
        //            } while (input == "1");
                    


        //        }
        //        else
        //        {
        //            Console.WriteLine("Insufficient balance in this account to perform this transaction.");
        //        }

        //    }

        //    else
        //    {
        //        if (amount < sourceAccount.Balance)
        //        {

        //            Console.WriteLine("Press 'a' for RTGS, and 'b' for IMPS transfer");
        //            var x = Console.ReadLine()[0];

        //            destinationAccount.Balance += amount;

        //            if (x == 'a')
        //            {
        //                double rtgs = DifferentBankRtgsTransfer(amount);
        //                sourceAccount.Balance -= amount - rtgs;
        //            }
        //            if (x == 'b')
        //            {
        //                double imps = DifferentBankImpsTransfer(amount);
        //                sourceAccount.Balance -= amount - imps;
        //            }


        //        }
        //        else
        //        {
        //            Console.WriteLine("Insufficient balance in this account to perform this transaction.");
        //        }

        //    }

        //    TransferTransact(amount, sourceAccount, destinationAccount);

        //}

        //public void TransferTransact(double amount, Account x, Account y)
        //{
        //    string transactJsonPath = @"C:\Work\Training\DotNet\BankAccount\BankAccount\Data\Transactions.json";
        //    string transactJsonString = System.IO.File.ReadAllText(transactJsonPath);
        //    var transactList = JsonConvert.DeserializeObject<List<Transaction>>(transactJsonString);

        //    int id = transactList.Count();

        //    Transaction t = new Transaction();
        //    t.ID = ++id;
        //    t.Amount = amount;
        //    t.MadeBy = x.ID;
        //    t.MadeTo = y.ID;
        //    t.Time = DateTime.Now.ToLocalTime();

        //    transactList.Add(t);

        //    var transaction = Newtonsoft.Json.JsonConvert.SerializeObject(transactList);
        //    System.IO.File.WriteAllText(@"C:\Work\Training\DotNet\BankAccount\BankAccount\Data\Transactions.json", transaction);
        //}

        //public double SameBankRtgsTransfer(double amount)
        //{
        //    double rtgs = 0 * amount;
        //    return rtgs;
        //}

        //public double SameBankImpsTransfer(double amount)
        //{
        //    double imps = 0.05 * amount;
        //    return imps;
        //}

        //public double DifferentBankRtgsTransfer(double amount)
        //{
        //    double rtgs = 0.02 * amount;
        //    return rtgs;
        //}

        //public double DifferentBankImpsTransfer(double amount)
        //{
        //    double imps = 0.06 * amount;
        //    return imps;
        //}

        //public static void createUserAccount()
        //{
 
        //    string accountJsonPath = @"C:\Work\Training\DotNet\BankAccount\BankAccount\Data\Accounts.json";
        //    string accountJsonString = System.IO.File.ReadAllText(accountJsonPath);
        //    var accountList = JsonConvert.DeserializeObject<List<Account>>(accountJsonString);


        //    int count = accountList.Count();
        //    int id = accountList[count - 1].ID;

        //    Account a = new Account();
        //    Console.WriteLine("Enter new account holder's name: ");
        //    a.Name = Console.ReadLine();
        //    Console.WriteLine("Enter the role: (staff/customer)");
        //    a.Role = Console.ReadLine();
        //    Console.WriteLine("Enter the username: ");
        //    a.UserName = Console.ReadLine();
        //    Console.WriteLine("Enter the password: ");
        //    a.password = Console.ReadLine();
        //    a.Balance = 0;
        //    a.BankID = 1;
        //    a.ID = ++id;
        //    a.AccountNumber = a.Name.Substring(0, 3) + DateTime.Now.ToString("yyyyMMdd");

        //    accountList.Add(a);

        //    var newAccount = Newtonsoft.Json.JsonConvert.SerializeObject(accountList);
        //    System.IO.File.WriteAllText(@"C:\Work\Training\DotNet\BankAccount\BankAccount\Data\Accounts.json", newAccount);
        //}

        //public static void updateOrDeleteUser()
        //{
        //    string accountJsonPath = @"C:\Work\Training\DotNet\BankAccount\BankAccount\Data\Accounts.json";
        //    string accountJsonString = System.IO.File.ReadAllText(accountJsonPath);
        //    var accountList = JsonConvert.DeserializeObject<List<Account>>(accountJsonString);

        //    int id = 0;

        //    Console.WriteLine("Enter the account ID which you want to update/delete: ");
        //    int AccountId = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Enter '1' to update, '2' to delete: ");
        //    var option = Console.ReadLine();


        //    if (option == "1")
        //    {
        //        foreach (var acc in accountList)
        //        {
        //            if (acc.ID == AccountId)
        //            {

        //                Console.WriteLine("Enter new name to update: ");
        //                acc.Name = Console.ReadLine();

        //                var UpdatedAccount = Newtonsoft.Json.JsonConvert.SerializeObject(accountList);
        //                System.IO.File.WriteAllText(@"C:\Work\Training\DotNet\BankAccount\BankAccount\Data\Accounts.json", UpdatedAccount);
        //            }
        //        }
        //        Console.WriteLine("User's data updated successfully.");
        //    }

        //    else if (option == "2")
        //    {
        //        int index = 0, currentObjectCount = 0;
        //        foreach (var acc in accountList)
        //        {
        //            if (acc.ID == AccountId)
        //            {
        //                index = currentObjectCount;

        //            }
        //            currentObjectCount++;
        //        }

        //        accountList.Remove(accountList[index]);
               

        //        Console.WriteLine("User deleted successfully.");

        //        var UpdatedList = Newtonsoft.Json.JsonConvert.SerializeObject(accountList);
        //        System.IO.File.WriteAllText(@"C:\Work\Training\DotNet\BankAccount\BankAccount\Data\Accounts.json", UpdatedList);
        //    }

        //    else
        //        Console.WriteLine("Invalid input");
        //}


        //public static double currencyConvert(double amount)
        //{
        //    Console.WriteLine("Enter the currency type: (INR/USD/AUD/EUR/PND)");
        //    String type = Console.ReadLine().ToUpper();

        //    switch (type)
        //    {
        //        case "INR":
        //            amount *= 1;
        //            break;
        //        case "USD":
        //            amount *= 78.50;
        //            break;
        //        case "AUD":
        //            amount *= 54.30;
        //            break;
        //        case "EUR":
        //            amount *= 83.10;
        //            break;
        //        case "PND":
        //            amount *= 96.40;
        //            break;
        //        default:
        //            Console.WriteLine("Enter a valid currency type.");
        //            break;
        //    }
        //    return amount;
        //}

        //public static void viewTransactionHistory()
        //{
        //    string transactionPath = @"C:\Work\Training\DotNet\BankAccount\BankAccount\Data\Transactions.json";
        //    string transactionJsonString = System.IO.File.ReadAllText(transactionPath);
        //    var transactionList = JsonConvert.DeserializeObject<List<Transaction>>(transactionJsonString);

        //    foreach(var trans in transactionList)
        //    {
        //        Console.WriteLine("ID: " + trans.ID);
        //        Console.WriteLine("Amount: " + trans.Amount);
        //        Console.WriteLine("Made By: " + trans.MadeBy);
        //        Console.WriteLine("Made To: " + trans.MadeTo);
        //        Console.WriteLine("Time: " + trans.Time);
        //        Console.WriteLine("\n");
        //    }
            
        //}
    }
}
