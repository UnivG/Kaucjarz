using kaucjarz_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace kaucjarz_api.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
    private readonly AppDBContext _appDbContext;
    public  UserController(AppDBContext appDbContext)
    {
        _appDbContext=appDbContext;
    }
    [HttpGet("GetUser")]
    public IEnumerable<User> Get(){
        try
        {
            return _appDbContext.Users.ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error during get user: " + e.Message);
            throw;
        }
    }

    [HttpPost("PostUser")]
    public User Add(User user)
    {
        try
        {
            var passwordHasher = new PasswordHasher<User>();
            user.password = passwordHasher.HashPassword(user, user.password);
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error during add user: " + e.Message);
            throw;
        }
        
    }
    
    [HttpGet("VerifyLogin")]
    public Boolean VerifyLogin(User user)
    {
        try
        {
            var passwordHasher=new PasswordHasher<User>();
            var hashedPasssword=_appDbContext.Users.Where(x => x.name == user.name || x.email==user.email).Select(x=>x.password).FirstOrDefault()??"";
            var result= passwordHasher.VerifyHashedPassword(user, hashedPasssword, user.password);
            return result==PasswordVerificationResult.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine("error during verify login: " + e.Message);
            return false;
        }
    }
}