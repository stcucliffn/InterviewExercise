using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace InterviewExercise.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var accountlist;
            using (var connection =
                new SqlConnection("Data Source=(LOCALDB)\\PROJECTSV13;Initial Catalog = Database.InterviewExercise"))
            {
                accountlist = connection.Query("SELECT account_id, account_no, nickname, type, balance FROM ACCOUNT WHERE member_id = @id AND status = active", id);
            }

            return accountlist;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
