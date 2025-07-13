using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;
using School.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Commands.Handelrs
{

    public class EditStudentCommandHandler : ResponseHandler, IRequestHandler<EditStudentCommand, Response<string>>
    {
        private readonly IMapper map;
        private readonly IStudentService studentService;

        public EditStudentCommandHandler(IMapper Map,IStudentService studentService)
        {
            map = Map;
            this.studentService = studentService;
        }
        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {

            var studentMapper = map.Map<Student>(request);
          
            var studentupdate = await studentService.EditStudentAsync(studentMapper);

            if(studentupdate=="success")
            return Success<string>($"Updated Successfully {studentMapper}");
           
            return BadRequest<string>("Doesnot Updated");
        }
    }
}
