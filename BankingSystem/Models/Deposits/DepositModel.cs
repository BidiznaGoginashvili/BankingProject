using BankingSystem.Models.Base;

namespace BankingSystem.Models.Deposits
{
    public class DepositModel : BaseModel
    {
        public decimal Balance { get; set; }

        public DepositModel(decimal balance)
        {
            Balance = balance;
        }
    }
}