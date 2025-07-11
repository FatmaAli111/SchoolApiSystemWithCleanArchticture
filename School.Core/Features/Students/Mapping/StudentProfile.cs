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
   public  class StudentProfile:Profile
    {
        public StudentProfile()
        {
            StudetCommandMapping.AddStudentCommand(this);
            StudentQueryMapping.StudentListQuery(this);
            StudentQueryMapping.StudentQueryById(this);
            StudetCommandMapping.EditStudentCommand(this);
        }
    }
}
