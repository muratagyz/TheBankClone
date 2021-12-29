using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace olbe.Entity
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string userNameSurname { get; set; }
        public string userMail { get; set; }
        public string userPassword { get; set; }
        public string userTC { get; set; }
        public string userTel { get; set; }
        public virtual List<BankAccount> BankAccount { get; set; }
    }
}
