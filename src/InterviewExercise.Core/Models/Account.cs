
namespace InterviewExercise.Core.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int MemberId { get; set; }
        public string AccountNo { get; set; }
        public string Nickname { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public decimal Balance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
