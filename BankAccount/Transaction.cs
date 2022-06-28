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

    }
}
