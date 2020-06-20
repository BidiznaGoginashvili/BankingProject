using System;
using BankingSystem.Models.Base;
using System.Collections.Generic;
using BankingSystem.Models.Loans;
using BankingSystem.Models.Deposits;

namespace BankingSystem.Models.Users
{
    public class UserModel : BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte Gender { get; set; }

        public string UniqueNumber { get; set; }

        public DateTime BirthDay { get; private set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public IList<LoanModel> Loans { get; set; }

        public IList<DepositModel> Deposits { get; set; }

        public string Branch { get; set; }

        public UserModel(int id, string firstName, string lastName, byte gender,
               string uniqueNumber, DateTime birthDay, string address,
               string email, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            UniqueNumber = uniqueNumber;
            BirthDay = birthDay;
            Address = address;
            Email = email;
            Phone = phone;
            Loans = new List<LoanModel>();
            Deposits = new List<DepositModel>();
        }
    }
}