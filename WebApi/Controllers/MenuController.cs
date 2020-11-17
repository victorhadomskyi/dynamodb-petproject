namespace WebApi.Controllers
{
    using Application.Menu.Commands.AddMenuItem;
    using Application.Menu.Commands.UpdateMenuGroups;
    using Application.Menu.Queries.GetMenuGroups;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MenuController : ApiController
    {
        [HttpPut("groups")]
        public async Task<ActionResult> UpdateMenu([FromBody] UpdateMenuGroupsCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPost("groups/items")]
        public async Task<ActionResult> AddMenuItem([FromBody] AddMenuItemCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpGet("groups")]
        public async Task<ActionResult<List<string>>> GetMenuGroups()
        {
            return await Mediator.Send(new GetMenuGroupsQuery());
        }
    }
}
