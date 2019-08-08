using InterviewExercise.Core.Models;
using InterviewExercise.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewExercise.Core.Services
{
    public interface IAccountsService
    {
        List<AccountDTO> GetAccountsForMember(int rim);
        AccountDTO GetAccount(int accountNumber);
        void UpdateNickName(AccountDTO accountDto);
    }

    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository accountsRepository;

        public AccountsService(IAccountsRepository accountsRepository)
        {
            this.accountsRepository = accountsRepository;
        }

        public List<AccountDTO> GetAccountsForMember(int rim)
        {
            return accountsRepository
                .GetAccountsForMember(rim)
                .Select(account => MapAccountToAccountDTO(account))
                .Where(account => account.Status.Equals("active"))
                .ToList();
        }

        public AccountDTO GetAccount(int accountId)
        {
            return MapAccountToAccountDTO(accountsRepository
                .GetAccount(accountId));
        }

        public void UpdateNickName(AccountDTO accountDto)
        {
            accountsRepository.UpdateNickname(accountDto);
        }

        private AccountDTO MapAccountToAccountDTO(Account account)
        {
            return new AccountDTO()
            {
                Id = account.AccountId,
                Balance = account.Balance,
                LastFour = Truncate(account.AccountNo),
                Nickname = SetNickname(account),
                Status = account.Status,
                Type = account.Type,
                AccountHolder = account.FirstName + " " + account.LastName
            };
        }

        private string Truncate(string accountNumber)
        {
            var length = accountNumber.Length;
            return accountNumber.Substring(length - 4);
        }


        private string SetNickname(Account account)
        {
            var accountNickname = account.Nickname;

            if (string.IsNullOrWhiteSpace(account.Nickname))
            {
                accountNickname = (account.Type.Equals("sav")) ? "Savings" : "Checking";
            }

            return accountNickname;
        }
    }
}
