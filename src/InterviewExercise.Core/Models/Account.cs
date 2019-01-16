namespace InterviewExercise.Core.Models
{
    public class Account
    {
        public int MemberId { get; set; }
        public string AccountNo { get; set; }
        public string LastFour { get; set; }
        public string NickName { get; set; }
        public string Type { get; set; }
        public decimal Balance { get; set; }
    }
}
