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

        public int ID { get; set; }

      

        public Account VerifyUser(string userName, string password)
        {
            string accountJsonPath = @"C:\Work\Training\DotNet\BankAccount\BankAccount\Data\Accounts.json";
            string accountJsonString = System.IO.File.ReadAllText(accountJsonPath);
            var accountList = JsonConvert.DeserializeObject<List<Account>>(accountJsonString);

            
            foreach(var acc in accountList)
            {
                if(acc.BankID == ID)
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


        public void Deposit(double amount, Account account)
        {
            // Update corresponding account object in Accounts json file
        }

        public void Withdraw(double amount, Account account)
        {
            // Validate if acount has enough balance or not
            // You need to update accounts json
        }

        public void Transfer(double amount, Account sourceAccount, Account destinationAccount)
        {
            //
        }


        //string bankName = "XYZ";

        //double amount;

        //public int currencyConvert()
        //{
        //    Console.WriteLine("Enter the currency type: ");
        //    String amountType = Console.ReadLine();


        //    if (amountType.ToUpper() != "INR")
        //    {
                
        //    }

        //}
        

        //public double sameBankRtgsTransaction()
        //{
        //    double rtgs = 0 * amount;
        //    amount = amount - rtgs;
        //    return amount;
        //}

        //public double sameBankImpsTransaction()
        //{
        //    double imps = 0.05 * amount;
        //    amount = amount - imps;

        //    return amount;
        //}
        //public double differentBankRtgsTransaction()
        //{
        //    double rtgs = 0.02 * amount;
        //    amount = amount - rtgs;

        //    return amount;
        //}

        //public double differentBankImpsTransaction()
        //{
        //    double imps = 0.06 * amount;
        //    amount = amount - imps;

        //    return amount;
        //}

    }
}
