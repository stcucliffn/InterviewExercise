using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using InterviewExercise.Core.Models;

namespace InterviewExercise.Core.Repositories
{
    class AccountRepository
    {
        public Account[] GetAccount(string memberId)
        {
            using (var connection =
                new SqlConnection("Data Source=(LOCALDB)\\PROJECTSV13;Initial Catalog = Database.InterviewExercise"))
            {
                var Accounts = connection.Query<Account>("select * from dbo.Account where member_id = @memberId", new {memberId});

                return Accounts.ToArray();
            }
        }
    }
}
