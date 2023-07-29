using Application.Abstractions.SchoolStudent;
using Domain.Models.SchoolStudent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace DataAccess.Repository.SchoolStudent
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _dbContext;
        public StudentRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(int id)
        {
            var student = await GetbyStudentId(id);
            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Student>> GetAllStudents()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student> GetbyStudentId(int id) => await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

        public async Task Insert(Student student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Student student)
        {
            _dbContext.Students.Update(student);
            await _dbContext.SaveChangesAsync();
        }
    }
}
