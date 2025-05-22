using System.IO;

namespace CalculatorApp;

public partial class MainPage : ContentPage
{
    public static List<User> Users = new List<User>();
    public static User LoggedUser;

    public MainPage()
    {
        InitializeComponent();
        LoadUserData();
    }

    public async static void LoadUserData()
    {
        string separator = ",";
        var path = "Practical_Work_II_OOP/Files/user_data.csv";
        StreamReader sr = null;

        try
        {
            sr = File.OpenText(path);

            Users.Clear();

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

                    Users.Add(new User(username, email, password, operations));
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
            sr?.Close();
        }
    }

    public async static void SaveUserData()
    {
        string separator = ",";
        var path = "Practical_Work_II_OOP/Files/user_data.csv";
        StreamWriter sw = null;

        try
        {
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
            sw?.Close();
        }
    }

    private static bool UserExists(string username, string password)
    {
        foreach (User user in Users)
        {
            if (user.username == username && user.password == password)
                return true;
        }
        return false;
    }

    private static User GetUser(string username, string password)
    {
        foreach (User user in Users)
        {
            if (user.username == username && user.password == password)
                return user;
        }
        return null;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        if (UserExists(UsernameEntry.Text, PasswordEntry.Text))
        {
            User user = GetUser(UsernameEntry.Text, PasswordEntry.Text);
            LoggedUser = user;
            await DisplayAlert("Success", $"Welcome {UsernameEntry.Text}!", "OK");
            await Shell.Current.GoToAsync("ConversorPage");
            UsernameEntry.Text = string.Empty;
            PasswordEntry.Text = string.Empty;
        }
        else
        {
            await DisplayAlert("Error", "Invalid credentials", "Try Again");
        }
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("RegisterPage");
        UsernameEntry.Text = string.Empty;
        PasswordEntry.Text = string.Empty;
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        SaveUserData();
        Application.Current.Quit();
    }
}