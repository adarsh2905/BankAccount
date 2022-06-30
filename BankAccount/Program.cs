// See https://aka.ms/new-console-template for more information
using System;
using Newtonsoft.Json;
using BankLibrary;

namespace BankAccount // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            Account user = loginMember();
            DisplayAccountDetails(user);
            userFunctions(user);

        }

        public static Account loginMember()
        {
            Console.WriteLine("Hi there !!");
            Console.WriteLine("Welcome to HDFC Bank");
            Console.WriteLine("Enter your login credentials to login:");

            Console.WriteLine("Enter your username:");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter the password:");
            string password = Console.ReadLine();

            string bankJsonPath = @"C:\Work\Training\DotNetTraining\BankAccount\BankAccount\Data\Banks.json";
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

            char x;
            do
            {
                if (account.Role.Equals(Role.Customer))
                {
                    Console.WriteLine("Enter '1' to deposit money, '2' to withdraw money and '3' to transfer money: ");
                    var input = Console.ReadLine()[0];

                    Bank b = new Bank();

                    string accountPath = @"C:\Work\Training\DotNetTraining\BankAccount\BankAccount\Data\Accounts.json";
                    string accountJsonString = System.IO.File.ReadAllText(accountPath);
                    var accountList = JsonConvert.DeserializeObject<List<Account>>(accountJsonString);

                    if (input == '1')
                    {
                        Console.WriteLine("Enter amount to deposit: ");
                        double amount = Double.Parse(Console.ReadLine());


                        foreach( var acc in accountList)
                        {
                            if(account.ID == acc.ID)
                            {
                                AccountServices.Deposit(BankServices.currencyConvert(amount), acc);
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
                    else
                    {
                        Console.WriteLine("Enter a valid input !!");
                    }

                    var NewAccountList = Newtonsoft.Json.JsonConvert.SerializeObject(accountList);
                    System.IO.File.WriteAllText(@"C:\Work\Training\DotNetTraining\BankAccount\BankAccount\Data\Accounts.json", NewAccountList);
                    
                }
                else
                {
                    Console.WriteLine("Enter '1' to create account, \n '2' to delete/update account, \n '3' to do currency exchange, \n '4' to view account transaction history: ");
                    int input = Convert.ToInt32(Console.ReadLine());



                    switch (input)
                    {
                        case 1:
                            BankServices.createUserAccount();
                            break;

                        case 2:
                            BankServices.updateOrDeleteUser();
                            break;

                        case 3:
                            Console.WriteLine("Enter the amount: ");
                            double amount = Double.Parse(Console.ReadLine());
                            double convertedAmount = BankServices.currencyConvert(amount);
                            Console.WriteLine("Amount in INR: " + convertedAmount);
                            break;

                        case 4:
                            BankServices.viewTransactionHistory();
                            break;

                        default:
                            Console.WriteLine("Enter a valid option.");
                            break;

                    }
                }

                Console.WriteLine("Do you want to continue doing other operations ? ");
                x = Console.ReadLine()[0];
            } while (x == 'y' || x == 'Y');
        }

        public static void DisplayAccountDetails(Account account)
        {
            Console.WriteLine("Account ID: " + account.ID);
            Console.WriteLine("Account Holder's Name: " + account.Name);
            Console.WriteLine("Account Number: " + account.AccountNumber);
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