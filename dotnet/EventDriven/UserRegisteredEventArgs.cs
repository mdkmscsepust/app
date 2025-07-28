public class UserRegisteredEventArgs : EventArgs
{
    public string Username { get; }
    public string Email { get; }
    public UserRegisteredEventArgs(string username, string email)
    {
        Username = username;
        Email = email;
    }
}