using Domain.BaseClass;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SchoolStudent
{
    public class Student : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; } = null;
        public string LastName { get; set; }
        public string Title { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;
        public string GuardianFirstName { get; set; }
        public string GuardianLastName { get; set; }
        public string GuardianTitle { get; set; }
        [Phone]
        public int EmergencyContactNumber { get; set; }
        [Phone]
        public int? MobilePhoneNumber { get; set; }
        [Phone]
        public int? LandPhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string GuardianEmail { get; set; } = string.Empty;
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; } = string.Empty;
        public string AddressCity { get; set; }
        public DateTime DateofBirth { get; set; }

    }
}
