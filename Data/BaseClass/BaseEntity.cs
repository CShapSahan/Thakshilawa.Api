using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseClass
{
    public class BaseEntity
    {
        [ForeignKey("User")]
        public int CreatedByUser { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("User")]
        public int? UpdateByUser { get; set; }
        public DateTime? UpdateDate { get; set; }

        public bool IsDelete { get; set; } = false;
    }
}
