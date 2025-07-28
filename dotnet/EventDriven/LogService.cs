public class LogService
{
    public void RegisteredUser(object sender, UserRegisteredEventArgs e)
    {
        Console.WriteLine($"Log: User registered - Username: {e.Username}, Email: {e.Email}");
    }
}