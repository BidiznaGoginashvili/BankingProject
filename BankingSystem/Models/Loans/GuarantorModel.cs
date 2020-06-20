using BankingSystem.Models.Base;

namespace BankingSystem.Models.Loans
{
    public class GuarantorModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string Phone { get; set; }
        public string Relationship { get; set; }

        public GuarantorModel(string firstName, string lastName, string phone, string relationship)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Relationship = relationship;
        }
    }
}