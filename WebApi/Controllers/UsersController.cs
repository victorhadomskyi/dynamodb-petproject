namespace WebApi.Controllers
{
    using Application.Users.Commands.CreateUser;
    using Application.Users.Queries.GetUser;
    using Application.Users.Queries.GetUsers;
    using Application.ViewModels.Users;
    using Domain.Entities;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UsersController : ApiController
    {

        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> Get([FromRoute] string userId)
        {
            return await Mediator.Send(new GetUserQuery{UserId = userId});
        }

        [HttpGet]
        public async Task<ActionResult<List<UserInfoVm>>> Get()
        {
            return await Mediator.Send(new GetUsersQuery());
        }
    }
}
