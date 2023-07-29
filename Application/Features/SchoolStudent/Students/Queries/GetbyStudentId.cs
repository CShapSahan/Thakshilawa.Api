using Domain.Models.SchoolStudent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SchoolStudent.Students.Queries
{
    public class GetbyStudentId : IRequest<Student>
    {
        public int Id { get; set; }
    }
}
