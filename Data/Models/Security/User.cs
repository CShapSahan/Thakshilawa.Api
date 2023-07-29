using Domain.BaseClass;
using Domain.Models.SchoolStudent;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models.Security
{
    [Index(nameof(UserName), IsUnique =true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User   :  BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
         
        public string Email { get; set; }
        public string Password { get; set; }
           
        public string UserName { get; set; }

        public bool IsAdminPasswordRest { get; set; } 

        public bool IsActive { get; set; } = false;       

        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<Student> Student { get; set; }



    }
}
