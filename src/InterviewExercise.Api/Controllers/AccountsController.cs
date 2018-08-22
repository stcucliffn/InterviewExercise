using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewExercise.Core.Models;
using InterviewExercise.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterviewExercise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        public IAccountService accountService { get; }

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        // GET api/values
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<AccountDTO>> Get(int id)
        {
            return accountService.GetAccountsForMember(id.ToString());
        }

        // GET api/values
        [HttpGet("getaccount/{id}")]
        public ActionResult<AccountDTO> GetAccount(int id)
        {
            return accountService.GetAccount(id.ToString());
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult<AccountDTO> Put(AccountDTO account)
        {
            return accountService.UpdateAccount(account);
        }
    }
}
