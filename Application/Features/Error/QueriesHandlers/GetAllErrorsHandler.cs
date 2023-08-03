using Application.Abstractions.Error;
using Application.Features.Error.Queries;
using Domain.Models.Error;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Error.QueriesHandlers
{
    public class GetAllErrorsHandler : IRequestHandler<GetAllErrors, ICollection<ErrorLog>>
    {
        private readonly IErrorLogRepository _errorRepository;
        public GetAllErrorsHandler(IErrorLogRepository errorLogRepository)
        {
            _errorRepository = errorLogRepository;
        }
        public async Task<ICollection<ErrorLog>> Handle(GetAllErrors request, CancellationToken cancellationToken)
        {
            return await _errorRepository.GetAllErrors();
        }
    }
}
