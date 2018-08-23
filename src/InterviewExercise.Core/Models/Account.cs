using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InterviewExercise.Core.Models
{
    public class Account 
    {
        [Required]
        public int member_id { get; set; }

        [Required]
        [StringLength(100)]
        public String first_name { get; set; }

        [Required]
        [StringLength(100)]
        public String last_name { get; set; }
    }
}
