using Application.Abstractions.Error;
using Domain.Models.Error;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Error
{
    public class ErrorLogRepository : IErrorLogRepository
    {
        private readonly DataContext _dataContext;

        public ErrorLogRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task AddError(ErrorLog errorLog)
        {
            _dataContext.ErrorLogs.Add(errorLog);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<ICollection<ErrorLog>> GetAllErrors()
        {
            return await _dataContext.ErrorLogs.OrderByDescending(x=>x.DateTime).ToListAsync();
        }
    }
}
