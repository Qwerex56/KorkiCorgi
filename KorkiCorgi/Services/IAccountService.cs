using KorkiCorgi.DataTransferObjects;
using KorkiCorgi.Models;

namespace KorkiCorgi.Services;

public interface IAccountService {
    public object RegisterNewAccount(UserDto userDto);
    public bool LoginAccount(UserDto userDto);
    public User? GetUserByEmail(string email);
    public User? GetUserById(int id);
}