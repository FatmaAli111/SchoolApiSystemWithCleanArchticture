using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
   public class StudentRepository : GenericRepository<Student>,IStudentRepository
    {
        private readonly AppDbContext _dbcontext;
        private readonly DbSet<Student> dbset;
        public StudentRepository(AppDbContext dbcontext):base(dbcontext)
        {
          _dbcontext = dbcontext;
            dbset = _dbcontext.Set<Student>();
        }

        public Task<List<Student>> GetStudentAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student =  dbset.AsNoTracking()
                .Include(i => i.Department).
                Where(i => i.StudentId == id).
                FirstOrDefault();
            return  student;
        }
    }
}
