using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Queries.Results
{
    public class GetPaginatedStudentResponse
    {
        public int StudentId { get; set; }

        public string? StudentName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string DepartmentName { get; set; }
        public GetPaginatedStudentResponse(int id,string name,string address,string phone ,string departmentName)
        {
            StudentId = id;
            StudentName = name;
            Address = address;
            Phone = phone;
            DepartmentName = departmentName;
                
        }
    }
}
