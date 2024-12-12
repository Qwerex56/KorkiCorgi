namespace KorkiCorgi.Models.ModelFactory;

public class StudentFactory : IUserFactory {
    public IUser CreateUser(string name, string surname) =>
        new StudentUser { Name = name, Surname = surname, AccountInformation = { } };
}