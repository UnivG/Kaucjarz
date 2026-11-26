using kaucjarz_api.DTO;
using kaucjarz_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace kaucjarz_api.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
    private readonly AppDBContext _appDbContext;
    private readonly IPasswordHasher<User> _passwordHasher;
    public  UserController(AppDBContext appDbContext, IPasswordHasher<User> passwordHasher)
    {
        _appDbContext=appDbContext;
        _passwordHasher = passwordHasher;
    }
    [HttpGet("GetUser")]
    public IEnumerable<UserResponseDto> Get(){
        try
        {
            var users = _appDbContext.Users.Select(x => new UserResponseDto(x.userId,x.name,x.email,x.balance,x.role.ToString())).ToList<UserResponseDto>();
            return users;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error during get user: " + e.Message);
            throw;
        }
    }

    [HttpPost("PostUser")]
    public ActionResult<UserResponseDto> Add(CreateUserDto request)
    {
        var user = new User
        {
            name = request.Name,
            email = request.Email,
            role = request.Role
        };

        user.password = _passwordHasher.HashPassword(user, request.Password);

        _appDbContext.Users.Add(user);
        _appDbContext.SaveChanges();

        return Ok(new UserResponseDto(user.userId, user.name, user.email, user.balance, user.role.ToString()));

    }

    [HttpPost("VerifyLogin")] 
    public ActionResult<bool> VerifyLogin(LoginDto request)
    {
        var dbUser = _appDbContext.Users
            .FirstOrDefault(x => x.name == request.Login || x.email == request.Login);

        if (dbUser == null)
        {
            return Unauthorized(false);
        }

        var result = _passwordHasher.VerifyHashedPassword(dbUser, dbUser.password, request.Password);

        if (result == PasswordVerificationResult.SuccessRehashNeeded)
        {
            dbUser.password = _passwordHasher.HashPassword(dbUser, request.Password);
            _appDbContext.SaveChanges();
        }

        if (result == PasswordVerificationResult.Failed)
        {
            return Unauthorized(false);
        }

        return Ok(true);
    }

}