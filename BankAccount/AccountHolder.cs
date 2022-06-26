using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class AccountHolder
    {
        string date = DateTime.UtcNow.ToString("ddMMyyyy");
        string bankID = "XYZ" + date;
        Account naman = new Account("Naman", date, bankID, "NAM" + date, "Account Holder", "12345678");
    }
}
