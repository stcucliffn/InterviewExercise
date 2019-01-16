namespace InterviewExercise.Api.Controllers
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string LastFour { get; set; }
        public string NickName { get; set; }
        public string Type { get; set; }
        public decimal Balance { get; set; }
    }
}