using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using InterviewExercise.Core.Models;

namespace InterviewExercise.Core.Repositories
{
    public interface IAccountsRepository
    {
        List<Account> GetAccountsForMember(int rim);
        Account GetAccount(int accountId);
        void UpdateNickname(AccountDTO accountDto);
    }
    public class AccountsRepository : IAccountsRepository
    {
        private string sqlConnection;

        public AccountsRepository(string sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public List<Account> GetAccountsForMember(int rim)
        {
            using (var connection = new SqlConnection(sqlConnection))
            {
                var accounts = connection.Query<Account>("SELECT * FROM Account JOIN Member ON Member.member_id = Account.member_id WHERE Member.member_id = @id", new { id = rim });
                return accounts.ToList();
            }
        }

        public Account GetAccount(int accountId)
        {
            using (var connection = new SqlConnection(sqlConnection))
            {
                var account = connection.QueryFirst<Account>("SELECT * FROM Account JOIN Member ON Member.member_id = Account.member_id WHERE Account.account_id = @acctID", new { acctID = accountId });
                return account;
            }
        }

        public void UpdateNickname(AccountDTO accountDto)
        {
            using (var connection = new SqlConnection(sqlConnection))
            {
                var account = connection.Execute("UPDATE Account SET nickname = @updatedNickname WHERE account_id = @acctID", 
                    new {acctID = accountDto.Id, updatedNickname = accountDto.Nickname });
            }
        }
    }
}
