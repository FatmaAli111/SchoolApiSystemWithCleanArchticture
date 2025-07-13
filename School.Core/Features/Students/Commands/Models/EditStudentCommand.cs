using MediatR;
using School.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Commands.Models
{
    public class EditStudentCommand:IRequest<Response<string>>
    {
        public int id { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Did { get; set; }


    }
}
