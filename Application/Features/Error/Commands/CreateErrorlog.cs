using Domain.Models.Error;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Error.CommandHandlers
{
    public class CreateErrorLog:IRequest
    {
        public int Id { get; set; }
        public string? ApiPath { get; set; }
        public string? Message { get; set; }
        public string? InnerException { get; set; }
        public string? UserId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
