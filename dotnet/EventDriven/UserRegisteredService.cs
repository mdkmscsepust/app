public class UserRegisteredService
{
    public event EventHandler<UserRegisteredEventArgs>? UserRegistered;

    public void RegisteredUser(string username, string email)
    {
        OnUserRegistered(new UserRegisteredEventArgs(username, email));
    }
    public virtual void OnUserRegistered(UserRegisteredEventArgs e)
    {
        UserRegistered?.Invoke(this, e);
    }
}