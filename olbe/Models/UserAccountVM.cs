using olbe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olbe.Models
{
    public class UserAccountVM
    {
        public List<User> Users { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
