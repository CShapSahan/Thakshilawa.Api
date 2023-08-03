using Application.Abstractions.SchoolStudent;
using Application.Features.SchoolStudent.Students.Commands;
using MediatR;

namespace Application.Features.SchoolStudent.Students.CommandHandlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudent>
    {
        private readonly IStudentRepository _studentRepository;
        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(DeleteStudent request, CancellationToken cancellationToken)
        {
            var deleteStudent = await _studentRepository.GetbyStudentId(request.Id);
            deleteStudent.IsDelete = true;
            await _studentRepository.Update(deleteStudent);
            return Unit.Value;
        }
    }
}
