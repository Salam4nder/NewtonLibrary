namespace NewtonLibraryManager.Handlers;

public static class AccountHandler
{
    private static bool _loggedIn;
    public static bool LoggedIn => _loggedIn;

    public static bool LogIn(string email, string password)
    {
        var listOfUsers = EntityFramework.Read.ReadHandler.GetUsers();
        
        foreach (var user in listOfUsers)
            if (email == user.EMail && password == user.Password)
            {
                _loggedIn = true;
                return true;
            }
        return false;
    }

    public static void LogOut() => _loggedIn = false;

    public static bool CreateUser(string firstName, string lastName, string email, string password)
    {
        try
        {
            EntityFramework.Create.CreateHandler.CreateUser(firstName, lastName, email, password, false);
            return true;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
            return false;
        }
    }
    public static bool CreateAdmin(string firstName, string lastName, string email, string password)
    {
        try
        {
            EntityFramework.Create.CreateHandler.CreateUser(firstName, lastName, email, password, true);
            return true;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
            return false;
        }
    }

    public static bool DeleteUser(int userId)
    {
        var listOfUsers = EntityFramework.Read.ReadHandler.GetUsers();

        try
        {
            EntityFramework.Delete.DeleteHandler.DeleteUser(listOfUsers, userId);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
            return false;
        }
    }
}