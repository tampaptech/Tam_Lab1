using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tam_Lab1.Models
{
    //Id, Username, FirstName, LastName, DateOfBirth, Gender
    public class Tam_Employee
    { 
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 5)]
        [Required]
        public string Username { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        
        [Required]
        public string Gender { get; set; }

    }
}
