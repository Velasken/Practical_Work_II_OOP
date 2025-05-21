using System.IO;


namespace CalculatorApp;

public partial class OperationsPage : ContentPage
{
    public OperationsPage()
    {
        InitializeComponent();

        UsernameLabel.Text = $"Username: {MainPage.LoggedUser.username}";
        EmailLabel.Text = $"Email: {MainPage.LoggedUser.email}";
        PasswordLabel.Text = $"Password: {MainPage.LoggedUser.password}";
        OperationsCountLabel.Text = $"Operations done: {MainPage.LoggedUser.operationsCount}";
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        MainPage.SaveUserData();
        Application.Current.Quit();
    }
    private async void OnConversorClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ConversorPage"); 
    }
    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        MainPage.SaveUserData();
        await Shell.Current.GoToAsync("../.."); 
    }
    
}

