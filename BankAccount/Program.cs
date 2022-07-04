// See https://aka.ms/new-console-template for more information
using System;
using Newtonsoft.Json;
using BankLibrary.Services;

namespace BankAccount // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            Account user;

            Console.WriteLine("Hi there !!");
            Console.WriteLine("Welcome to HDFC Bank");
            Console.WriteLine("Enter your login credentials to login:");

            string x;
            do
            {
                user = loginMember();

                if (user == null)
                {
                    
                    Console.WriteLine("Invalid credentials. Please try again.");

                }
                else
                {
                    DisplayAccountDetails(user);
                    userFunctions(user);
                }
                Console.WriteLine("Do you want to login as another user ? Press 'y' to continue, else press any key and enter to terminate.");
                x = Console.ReadLine();

            } while(x == "y" || x == "Y");

        }

        public static Account loginMember()
        {
            

            Console.WriteLine("Enter your username:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter the password:");
            string password = Console.ReadLine();
            Console.WriteLine("\n");

            string bankJsonPath = @"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Banks.json";
            string bankJsonString = System.IO.File.ReadAllText(bankJsonPath);
            var list = JsonConvert.DeserializeObject<List<Bank>>(bankJsonString);
            
            var first_bank = list.First();

            BankServices bankservice = new BankServices();
            Account newUser = bankservice.VerifyUser(first_bank, userName, password);
            // Console.ReadLine();

            return newUser;
            
        }

        public static void userFunctions(Account account)
        {

            string x;
            do
            {
                if (account.Role == "Customer" || account.Role == "customer")
                {
                    Console.WriteLine("Enter '1' to deposit money, \n '2' to withdraw money, \n '3' to transfer money \n and '4 ' to see transaction history: ");
                    var input = Console.ReadLine()[0];

                    Bank b = new Bank();

                    string accountPath = @"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Accounts.json";
                    string accountJsonString = System.IO.File.ReadAllText(accountPath);
                    var accountList = JsonConvert.DeserializeObject<List<Account>>(accountJsonString);

                    if (input == '1')
                    {
                        Console.WriteLine("Enter amount to deposit: ");
                        double amount = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the currency: (INR/USD/AED/PND/EUR)");
                        string type = Console.ReadLine();

                        double convertedAmount = BankServices.currencyConvert(amount, type);

                        foreach ( var acc in accountList)
                        {
                            if(account.ID == acc.ID)
                            {
                                AccountServices.Deposit(convertedAmount, acc);
                            }
                        }

                    }
                    else if (input == '2')
                    {
                        Console.WriteLine("Enter amount to withdraw: ");
                        double amount = Double.Parse(Console.ReadLine());

                        foreach (var acc in accountList)
                        {
                            if (account.ID == acc.ID)
                            {
                                AccountServices.Withdraw(amount, acc);
                            }
                        }


                    }
                    else if (input == '3')
                    {
                        Console.WriteLine("Enter the account ID to which you want to transfer money: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter amount to transfer: ");
                        double amount = Double.Parse(Console.ReadLine());

                        Account srcAccnt = null;
                        Account destAccnt = null;


                        foreach (var acc in accountList)
                        {
                            if(account.ID == acc.ID)
                            {
                                srcAccnt = acc;
                            }
                            if (id == acc.ID)
                            {
                                destAccnt = acc;
                            }
                        }

                        AccountServices.Transfer(amount, srcAccnt, destAccnt);


                    }

                    else if(input == '4')
                    {
                        string transactionPath = @"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Transactions.json";
                        string transactionJsonString = File.ReadAllText(transactionPath);
                        var transactionList = JsonConvert.DeserializeObject<List<Transaction>>(transactionJsonString);

                        foreach(var trans in transactionList)
                        {
                            if(trans.From == account.ID)
                            {
                                BankServices.viewTransactionHistory(trans);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid input !!");
                    }

                    var NewAccountList = Newtonsoft.Json.JsonConvert.SerializeObject(accountList);
                    System.IO.File.WriteAllText(@"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Accounts.json", NewAccountList);
                    
                }
                else
                {
                    Console.WriteLine("Enter '1' to create account, \n '2' to delete/update account, \n '3' to do currency exchange, \n '4' to view account transaction history: ");
                    int input = Convert.ToInt32(Console.ReadLine());



                    switch (input)
                    {
                        

                        case 1:

                            string ip;
                            do
                            {
                                string bankJsonPath = @"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Banks.json";
                                string bankJsonString = System.IO.File.ReadAllText(bankJsonPath);
                                var list = JsonConvert.DeserializeObject<List<Bank>>(bankJsonString);

                                var first_bank = list.First();

                                string accountJsonPath1 = @"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Accounts.json";
                                string accountJsonString1 = File.ReadAllText(accountJsonPath1);
                                var accountList1 = JsonConvert.DeserializeObject<List<Account>>(accountJsonString1);

                                Console.WriteLine("Enter new account holder's name: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter the role: (Staff/Customer)");
                                string role = Console.ReadLine();
                                
                                Console.WriteLine("Enter the username: ");
                                string userName = Console.ReadLine();

                                foreach (var acc in accountList1)
                                {
                                    if (acc.UserName.Equals(userName))
                                    {
                                        Console.WriteLine("This username already exists. Try something else.");
                                    }
                                    break;
                                }

                                Console.WriteLine("Enter the password: ");
                                string password = Console.ReadLine();
                                BankServices.createUserAccount(first_bank, accountList1, name, role, userName, password);
                                Console.WriteLine("Do you want to continue creating another account ? Press 'y' to continue or any other key and then enter to quit.");
                                ip = Console.ReadLine();
                            } while (ip == "y" || ip == "Y");

                            break;

                        case 2:

                            string accountJsonPath2 = @"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Accounts.json";
                            string accountJsonString2 = File.ReadAllText(accountJsonPath2);
                            var accountList2 = JsonConvert.DeserializeObject<List<Account>>(accountJsonString2);

                            Console.WriteLine("Enter the account ID which you want to update/delete: ");
                            int AccountId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter '1' to update, '2' to delete: ");
                            var option = Console.ReadLine();

                            bool check1 = false;
                            bool newCheck1 = BankServices.updateOrDeleteUser(accountList2, AccountId, option, check1);
                            if (newCheck1 == true)
                            {
                                Console.WriteLine("Operation performed successfully.");
                            }
                            else
                            {
                                Console.WriteLine("No such user exists !!");
                            }

                            break;

                        case 3:
                            Console.WriteLine("Enter the amount: ");
                            double amount = Double.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the currency type: (INR/USD/AUD/EUR/PND)");
                            string type = Console.ReadLine().ToUpper();

                            double convertedAmount = BankServices.currencyConvert(amount, type);
                            Console.WriteLine("Amount in INR: " + convertedAmount);
                            break;

                        case 4:

                            Console.WriteLine("Enter the account ID: ");
                            int ID = Convert.ToInt32(Console.ReadLine());

                            string transactionPath = @"C:\Work\Training\DotNetTraining\BankAccount\BankLibrary\Data\Transactions.json";
                            string transactionJsonString = File.ReadAllText(transactionPath);
                            var transactionList = JsonConvert.DeserializeObject<List<Transaction>>(transactionJsonString);


                            bool check2 = false;

                            foreach (var trans in transactionList)
                            {
                                if (trans.From == ID)
                                {
                                    check2 = true;
                                    BankServices.viewTransactionHistory(trans);
                                }
                            }
                             
                            if (check2 == false)
                            {
                                Console.WriteLine("Either no transactions have been made to this id or it's not a valid account id.");
                            }

                            break;

                        default:
                            Console.WriteLine("Enter a valid option.");
                            break;

                    }
                }

                Console.WriteLine("Do you want to continue doing other operations ? Enter 'y' to continue or any other key to exit.");
                x = Console.ReadLine();
            } while (x == "y" || x == "Y");
        }

        public static void DisplayAccountDetails(Account account)
        {
            Console.WriteLine("Account ID: " + account.ID);
            Console.WriteLine("Account Holder's Name: " + account.Name);
            Console.WriteLine("Account Number: " + account.AccountNumber);
            Console.WriteLine("IFSC Code: " + account.IfscCode);
            Console.WriteLine("Bank ID: " + account.BankID);
            Console.WriteLine("Balance: " + account.Balance);

            Console.ReadLine();
        }
        
    }

    enum Role
    {
        Staff,
        Customer
    }
}