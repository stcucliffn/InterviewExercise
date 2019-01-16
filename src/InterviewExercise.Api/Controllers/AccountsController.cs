namespace InterviewExercise.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        [HttpGet("{id}")]
        public AccountViewModel[] GetAccounts(int id)
        {
            var result = new List<AccountViewModel>();

            var accounts = accountsService.GetAccounts(id);
            foreach (var account in accounts)
            {
                var accountViewModel = new AccountViewModel
                {
                    Id = account.MemberId,
                    LastFour = account.LastFour,
                    NickName = account.NickName,
                    Type = account.Type,
                    Balance = account.Balance
                };
                result.Add(accountViewModel);
            }

            return result.ToArray();
        }
    }
}