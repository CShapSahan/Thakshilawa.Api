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
        public async Task Handle(DeleteStudent request, CancellationToken cancellationToken)
        {
            //await _studentRepository.Delete(request.Id);

            var deleteStudent = await _studentRepository.GetbyStudentId(request.Id);
            deleteStudent.IsDelete = true;
            await _studentRepository.Update(deleteStudent);
        }
    }
}
