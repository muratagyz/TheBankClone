using Microsoft.EntityFrameworkCore;
using olbe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olbe.Data
{
    public class ArbankContext : DbContext
    {
        public ArbankContext(DbContextOptions<ArbankContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<ProcessType> ProcessType { get; set; }
    }
}
