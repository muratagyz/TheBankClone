using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace olbe.Entity
{
    public class Admin
    {
        [Key]
        public  int adminId { get; set; }
        public string adminName { get; set; }
        public string adminPassword { get; set; }
    }
}
