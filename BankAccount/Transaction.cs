using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Transaction
    {
        public int ID { get; set; }
        public double Amount { get; set; }
        public int MadeBy { get; set; }
        public int MadeTo { get; set; }
        public DateTime Time { get; set; }

        //public double transact(double amount)
        //{
        //    Console.WriteLine("Click 'a' to deposit money, 'b' to withdraw money and 'c' to transfer money to another account: ");
        //    char x = Console.ReadLine()[0];
        //    Char.ToLower(x);
        //    double newAmount = 0;

        //    switch (x)
        //    {
        //        case 'a':
        //            Console.WriteLine("Enter the amount to deposit: ");
        //            int amountToAdd = Convert.ToInt32(Console.ReadLine());

        //            newAmount = amount + amountToAdd;
        //            return newAmount;
        //            // break;

        //        case 'b':
        //            Console.WriteLine("Enter the amount to withdraw: ");
        //            int amountToDeduct = Convert.ToInt32(Console.ReadLine());

        //            if (amount >= amountToDeduct)
        //                newAmount = amount - amountToDeduct;
        //            else
        //                Console.WriteLine("Insufficient balance in account to perform this transaction.");

        //            return newAmount;
        //            // break;

        //        case 'c':
        //            Console.WriteLine("Enter the name of bank to which u want money to transfer: ");
        //            String newBank = Console.ReadLine();

        //            Console.WriteLine("Enter the amount to transfer: ");
        //            int amountToTransfer = Convert.ToInt32(Console.ReadLine());

        //            Bank b = new Bank();

        //            Console.WriteLine("Enter 'a' for RTGS transfer, 'b' for IMPS transfer: ");
        //            char input = Console.ReadLine()[0];

        //            if (newBank == "XYZ")
        //            {
        //               if(input == 'a')
        //                {
        //                    newAmount = amount - amountToTransfer;
        //                    Console.WriteLine("Amount transferred to other account: " + b.sameBankRtgsTransaction);
        //                } 

        //               else if (input == 'b')
        //                {
        //                    newAmount = amount - amountToTransfer;
        //                    Console.WriteLine("Amount transferred to other account: " + b.sameBankImpsTransaction);
        //                }
        //               else
        //                {
        //                    Console.WriteLine("Invalid option. Transfer terminated.");
        //                }

        //            }

        //            else
        //            {
        //                if (input == 'a')
        //                {
        //                    newAmount = amount - amountToTransfer;
        //                    Console.WriteLine("Amount transferred to other account: " + b.differentBankRtgsTransaction);
        //                }

        //                else if (input == 'b')
        //                {
        //                    newAmount = amount - amountToTransfer;
        //                    Console.WriteLine("Amount transferred to other account: " + b.differentBankImpsTransaction);
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid option. Transfer terminated.");
        //                }
        //            }

        //            return newAmount;

        //            // break;

        //        default:
        //            Console.WriteLine("Invalid option. Transaction terminated");
        //            return newAmount;

        //    }

        //}
    }
}
