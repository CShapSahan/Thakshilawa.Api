using Application.Abstractions.SchoolStudent;
using Application.Features.SchoolStudent.Students.Commands;
using Domain.Models.SchoolStudent;
using MediatR;

namespace Application.Features.SchoolStudent.Students.CommandHandlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudent, Student>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> Handle(CreateStudent request, CancellationToken cancellationToken)
        {
            var newStudent = new Student
            {
                AddressCity = request.AddressCity,
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                CreatedByUser = request.CreatedByUser,
                CreatedDate = request.CreatedDate,
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
            await _studentRepository.Insert(newStudent);
            return newStudent;
        }
    }
}
