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
    public static class StudetCommandMapping
    {
        public static void AddStudentCommand(Profile profile)
        {
            profile.CreateMap<AddStudentCommand, Student>()
              .ForMember(dst => dst.Department, src => src.MapFrom(opt => new Department { DName = opt.StudentName }));
        }
        public static void EditStudentCommand(Profile profile)
        {
            profile.CreateMap<EditStudentCommand, Student>()
              .ForMember(dst => dst.StudentId, src => src.Ignore());
        }
    }

}
