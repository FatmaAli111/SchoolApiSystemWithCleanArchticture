using School.Data.DTOs;
using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.IServices
{
   public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<string> AddStudentAsync(Student studentFromRequest);
        Task<Student> GetStudentByIdAsync(int id);
    }
}
