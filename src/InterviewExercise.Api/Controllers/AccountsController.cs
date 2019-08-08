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
        private readonly IAccountsService accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            this.accountsService = accountsService;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<List<AccountDTO>> Get(int id)
        {
            return accountsService.GetAccountsForMember(id);
        }


        // GET api/values/5
        [HttpGet("getAccount/{accountId}")]
        public ActionResult<AccountDTO> GetAccount(int accountId)
        {
            return accountsService.GetAccount(accountId);
        }

        // PUT api/values/5
        [HttpPut("{accountId}")]
        public ActionResult Put(int accountId, AccountDTO accountDto)
        {
            accountsService.UpdateNickName(accountDto);
            return Ok();
        }
    }
}
