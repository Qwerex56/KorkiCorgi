using KorkiCorgi.DataTransferObjects;
using KorkiCorgi.Models;
using KorkiCorgi.Models.ModelFactory;

namespace KorkiCorgi.Services;

public class AccountService : IAccountService {
    private readonly CorgiDbContext _context;
    private readonly IUserFactory _userFactory;

    public AccountService(CorgiDbContext context, IUserFactory userFactory) {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _userFactory = userFactory ?? throw new ArgumentNullException(nameof(userFactory));
    }

    public object RegisterNewAccount(UserDto userDto) {
        if (_context.Users.Any(u => u.Email == userDto.Email)) {
            // user already exists
            // TODO: https://code-maze.com/aspnetcore-result-pattern/
            return new { message = "Email address already exists!" };
        }

        var user = _userFactory.CreateUserFromDto(userDto);

        if (user is not User createdUser) {
            return false;
        }

        _context.Users.Add(createdUser);
        _context.SaveChanges();

        return true;
    }

    public bool LoginAccount(UserDto userDto) {
        var user = _context.Users.FirstOrDefault(u => u.Email == userDto.Email);
        
        if (user is null) {
            // User doesnt exists
            return false;
        }
        
        Console.WriteLine("Can login");
        return user.Password == userDto.Password;
    }

    public User? GetUserByEmail(string email) {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);

        // user.AccountStatistics = new AccountStatistics();
        // _context.Users.Update(user);
        // _context.SaveChanges();

        return user;
    }

    public User? GetUserById(int id) {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        return user;
    }
}