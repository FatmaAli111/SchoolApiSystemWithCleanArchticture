using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Core.Features.Students.Commands.Models;
using School.Core.Features.Students.Queries.Models;
using SchoolApi.Base;
using System.Threading.Tasks;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : AppControllerBase
    {
       
        [HttpGet]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new GetStudentList());
                                 return  NewResult(response);

        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] AddStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet("GetByid/{id}")]
        public async Task<IActionResult> GetSingleStudentById(int id)
        {
            var response = await _mediator.Send(new GetSingleStudentById(id));
            return NewResult(response);
        }
        [HttpPost("Edit")]
        public async Task<IActionResult> EditAsync([FromBody] EditStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
    }
}
