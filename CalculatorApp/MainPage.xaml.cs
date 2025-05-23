using System.IO;

namespace CalculatorApp;

// MainPage acts as the login screen
public partial class MainPage : ContentPage
{
    // Static list of users and the currently logged-in user.
    public static List<User> Users = new List<User>();
    public static User LoggedUser;

    public MainPage()
    {
        InitializeComponent();
        LoadUserData();
    }

    // Loads user data from a CSV file into the Users list
    public async static void LoadUserData()
    {
        string separator = ",";
        var path = "Practical_Work_II_OOP/Files/user_data.csv";
        StreamReader sr = null;

        try
        {
            sr = File.OpenText(path);

            Users.Clear(); // Clear existing users

            string headerLine = sr.ReadLine();
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                var parts = line.Split(separator);
                if (parts.Length >= 4)
                {
                    string username = parts[0];
                    string email = parts[1];
                    string password = parts[2];
                    int operations = Int32.Parse(parts[3]);

                    Users.Add(new User(username, email, password, operations)); // Adds a new User object to the list
                }
            }
        }
        catch (IOException)
        {
        }
        catch (Exception)
        {
        }
        finally
        {
            sr?.Close(); // Closes the stream reader
        }
    }

    // Saves the current state of the Users list to the CSV file
    public async static void SaveUserData()
    {
        string separator = ",";
        var path = "Practical_Work_II_OOP/Files/user_data.csv";
        StreamWriter sw = null;

        try
        {
            // Update the logged-in user's operations count
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].username == LoggedUser.username && Users[i].email == LoggedUser.email)
                {
                    Users[i].operationsCount = LoggedUser.operationsCount;
                }
            }

            sw = File.CreateText(path);

            string header = "username" + separator + "email" + separator + "password" + separator + "Operations";
            sw.WriteLine(header);

            // Write each user's data
            foreach (var user in Users)
            {
                sw.WriteLine(
                    user.username + separator +
                    user.email + separator +
                    user.password + separator +
                    user.operationsCount
                );
            }
        }
        catch (IOException)
        {
        }
        catch (Exception)
        {
        }
        finally
        {
            sw?.Close(); // Closes the stream writer
        }
    }

    // Checks if a user exists
    private static bool UserExists(string username, string password)
    {
        foreach (User user in Users)
        {
            if (user.username == username && user.password == password)
                return true; //Founded user
        }
        return false; //Not founded user
    }

    // Retrieves a user object based on username and password
    private static User GetUser(string username, string password)
    {
        foreach (User user in Users)
        {
            if (user.username == username && user.password == password)
                return user;
        }
        return null;
    }

    // Event handler for Login button click
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        if (UserExists(UsernameEntry.Text, PasswordEntry.Text))
        {
            // Logs in the user and navigates to the ConversorPage
            User user = GetUser(UsernameEntry.Text, PasswordEntry.Text);
            LoggedUser = user;
            await Shell.Current.GoToAsync("ConversorPage");

            // Clears input fields
            UsernameEntry.Text = string.Empty;
            PasswordEntry.Text = string.Empty;
        }
        else
        {
            // Shows error if login fails
            await DisplayAlert("Error", "Invalid credentials", "Try Again");
        }
    }
    
    // Event handler for Register button click
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        // Navigates to the Register page
        await Shell.Current.GoToAsync("RegisterPage");

        // Clears input fields
        UsernameEntry.Text = string.Empty;
        PasswordEntry.Text = string.Empty;
    }

    // Event handler for Forgot Password tap
    private async void OnForgotPasswordTapped(object sender, EventArgs e)
    {
        // Navigates to Forgot Password page
        await Shell.Current.GoToAsync("ForgotpasswordPage");

        // Clears input fields
        UsernameEntry.Text = string.Empty;
        PasswordEntry.Text = string.Empty;
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        // Saves current user data before exiting
        SaveUserData();

        // Exits the application
        Application.Current.Quit();
    }
}