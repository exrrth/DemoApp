using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

// [ApiController]
// [Route("api/[controller]")] // localhost:5001/api/users
////// public class UsersController(DataContext context) : BaseApiController

[Authorize]
public class UsersController(IUserRepository userRepository) : BaseApiController

{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await userRepository.GetMembersAsync();

        // var usersToReturn = mapper.Map<IEnumerable<MemberDto>>(users);

        return Ok(users); // or can use -- return (users);
    }

    [HttpGet("{username}")] // api/users/{username}
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        var user = await userRepository.GetMemberAsync(username);

        if (user == null) return NotFound(); //GetUserByUsernameAsync could return null so it has to put "if" statement

        // return mapper.Map<MemberDto>(user);
        return user;
    }
}
