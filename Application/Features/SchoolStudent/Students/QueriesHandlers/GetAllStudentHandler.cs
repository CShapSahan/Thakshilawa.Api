using Application.Abstractions.SchoolStudent;
using Application.Features.SchoolStudent.Students.Queries;
using Domain.Models.SchoolStudent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SchoolStudent.Students.QueriesHandlers
{
    public class GetAllStudentHandler : IRequestHandler<GetAllStudent, ICollection<Student>>
    {
        private readonly IStudentRepository _studentRepository;
        public GetAllStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ICollection<Student>> Handle(GetAllStudent request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetAllStudents();
        }
    }
}
