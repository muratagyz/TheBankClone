using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace olbe.Entity
{
    public class Process
    {
        [Key]
        public int processId { get; set; }
        public ProcessType ProcessType { get; set; }
        public int processTypeId { get; set; }
        public int processAmount { get; set; }
        public BankAccount BankAccount { get; set; }
        public int bankAccountId { get; set; }
    }
}
