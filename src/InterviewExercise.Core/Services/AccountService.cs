using InterviewExercise.Core.Models;
using InterviewExercise.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace InterviewExercise.Core.Services
{
    public interface IAccountService
    {
        List<AccountDTO> GetAccountsForMember(string memberId);
        AccountDTO GetAccount(string accountId);
        AccountDTO UpdateAccount(AccountDTO account);
    }

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IMemberRepository memberRepository;

        public AccountService(IAccountRepository accountRepository, IMemberRepository memberRepository)
        {
            this.accountRepository = accountRepository;
            this.memberRepository = memberRepository;
        }

        public AccountDTO GetAccount(string accountId)
        {
            var account = accountRepository.GetAccount(accountId);

            var member = memberRepository.GetMember(account.MemberId.ToString());
            var accountHolder = CreateAccountHolderName(member);

            return MapAccountToAccountDTO(account, accountHolder);
        }

        public List<AccountDTO> GetAccountsForMember(string memberId)
        {
            var member = memberRepository.GetMember(memberId);
            var accountHolder = CreateAccountHolderName(member);

            return accountRepository
                .GetAccountsForMember(memberId)
                .Where(account => account.Status == "active")
                .Select(account => MapAccountToAccountDTO(account, accountHolder))
                .ToList();
        }

        public AccountDTO UpdateAccount(AccountDTO account)
        {
            accountRepository.UpdateAccount(MapAccountDTOToAccount(account));
            return GetAccount(account.Id.ToString());
        }

        private Account MapAccountDTOToAccount(AccountDTO account)
        {
            return new Account()
            {
                Nickname = account.Nickname,
                AccountId = account.Id
            };
        }

        private string CreateAccountHolderName(Member member)
        {
            return $"{member.FirstName} {member.LastName}";
        }

        private AccountDTO MapAccountToAccountDTO(Account account, string accountHolder)
        {
            return new AccountDTO()
            {
                Nickname = SetNickname(account),
                LastFour = Truncate(account.AccountNo),
                Type = account.Type,
                Id = account.AccountId,
                Balance = account.Balance,
                AccountHolder = accountHolder
            };
        }

        private string SetNickname(Account account)
        {
            var nickname = account.Nickname;
            var defaultNickname = (account.Type == "ckg") ? "checking" : "savings";
            return string.IsNullOrWhiteSpace(nickname) ? defaultNickname : nickname;
        }

        private string Truncate(string accountNo)
        {
            var accountLength = accountNo.Length;
            return accountNo.Substring(accountLength - 4);
        }
    }
}
