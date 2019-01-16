namespace InterviewExercise.Core
{
    using Dapper;
    using Models;
    using System.Data.SqlClient;
    using System.Linq;

    public class AccountRepository : IAccountRepository
    {
        private readonly string sqlConnection;

        public AccountRepository(string sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public Account[] GetAccounts(int memberId)
        {
            using (var sqlConnection = new SqlConnection(this.sqlConnection))
            {
                var sqlStatement = "SELECT * FROM Account WHERE member_id = @Id";
                return sqlConnection.Query<Account>(sqlStatement, new { Id = memberId }).ToArray();
            }
        }
    }
}
