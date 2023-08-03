using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Error
{
    public class ErrorLog
    {
        public int Id { get; set; }
        public string? ApiPath { get; set; }
        public string? Message { get; set; }
        public string? InnerException { get; set; }
        public string? UserId { get; set; }
        public DateTime DateTime { get; set; }

    }
}
