using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace olbe.Entity
{
    public class BankAccount
    {
        [Key]
        public int bankAccountId { get; set; }
        public virtual User User { get; set; }
        public int userId { get; set; }
        public int Money { get; set; }
        public string IBAN { get; set; }

    }
}
