using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrastructure.Data;
using School.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Repository
{
   public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbcontext;

        public StudentRepository(AppDbContext dbcontext)
        {
          _dbcontext = dbcontext;
        }

        public async Task<List<Student>> GetStudentAsync()
        {
            return await _dbcontext.students.ToListAsync();
        }

       
    }
}
