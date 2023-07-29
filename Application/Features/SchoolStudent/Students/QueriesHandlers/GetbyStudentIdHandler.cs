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
    public class GetbyStudentIdHandler : IRequestHandler<GetbyStudentId, Student>
    {
        private readonly IStudentRepository _studentRepository;
        public GetbyStudentIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> Handle(GetbyStudentId request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetbyStudentId(request.Id);
        }
    }
}
