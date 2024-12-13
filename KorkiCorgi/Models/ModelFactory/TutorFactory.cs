namespace KorkiCorgi.Models.ModelFactory;

public class TutorFactory : IUserFactory {
    public IUser CreateUser(string name, string surname) =>
        new TutorUser();
}