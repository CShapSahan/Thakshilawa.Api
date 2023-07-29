using Application.Abstractions.SchoolStudent;
using Application.Features.SchoolStudent.Students.Commands;
using Domain.Models.SchoolStudent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SchoolStudent.Students.CommandHandlers
{
    internal class UpdateStudentHandler : IRequestHandler<UpdateStudent, Student>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> Handle(UpdateStudent request, CancellationToken cancellationToken)
        {
            var existingStudent = new Student
            {
                Id = request.Id,
                AddressCity = request.AddressCity,
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                UpdateByUser = request.UpdateByUser,
                UpdateDate = request.UpdateDate,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmergencyContactNumber = request.EmergencyContactNumber,
                GuardianEmail = request.GuardianEmail,
                GuardianFirstName = request.GuardianFirstName,
                GuardianLastName = request.GuardianLastName,
                GuardianTitle = request.GuardianTitle,
                LandPhoneNumber = request.LandPhoneNumber,
                MiddleName = request.MiddleName,
                MobilePhoneNumber = request.MobilePhoneNumber,
                Title = request.Title,
                DateofBirth = request.DateofBirth,
            };

            await _studentRepository.Update(existingStudent);
            return existingStudent;
        }
    }
}
