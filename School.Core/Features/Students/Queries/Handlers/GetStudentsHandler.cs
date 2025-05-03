using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Models;
using School.Core.Features.Students.Queries.Results;
using School.Data.Entities;
using School.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Commands.Handelrs
{
   public class GetStudentsHandler :ResponseHandler, IRequestHandler<GetStudentList, Response<List<GetStudentListResponse>>>
        ,IRequestHandler<GetSingleStudentById,Response<GetSingleStudentListByIdResponse>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public GetStudentsHandler(IStudentService studentService,IMapper Mapper)
        {
           _studentService = studentService;
            _mapper = Mapper;
        }
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentList request, CancellationToken cancellationToken)
        {

            var studentList= await _studentService.GetAllStudentsAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            return Success(studentListMapper);

        }

      
        Task<Response<GetSingleStudentListByIdResponse>> IRequestHandler<GetSingleStudentById, Response<GetSingleStudentListByIdResponse>>.Handle(GetSingleStudentById request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
