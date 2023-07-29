using Domain.Models.SchoolStudent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SchoolStudent.Students.Commands
{
    public class UpdateStudent : IRequest<Student>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; } = null;
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; } = string.Empty;
        public string GuardianFirstName { get; set; }
        public string GuardianLastName { get; set; }
        public string GuardianTitle { get; set; }
        public int EmergencyContactNumber { get; set; }
        public int? MobilePhoneNumber { get; set; }
        public int? LandPhoneNumber { get; set; }
        public string GuardianEmail { get; set; } = string.Empty;
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; } = string.Empty;
        public string AddressCity { get; set; }
        public DateTime DateofBirth { get; set; }
        public int? UpdateByUser { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
