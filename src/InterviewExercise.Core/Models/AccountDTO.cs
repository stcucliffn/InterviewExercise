using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewExercise.Core.Models
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string LastFour { get; set; }
        public string Nickname { get; set; }
        public string Type { get; set; }
        public decimal Balance { get; set; }
        public string AccountHolder { get; set; }
    }
}
