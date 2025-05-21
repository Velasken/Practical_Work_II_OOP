namespace CalculatorApp;

public partial class MainPage : ContentPage
{
    public static List<User> Users = new List<User>();
    public static User LoggedUser;

	public MainPage()
	{
		InitializeComponent();
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
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }
}

