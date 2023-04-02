using Core.Application.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Books.Commands.Create;
using Project.Application.Features.Books.Commands.Delete;
using Project.Application.Features.Books.Commands.Update;
using Project.Application.Features.Books.Queries.GetAll;
using Project.Application.Features.Books.Queries.GetById;
using Project.Application.Features.Books.Requests;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBook([FromQuery] PageRequest pageRequest)
        {
            var query = new GetAllBookQuery { PageRequest = pageRequest };
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetBookById([FromQuery] GetBookByIdQuery query)
        {
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request)
        {
            var command = new CreateBookCommand(request);
            var result = await Mediator!.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookRequest request)
        {
            var command = new UpdateBookCommand(request);
            var result = await Mediator!.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook([FromQuery] DeleteBookCommand command)
        {
            var result = await Mediator!.Send(command);
            return Ok(result);
        }
    }
}
