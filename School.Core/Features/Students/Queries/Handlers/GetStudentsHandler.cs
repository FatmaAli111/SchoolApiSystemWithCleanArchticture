using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Models;
using School.Core.Features.Students.Queries.Results;
using School.Data.Entities;
using School.Service.IServices;
using School.Service.Services;
using SchoolProject.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Commands.Handelrs
{
   public class GetStudentsHandler :ResponseHandler,
        IRequestHandler<GetStudentList, Response<List<GetStudentListResponse>>>
        ,IRequestHandler<GetSingleStudentById,Response<GetSingleStudentByIdResponse>>,
        IRequestHandler<GetPaginatedStudents,PaginatedResult<GetPaginatedStudentResponse>>
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

        public async Task<Response<GetSingleStudentByIdResponse>> Handle(GetSingleStudentById request, CancellationToken cancellationToken)
        {

            var studentFromDB = await _studentService.GetStudentByIdAsync(request._id);
            if (studentFromDB == null)
                return  NotFound<GetSingleStudentByIdResponse>("Student Not Found");
            var resuult = _mapper.Map<GetSingleStudentByIdResponse>(studentFromDB);
            return Success<GetSingleStudentByIdResponse>(resuult);
        }


        async Task<PaginatedResult<GetPaginatedStudentResponse>> IRequestHandler<GetPaginatedStudents, PaginatedResult<GetPaginatedStudentResponse>>.Handle(GetPaginatedStudents request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetPaginatedStudentResponse>> expression = e => 
            new GetPaginatedStudentResponse(e.StudentId, e.StudentName, e.Address, e.Phone, e.Department.DName);
            var queryable = _studentService.GetStudentsQueryable();

            var paginatedStudents =await queryable.Select(expression).ToPaginatedListAsync(request.pageNumber, request.pageSize);
            return paginatedStudents;
        }
    }
}
