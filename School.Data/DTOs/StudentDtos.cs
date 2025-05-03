using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.DTOs
{
    public class StudentDtos
    {
        public string StudentName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }


        public int Did { get; set; }

    }
}
