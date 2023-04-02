using Core.Application.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Categories.Commands.Create;
using Project.Application.Features.Categories.Commands.Delete;
using Project.Application.Features.Categories.Commands.Update;
using Project.Application.Features.Categories.Queries.GetAll;
using Project.Application.Features.Categories.Queries.GetById;
using Project.Application.Features.Categories.Request;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategory([FromQuery] PageRequest pageRequest)
        {
            var query = new GetAllCategoryQuery(pageRequest);
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetCategoryById([FromQuery] GetCategoryByIdQuery query)
        {
            var result = await Mediator!.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            var command = new CreateCategoryCommand(request);
            var result = await Mediator!.Send(command);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
        {
            var command = new UpdateCategoryCommand(request);
            var result = await Mediator!.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromQuery] DeleteCategoryCommand command)
        {
            var result = await Mediator!.Send(command);
            return Ok(result);
        }

    }
}
