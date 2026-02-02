using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Core.Bases;
using School.Core.Features.Students.Commands.Models;
using School.Core.Features.Students.Queries.Models;
using SchoolApi.Base;
using System.Reflection.Metadata.Ecma335;
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
        [HttpPost("Delet/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var response =await _mediator.Send(new DeleteStudentByIdCommand(id));
            return NewResult(response);
        }
        [HttpGet("GetPaginatedStudents")]
        public async Task<IActionResult> GetPaginatedStudents([FromQuery] GetPaginatedStudents query)
        {
            var response =await _mediator.Send(query);

            return Ok(response);
        }
    }
}
