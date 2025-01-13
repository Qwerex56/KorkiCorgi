using KorkiCorgi.DataTransferObjects;
using KorkiCorgi.Models.Enums;

namespace KorkiCorgi.Models.ModelFactory;

public class UserFactory : IUserFactory {
    public IUser CreateUser(string name, string surname) =>
        new User { Name = name, Surname = surname };
    
    public IUser CreateUserFromDto(UserDto userDto) {
        var user = new User {
            Email = userDto.Email,
            Password = userDto.Password,
            AccountType = userDto.AccountType
        };

        if (user.AccountType == AccountType.Tutor) {
            user.AccountStatistics = new();
        }

        return user;
    }
}