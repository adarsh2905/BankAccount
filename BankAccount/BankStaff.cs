using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BankStaff
    {
        string date = DateTime.UtcNow.ToString("ddMMyyyy");
        string bankID = "XYZ" + date;
        Account ashish = new Account("Ashish", date, bankID, "ASH" + date, "Bank Holder");

    }
}
