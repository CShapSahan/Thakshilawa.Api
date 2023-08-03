using Domain.Models.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Error
{
    public interface IErrorLogRepository
    {
        Task<ICollection<ErrorLog>> GetAllErrors();

        Task AddError(ErrorLog errorLog);
    }
}
