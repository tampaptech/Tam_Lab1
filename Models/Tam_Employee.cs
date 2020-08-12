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

        public string Username { get; set; }
       
        public DateTime DateOfBirth { get; set; }
    
        public string FirstName { get; set; }
     
        public string LastName { get; set; }

        public string Gender { get; set; }

    }
}
