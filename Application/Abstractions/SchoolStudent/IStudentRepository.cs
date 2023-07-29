using Domain.Models.SchoolStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.SchoolStudent
{
    public interface IStudentRepository
    {
        Task<ICollection<Student>> GetAllStudents();
        Task<Student> GetbyStudentId(int id);
        Task Insert(Student student);
        Task Update(Student student);
        Task Delete(int id);
    }
}
