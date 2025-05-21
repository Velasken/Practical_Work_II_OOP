namespace CalculatorApp;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }

    private bool UserAlreadyExists(string username, string email, string password)
    {
        foreach (User user in MainPage.Users)
        {
            if (user.username == username || user.email == email || user.password == password)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsValidPassword(string password)
    {
        if (password.Length < 8)
            return false;

        bool hasUpper = false;
        bool hasLower = false;
        bool hasDigit = false;
        bool hasSpecial = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c))
                hasUpper = true;
            else if (char.IsLower(c))
                hasLower = true;
            else if (char.IsDigit(c))
                hasDigit = true;
            else
                hasSpecial = true;
        }

        return hasUpper && hasLower && hasDigit && hasSpecial;
    }
    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        if (NewPasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
            await DisplayAlert("Error", "Passwords do not match", "OK");
        }
        else if (NewUsernameEntry.Text == NewUseremailEntry.Text)
        {
           await DisplayAlert("Error", "The name can not be the same as the email", "OK");
        }
        else if (UserAlreadyExists(NewUsernameEntry.Text, NewUseremailEntry.Text, NewPasswordEntry.Text))
        {
            await DisplayAlert("Error", "Username, email or password already taken", "OK");
        }
        else if(NewPasswordEntry.Text == null || ConfirmPasswordEntry.Text == null || NewUsernameEntry.Text == null || NewUseremailEntry.Text == null)
        {
            await DisplayAlert("Error", "You have to fill all the boxes", "OK");
        }
        else if (!IsValidPassword(NewPasswordEntry.Text))
        {
            await DisplayAlert("Error", "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.", "OK");
        }
        else
        {
            User newUser = new User(NewUsernameEntry.Text, NewUseremailEntry.Text, NewPasswordEntry.Text);

            MainPage.Users.Add(newUser);
            await DisplayAlert("Success", $"Registered {NewUsernameEntry.Text}", "OK");
            await Shell.Current.GoToAsync(".."); // navigate back to login
        }
    }
    
}

