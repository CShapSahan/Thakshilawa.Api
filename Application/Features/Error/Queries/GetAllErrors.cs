using Domain.Models.Error;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Error.Queries
{
    public class GetAllErrors:IRequest<ICollection<ErrorLog>>
    {
    }
}
