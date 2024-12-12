namespace KorkiCorgi.Models.ModelFactory;

public interface IUserFactory {
    IUser CreateUser(string name, string surname);
}