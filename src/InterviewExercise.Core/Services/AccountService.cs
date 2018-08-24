using System;
using System.Collections.Generic;
using System.Text;
using InterviewExercise.Core.Repositories;
using InterviewExercise.Core.Models;

namespace InterviewExercise.Core.Services
{
    public class AccountService
    {
        public Account[] GetAccounts(string memberId)
        {
            var AccountInst = new AccountRepository();
            var Accounts = AccountInst.GetAccount(memberId);

            return Accounts;
        }
    }
}
