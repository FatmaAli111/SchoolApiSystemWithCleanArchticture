using AutoMapper;
using School.Core.Features.Students.Commands.Models;
using School.Core.Features.Students.Queries.Results;
using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Mapping
{
   public  partial class StudentProfile:Profile
    {
        public StudentProfile()
        {
            AddStudentCommand();
            StudentListQuery();
           StudentQueryById();
           EditStudentCommand();
        }
    }
}
