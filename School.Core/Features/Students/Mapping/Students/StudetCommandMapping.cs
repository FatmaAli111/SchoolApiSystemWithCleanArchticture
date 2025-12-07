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
    public partial class StudentProfile
    {
        public  void AddStudentCommand()
        {
            CreateMap<AddStudentCommand, Student>();
             // .ForMember(dst => dst.Department, src => src.MapFrom(opt => new Department { DName = opt.StudentName }));
        }
        public  void EditStudentCommand()
        {
            CreateMap<EditStudentCommand, Student>()
                .ForMember(dst => dst.StudentId, opt => opt.MapFrom(src => src.id))
                .ForPath(dst => dst.Department.DID, opt => opt.MapFrom(src => src.Did)).
                ForMember(dst => dst.Department, src => src.MapFrom(opt => new Department { DName = opt.StudentName }));
            ;
        }
    }

}
