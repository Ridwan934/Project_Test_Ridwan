using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test_Case_API.Data;
using Test_Case_API.Models.Entities;
using Test_Case_API.Utilities.Handlers;

namespace Test_Case_API.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController :Controller
{
    private readonly TestDbContext _dbcontext;

    public UserController(UserService userservices)
    {
        _userservices = userservices;
    }

    [HttpPost("Register")]
 
    public IActionResult Register(Dtos.RegisterDto registerDto)
    {
        var registerResult = _userservices.Register(registerDto);
        if (registerResult == null)
        {
            return NotFound(new ResponseHandlers<DetailAccountDto>
            {
                Code = StatusCodes.Status404NotFound,
                Status = HttpStatusCode.NotFound.ToString(),
                Message = "Register Failed"
            });
        }
        return Ok(new ResponseHandlers<DetailAccountDto>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Register Successfully",
            Data = registerResult
        });
    }


    [HttpPost("Login")]
    public IActionResult Login(LoginDto loginDto)
    {
        var loginResult = _userservices.Login(loginDto);
        switch (loginResult)
        {
            case "0":
                return NotFound(new ResponseHandlers<AccountDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Account has been deactivated"
                });
            case "-1":
                return NotFound(new ResponseHandlers<AccountDto>
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Login Failed"
                });
        }
        return Ok(new ResponseHandlers<string>
        {
            Code = StatusCodes.Status200OK,
            Status = HttpStatusCode.OK.ToString(),
            Message = "Login Successfully",
            Data = loginResult
        });

    }
}
