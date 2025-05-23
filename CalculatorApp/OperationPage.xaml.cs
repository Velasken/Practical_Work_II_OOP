using System.IO;


namespace CalculatorApp;

public partial class OperationsPage : ContentPage
{
    public OperationsPage()
    {
        InitializeComponent();

        // Display the logged-in user's information on the labels
        UsernameLabel.Text = $"Username: {MainPage.LoggedUser.username}";
        EmailLabel.Text = $"Email: {MainPage.LoggedUser.email}";
        PasswordLabel.Text = $"Password: {MainPage.LoggedUser.password}";
        OperationsCountLabel.Text = $"Operations done: {MainPage.LoggedUser.operationsCount}";
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        // Saves current user data before exiting
        MainPage.SaveUserData();

        // Exits the application
        Application.Current.Quit();
    }
    private async void OnConversorClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ConversorPage"); // Navigate to the ConversorPage
    }
    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        MainPage.SaveUserData(); // Saves current user data before logout
        await Shell.Current.GoToAsync("../.."); // Navigate back to login
    }
    
}

