using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Data.Entities;
namespace School.Core.Features.Students.Commands.Models
{
    public class GetStudentList:IRequest<List<Student>>
    {

    }
}
