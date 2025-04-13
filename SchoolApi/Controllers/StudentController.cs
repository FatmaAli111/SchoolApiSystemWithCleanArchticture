using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Core.Features.Students.Commands.Models;

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
    }
}
