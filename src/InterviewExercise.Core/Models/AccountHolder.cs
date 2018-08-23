using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InterviewExercise.Core.Models
{
    class AccountHolder
    {
        public int account_id { get; set; }

        public AccountHolder accountHolder { get; set; }

        public String account_no { get; set; }

        public String nickname { get; set; }

        [Required]
        [StringLength(3)]
        public String type { get; set; }

        [Required]
        [StringLength(10)]
        public String status { get; set; }

        public decimal balance { get; set; }[]
    }
}
