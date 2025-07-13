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

        public async Task<List<Student>> GetStudentAsync()
        {
            return await dbset.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await
                dbset.AsNoTracking().Include(x=>x.Department).
                FirstOrDefaultAsync(x => x.StudentId == id);
            ;
            return  student;
        }
    }
}
