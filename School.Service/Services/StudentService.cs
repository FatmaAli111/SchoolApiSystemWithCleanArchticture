using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Infrastructure.Data;
using School.Infrastructure.Interfaces;
using School.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
           _studentRepository = studentRepository;
        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetStudentAsync();
        }
    }
}
