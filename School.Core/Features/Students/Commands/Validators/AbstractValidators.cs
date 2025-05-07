using FluentValidation;
using School.Core.Features.Students.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidators:AbstractValidator<AddStudentCommand>
    {
        public AddStudentValidators()
        {
            ApplyStudentValidations();
        }

        public void ApplyStudentValidations()
        {
            RuleFor(x => x.StudentName).NotEmpty().MaximumLength(100);

        }

    }
}
