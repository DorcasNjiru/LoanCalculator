using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanCalc.DAL.Models;

namespace LoanCalc.DAL.Context
{
    public class LoanCalcContext : DbContext
    {
        public LoanCalcContext(DbContextOptions<LoanCalcContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
    
