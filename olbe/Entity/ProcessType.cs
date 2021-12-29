using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace olbe.Entity
{
    public class ProcessType
    {
        [Key]
        public int processTypeId { get; set; }
        public string processType { get; set; }
    }
}
