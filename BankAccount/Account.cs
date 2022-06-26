using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        public int ID { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public int UserName { get; set; }
        public string password { get; set; }
        public string Role { get; set; }
        public int BankID { get; set; }
        public double Balance { get; set; }
        
        


        //string name;
        //string date = DateTime.UtcNow.ToString("ddMMyyyy");
        //string bankID;
        //string accountID;
        //string type;
        //string password;

        //public Account(string name, string date, string bankID, string accountID, string type, string password)
        //{
        //    this.name = name;
        //    this.date = date;
        //    this.bankID = bankID;
        //    this.accountID = accountID;
        //    this.type = type;
        //    this.password = password;
        //}
    }
}
