namespace CalculatorApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnLoginClicked(object sender, EventArgs e)
    {
        /*if (UsernameEntry.Text == "admin" && PasswordEntry.Text == "1234")
        {
            await DisplayAlert("Success", "Logged in!", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Invalid credentials", "Try Again");
        }*/
        await Shell.Current.GoToAsync("ConversorPage");
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

