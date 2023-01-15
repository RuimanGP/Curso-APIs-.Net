namespace ApiBackend.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController: ControllerBase
{
    private readonly ApiDbContext _context;
    private readonly JwtSettings _jwtSettings;

    public AccountController(ApiDbContext context, JwtSettings jwtSettings)
    {
        _context = context;
        _jwtSettings = jwtSettings;
    }

    private IEnumerable<User> Logins = new List<User>()
    {
        new User()
        {
            Id = 1,
            Email = "Martin@imaginagroiup.com",
            Name = "Admin",
            Password = "Admin"
        },
        new User()
        {
            Id = 2,
            Email = "pepe@imaginagroiup.com",
            Name = "User1",
            Password = "pepe"
        }

    };

    [HttpPost]
    public IActionResult GetToken(UserLogins userLogin)
    {
        try
        {
            var Token = new UserTokens();

            // Search a user in context with LINQ

            var searchUser = (from user in _context.Users
                              where user.Name == userLogin.UserName && user.Password == userLogin.Password
                              select user).FirstOrDefault();

            Console.WriteLine($"User Found {searchUser}");

            // TODO:  Change to searchUser
            //var Valid = Logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));


            if (searchUser != null)
            {
                //var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                Token = JwHelpers.GenTokenKey(new UserTokens()
                {
                    UserName = searchUser.Name,
                    EmailId = searchUser.Email,
                    Id = searchUser.Id,
                    GuidId = Guid.NewGuid(),
                }, _jwtSettings);
            }
            else
            {
                return BadRequest("Wrong Password");
            }
            return Ok(Token);
        }
        catch (Exception e)
        {
            throw new Exception("GetToken Error", e);
        }

    }

    [HttpGet]    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
    public IActionResult GetUserList()
    {
        return Ok(Logins);
    }
}
