using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;
using School.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Commands.Handelrs
{
    public class AddStudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
    {
        #region fields
        private readonly IStudentService studentService;
        private readonly IMapper map;
        #endregion


        #region constr
        public AddStudentCommandHandler(IStudentService studentService,IMapper map)
        {
            this.studentService = studentService;
            this.map = map;
        }
        #endregion


        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var result = map.Map<Student>(request);
            var finalResult =await studentService.AddStudentAsync(result);
           
            if (finalResult == "exist")
                return BadRequest<string>("Name Exist");
            return Success<string>("success"); 
        }
    }
}
