using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Queries.Models
{
    public class GetSingleStudentById : IRequest<Response<GetSingleStudentListByIdResponse>>
    {
        public int id { get; set; }
    }
}
