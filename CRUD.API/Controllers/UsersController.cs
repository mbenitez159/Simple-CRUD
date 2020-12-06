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
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UsersController(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _unitOfWork.Users.GetAll();

            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(usersToReturn);
        }


        [HttpGet]
        [Route("{UserId}", Name = "UserLink")]
        public async Task<IActionResult> Get(int UserId)
        {
            var user = await _unitOfWork.Users.Get(UserId);

            if (user is null)
                return NotFound();

            var userToReturn = _mapper.Map<UserForDetailDto>(user);

            return Ok(userToReturn);
        }


        [HttpPost]
        public async Task<IActionResult> Create(UserForCreationDto UserDto)
        {
            var user = _mapper.Map<User>(UserDto);

            _unitOfWork.Users.Add(user);

            if (await _unitOfWork.Complete())
                return CreatedAtRoute("UserLink", new { user.Id }, UserDto);

            throw new Exception($"Something went wrong trying to create an user");
        }

        [HttpPut]
        [Route("{UserId}")]
        public async Task<IActionResult> Update(int UserId,
            UserForUpdateDto UserForUpdate)
        {
            UserForUpdate.Id = UserId;

            var userFromRepo = await _unitOfWork.Users.Get(UserId);

            _mapper.Map(UserForUpdate, userFromRepo);

            if (await _unitOfWork.Complete())
                return Ok();

            throw new Exception($"Update User {UserId} failed on save");
        }

        [HttpDelete]
        [Route("{UserId}")]
        public async Task<IActionResult> Delete(int UserId)
        {

            var userFromRepo = await _unitOfWork.Users.Get(UserId);

            _unitOfWork.Users.Remove(userFromRepo);

            if (await _unitOfWork.Complete())
                return Ok();

            throw new Exception($"Update User {UserId} failed on save");
        }

    }
}
