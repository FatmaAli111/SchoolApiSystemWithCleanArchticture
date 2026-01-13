using MediatR;
using School.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Commands.Models
{
   public class DeleteStudentByIdCommand: IRequest<Response<string>>

    {
        public int Id { get; set; }

        public DeleteStudentByIdCommand(int id)
        {
            Id = id;
        }

    }
}
