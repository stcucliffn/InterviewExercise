namespace InterviewExercise.Core.Services
{
    using Api;
    using Core;
    using Models;

    public class AccountsService : IAccountsService
    {
        private readonly IAccountRepository accountRepository;

        public AccountsService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Account[] GetAccounts(int memberId)
        {
            var accounts = accountRepository.GetAccounts(memberId);
            foreach (var account in accounts)
            {
                // Only return the last four. Thar be dragons!
                account.LastFour = account.AccountNo.Substring(account.AccountNo.Length - 4, 4);
            }

            return accounts;
        }
    }
}