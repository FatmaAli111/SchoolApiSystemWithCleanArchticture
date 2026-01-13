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
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<string>>,
        IRequestHandler<DeleteStudentByIdCommand, Response<string>>,
        IRequestHandler<EditStudentCommand, Response<string>>



    {
        #region fields
        private readonly IStudentService studentService;
        private readonly IMapper map;
        #endregion


        #region constr
        public StudentCommandHandler(IStudentService studentService,IMapper map)
        {
            this.studentService = studentService;
            this.map = map;
        }
        #endregion


        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var result = map.Map<Student>(request);
            var finalResult =await studentService.AddStudentAsync(result);
           
            if (finalResult == "Exit")
                return BadRequest<string>("Name Exist");
            return Success<string>("success"); 
        }
        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await studentService.GetStudentByIdAsync(request.StudentId);

            if (student == null)
                return NotFound<string>("Not found");

            var studentMapper = map.Map(request, student);

            var studentupdate = await studentService.EditStudentAsync(studentMapper);



            if (studentupdate == "success")
                return Success<string>($"Updated Successfully {studentMapper}");

            return BadRequest<string>("Doesnot Updated");
        }

        public async Task<Response<string>> Handle(DeleteStudentByIdCommand request, CancellationToken cancellationToken)
        {
            //get student ,check if it is exist ,delete
            var student =await studentService.GetStudentByIdAsync(request.Id);
            if (student == null)
                return NotFound<string>("Student not found");
          
            studentService.DeleteAsync(student);

            return Success<string>("success");


        }
    }
}
