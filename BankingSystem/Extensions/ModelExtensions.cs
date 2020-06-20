using System.Linq;
using BankingSystem.Service;
using System.Collections.Generic;
using BankingSystem.Models.Loans;
using BankingSystem.Models.Users;
using BankingSystem.Models.Deposits;

namespace BankingSystem.Extensions
{
    public static class ModelExtensions
    {
        public static UpdateUserCommand MapToCommand(this User user)
        {
            return new UpdateUserCommand()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                UniqueNumber = user.UniqueNumber,
                BirthDay = user.BirthDay,
                Address = user.Address,
                Email = user.Email,
                Phone = user.Phone
            };
        }

        public static UserModel MapToModel(this User user)
        {
            var model = new UserModel(user.Id, user.FirstName, user.LastName, user.Gender,
                user.UniqueNumber, user.BirthDay, user.Address, user.Email,
                user.Phone);

            model.Loans = user.Loans.Select(loan => 
                new LoanModel(loan.Amount, loan.StartDate, loan.FinishDate)).ToList();

            model.Deposits = user.Deposits.Select(deposit =>
                new DepositModel(deposit.Balance)).ToList();

            return model;
        }

        public static IEnumerable<UserModel> MapToModel(this IEnumerable<User> users)
        {
            return users.Select(user =>
            {
                var model =new UserModel(user.Id, user.FirstName, user.LastName, user.Gender,
                user.UniqueNumber, user.BirthDay, user.Address, user.Email,
                user.Phone);

                model.Loans = user.Loans.Select(loan =>
                    new LoanModel(loan.Amount, loan.StartDate, loan.FinishDate)).ToList();

                model.Deposits = user.Deposits.Select(deposit =>
                    new DepositModel(deposit.Balance)).ToList();

                return model;
            }).ToList();
        }
    }
}
