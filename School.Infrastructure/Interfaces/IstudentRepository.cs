using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentAsync();
    }
}
