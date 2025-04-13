using MediatR;
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
    class GetStudentsHandler : IRequestHandler<GetStudentList, List<Student>>
    {
        private readonly IStudentService _studentService;

        public GetStudentsHandler(IStudentService studentService)
        {
           _studentService = studentService;
        }
        public async Task<List<Student>> Handle(GetStudentList request, CancellationToken cancellationToken)
        {

            return await _studentService.GetAllStudentsAsync();

        }
    }
}
