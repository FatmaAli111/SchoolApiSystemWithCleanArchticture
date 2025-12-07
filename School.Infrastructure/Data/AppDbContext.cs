using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Data.Entities;
using School.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace School.Infrastructure.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
        {
                
        }
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
                
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Subjects> subjects { get; set; }
        public DbSet<StudentSubject> studentSubject { get; set; }
        public DbSet<DepartmentSubject> departmentSubject { get; set; }


    }
}
