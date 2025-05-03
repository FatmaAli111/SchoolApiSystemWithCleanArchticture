using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Data.Entities;
using School.Core.Features.Students.Queries.Results;
using School.Core.Bases;
namespace School.Core.Features.Students.Queries.Models
{
    public class GetStudentList:IRequest<Response<List<GetStudentListResponse>>>
    {

    }
}
