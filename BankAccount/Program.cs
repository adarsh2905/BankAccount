// See https://aka.ms/new-console-template for more information
using System;
using Newtonsoft.Json;

namespace BankAccount // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Take credentials from user
            // Read banks.json file and take the first bank
            // user = bank.VerifyUser(userNmae, password)
            // if user is NULL > user doesn't exist. Please try again!!
            // if user is account holder > display operations related to account holder
            // if user is staff > display operations related to the staff
        }

        public static Account loginMember()
        {
            Console.WriteLine("Hi there !!");
            Console.WriteLine("Welcome to XYZ Bank");
            Console.WriteLine("Enter your login credentials to login:");

            Console.WriteLine("Enter your account ID:");
            String userName = Console.ReadLine();
            Console.WriteLine("Enter the password:");
            String password = Console.ReadLine();

            string bankJsonPath = @"C:\Work\Training\DotNet\BankAccount\BankAccount\Data\Banks.json";
            string bankJsonString = System.IO.File.ReadAllText(bankJsonPath);
            var list = JsonConvert.DeserializeObject<List<Bank>>(bankJsonString);
            var first_bank = list.First();


            
            // var first_user = accountList.First();            


            Account newUser = first_bank.VerifyUser(userName, password);
            Console.ReadLine();

            return null;
            
        }

        if (newUser.Role.Equals("customer"))
            {
                Console.WriteLine(
            }
}
}