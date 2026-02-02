using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Queries.Models
{
    public class GetPaginatedStudents:IRequest<PaginatedResult<GetPaginatedStudentResponse>>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string[] orderBy { get; set; }
        public string search { get; set; }
    }
}
