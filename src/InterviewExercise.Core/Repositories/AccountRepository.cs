using Dapper;
using InterviewExercise.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace InterviewExercise.Core.Repositories
{
    public interface IAccountRepository
    {
        List<Account> GetAccountsForMember(string memberId);
        Account GetAccount(string accountId);
        Account UpdateAccount(Account account);
    }

    public class AccountRepository : IAccountRepository
    {
        private string sqlConnection;
        public AccountRepository(string sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public List<Account> GetAccountsForMember(string memberId)
        {
            using (var connection = new SqlConnection(sqlConnection))
            {
                var accounts = connection.Query<Account>(
                    "select * from Account where member_id = {=Id}",
                    new { Id = int.Parse(memberId) });

                return accounts.ToList();
            }
        }

        public Account GetAccount(string accountId)
        {
            using (var connection = new SqlConnection(sqlConnection))
            {
                var account = connection.QueryFirst<Account>(
                    "select * from Account where account_id = {=Id}",
                    new { Id = int.Parse(accountId) });

                return account;
            }
        }

        public Account UpdateAccount(Account account)
        {
            using (var connection = new SqlConnection(sqlConnection))
            {
                connection.Execute(
                    "update Account set nickname = {=Nickname} where account_id = {=Id}",
                    new { Nickname = account.Nickname, Id = account.AccountId });

                return account;
            }
        }
    }
}
