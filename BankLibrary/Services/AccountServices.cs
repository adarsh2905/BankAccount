using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccount;

namespace BankLibrary.Services
{
    public class AccountServices
    {


        public static void Deposit(double amount, Account account)
        {
            account.Balance += amount;
            BankServices.DepositTransact(amount, account);

        }



        public static void Withdraw(double amount, Account account)
        {

            if (account.Balance < amount)
            {
                Console.WriteLine("Insufficient balance in account to perform this transaction.");

            }
            else
            {
                account.Balance -= amount;

            }
            BankServices.WithdrawTransact(amount, account);

        }



        public static void Transfer(double amount, Account sourceAccount, Account destinationAccount)
        {
            if (sourceAccount.BankID == destinationAccount.BankID)
            {
                if (amount < sourceAccount.Balance)
                {
                    string input;
                    do
                    {
                        Console.WriteLine("Press 'a' for RTGS, and 'b' for IMPS transfer");
                        var x = Console.ReadLine()[0];

                        destinationAccount.Balance += amount;

                        if (x == 'a')
                        {
                            double rtgs = BankServices.SameBankRtgsTransfer(amount);
                            sourceAccount.Balance -= amount - rtgs;
                        }
                        else if (x == 'b')
                        {
                            double imps = BankServices.SameBankImpsTransfer(amount);
                            sourceAccount.Balance -= amount - imps;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }

                        Console.WriteLine("Press '1' to continue, or press any other key and then press Enter to exit.");
                        input = Console.ReadLine();
                    } while (input == "1");



                }
                else
                {
                    Console.WriteLine("Insufficient balance in this account to perform this transaction.");
                }

            }

            else
            {
                if (amount < sourceAccount.Balance)
                {

                    Console.WriteLine("Press 'a' for RTGS, and 'b' for IMPS transfer");
                    var x = Console.ReadLine()[0];

                    destinationAccount.Balance += amount;

                    if (x == 'a')
                    {
                        double rtgs = BankServices.DifferentBankRtgsTransfer(amount);
                        sourceAccount.Balance -= amount - rtgs;
                    }
                    if (x == 'b')
                    {
                        double imps = BankServices.DifferentBankImpsTransfer(amount);
                        sourceAccount.Balance -= amount - imps;
                    }


                }
                else
                {
                    Console.WriteLine("Insufficient balance in this account to perform this transaction.");
                }

            }

            BankServices.TransferTransact(amount, sourceAccount, destinationAccount);

        }



    }

}
