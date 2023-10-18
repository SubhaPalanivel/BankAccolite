using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTestProject_1.Models
{
    public class AccountTransactions
    {
        public string AccountId { get; set; } 
        public decimal TransactionAmount { get; set; }
        public TransType TransactionType { get; set; }

    }
    public enum TransType
    {
        Deposit,
        Withdrawl
    }
}