using MediatR;
using School.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Commands.Models
{
  public class AddStudentCommand:IRequest<Response<string>>
    {
        //هنا انا محتاجه اعمل validation لكن بدل مااعملها ب attributes
        //انا هستخدم حاجه اسمها fluent validation in base class separated from the properties
        //validators
        public string? StudentName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int Did { get; set; }
    }
}
