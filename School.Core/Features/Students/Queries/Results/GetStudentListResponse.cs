using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Queries.Results
{
    public class GetStudentListResponse
    {

        public int StudentId { get; set; }

        public string? StudentName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? DeptartmentName { get; set; }
    }
}
