//Bao Tran
//Homework 6

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BirthdayCard.Models
{
    public class BirthdayResponse
    {
        [Required(ErrorMessage = "Please enter From")]
        public string FromName { get; set; }

        [Required(ErrorMessage = "Please enter To")]
        public string ToName { get; set; }

        [Required(ErrorMessage = "Please enter Message")]
        public string Message { get; set; }
        public bool? CardSent { get; set; }
    }
}
