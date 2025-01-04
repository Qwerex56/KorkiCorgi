using KorkiCorgi.DataTransferObjects;
using KorkiCorgi.Models;

namespace KorkiCorgi.Services;

public interface IAccountService {
    public object RegisterNewAccount(UserDto userDto);
    public User? GetUserByEmail(string email);
}