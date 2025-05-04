using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Core.Features.Students.Commands.Models;
using School.Core.Features.Students.Queries.Models;
using System.Threading.Tasks;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
           _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new GetStudentList());
            return  Ok(response);

        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] AddStudentCommand command)
        {
            var response = _mediator.Send(command);
            return Ok(response);
        }
        [HttpGet("GetByid/{id}")]
        public async Task<IActionResult> GetSingleStudentById(int id)
        {
            var request =await _mediator.Send(new GetSingleStudentById(id));
            return  Ok(request);
        }
    }
}
