using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using CRUD.API.Core;
using CRUD.API.Core.Domain;
using CRUD.API.Core.Dto;

using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await UnitOfWork.Users.GetAll();

            var usersToReturn = Mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(usersToReturn);
        }


        [HttpGet]
        [Route("{UserId}", Name = "UserLink")]
        public async Task<IActionResult> Get(int UserId)
        {
            var user = await UnitOfWork.Users.Get(UserId);

            if (user is null)
                return NotFound();

            var userToReturn = Mapper.Map<UserForDetailDto>(user);

            return Ok(userToReturn);
        }


        [HttpPost]
        public async Task<IActionResult> Create(UserForCreationDto UserDto)
        {
            var user = Mapper.Map<User>(UserDto);

            UnitOfWork.Users.Add(user);

            if (await UnitOfWork.Complete())
                return CreatedAtRoute("UserLink", new { UserId = user.Id }, UserDto);

            throw new Exception($"Something went wrong trying to create an user");
        }

        [HttpPut]
        [Route("{UserId}")]
        public async Task<IActionResult> Update(int UserId,
            UserForUpdateDto UserForUpdate)
        {
            UserForUpdate.Id = UserId;

            var userFromRepo = await UnitOfWork.Users.Get(UserId);

            Mapper.Map(UserForUpdate, userFromRepo);

            if (await UnitOfWork.Complete())
                return Ok();

            throw new Exception($"Update User {UserId} failed on save");
        }

        [HttpDelete]
        [Route("{UserId}")]
        public async Task<IActionResult> Delete(int UserId)
        {

            var userFromRepo = await UnitOfWork.Users.Get(UserId);

            UnitOfWork.Users.Remove(userFromRepo);

            if (await UnitOfWork.Complete())
                return Ok();

            throw new Exception($"Update User {UserId} failed on save");
        }

    }
}
