namespace CalculatorApp;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        if (NewPasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
            await DisplayAlert("Error", "Passwords do not match", "OK");
            return;
        }

        await DisplayAlert("Success", $"Registered {NewUsernameEntry.Text}", "OK");
        await Shell.Current.GoToAsync(".."); // navigate back to login
    }
}

