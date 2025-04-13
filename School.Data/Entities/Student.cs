using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Entities
{
   public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [StringLength(5000)]
        public string StudentName { get; set; }
        [StringLength(5000)]
        public string Address { get; set; }
        [StringLength(5000)]
        public string Phone { get; set; }


        public int Did { get; set; }


        [ForeignKey("Did")]
        public Department Department;

    }
}
