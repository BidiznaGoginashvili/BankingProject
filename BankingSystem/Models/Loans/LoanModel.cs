using BankingSystem.Models.Base;
using System;

namespace BankingSystem.Models.Loans
{
    public class LoanModel : BaseModel
    {
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public GuarantorModel Guarantor { get; set; }
        public LoanModel(decimal amount, DateTime startDate, DateTime finishDate)
        {
            Amount = amount;
            StartDate = startDate;
            FinishDate = finishDate;
        }
    }
}