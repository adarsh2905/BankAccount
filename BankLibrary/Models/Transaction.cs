using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Transaction
    {
        public double Amount { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public DateTime Time { get; set; }
        public string? Type { get; set; }
        public string? ID { get; set; }

    }
}
