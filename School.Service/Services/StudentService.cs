using Microsoft.EntityFrameworkCore;
using School.Data.DTOs;
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

        public async Task<string> AddStudentAsync(Student studentFromRequest)
        {
            var studentFromDB = _studentRepository.GetStudentByName(studentFromRequest);

            if (studentFromDB != "Exist")
                return "Exit";
            await _studentRepository.AddAsync(studentFromRequest);

            return "success";
        }

        public async Task<string> EditStudentAsync(Student studentfromRequest)
        {
          
          await  _studentRepository.UpdateAsync(studentfromRequest);
           
            return "success";
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetStudentAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var Result= await _studentRepository.GetByIdAsync(id);
            return Result;
        }
        public async Task<string> DeleteAsync(Student student)
        {
            
             await _studentRepository.DeleteAsync(student);
            return "Success";

        }

        public  IQueryable<Student> GetStudentsQueryable()
        {
            return  _studentRepository.GetTableNoTracking().Include(s=>s.Department).AsQueryable();
        }
    }
}
