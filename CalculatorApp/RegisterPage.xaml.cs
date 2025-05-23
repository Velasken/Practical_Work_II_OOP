using System.IO;

namespace CalculatorApp;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
    {
        InitializeComponent();
    }

    // Event handler for the Exit button
    private async void OnExitClicked(object sender, EventArgs e)
    {
        // Saves current user data before exiting
        MainPage.SaveUserData();

        // Exits the application
        Application.Current.Quit();
    }

    // Event handler for the Back button
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(".."); // Navigates back to the previous page
    }

    // Checks if a user already exists
    private bool UserAlreadyExists(string username, string email, string password)
    {
        foreach (User user in MainPage.Users)
        {
            // Returns true if any of the fields already exist in the list
            if (user.username == username || user.email == email || user.password == password)
            {
                return true;
            }
        }
        return false;
    }

    // Validates if the password complies with all the required parameters
    private bool IsValidPassword(string password)
    {
        if (password.Length < 8)
            return false;

        bool hasUpper = false;
        bool hasLower = false;
        bool hasDigit = false;
        bool hasSpecial = false;

        // Checks for at least one uppercase, lowercase, digit, and special character
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

        // Returns true only if all four conditions are met
        return hasUpper && hasLower && hasDigit && hasSpecial;
    }

    // Event handler for the Submit button click
    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        // Ensures both password fields match
        if (NewPasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
            await DisplayAlert("Error", "Passwords do not match", "OK");
        }
        // Ensures username and email are not the same
        else if (NewUsernameEntry.Text == NewUseremailEntry.Text)
        {
           await DisplayAlert("Error", "The name can not be the same as the email", "OK");
        }
        // Checks if the user data already exists in the system
        else if (UserAlreadyExists(NewUsernameEntry.Text, NewUseremailEntry.Text, NewPasswordEntry.Text))
        {
            await DisplayAlert("Error", "Username, email or password already taken", "OK");
        }
        // Validates that none of the required fields are empty
        else if(NewPasswordEntry.Text == null || ConfirmPasswordEntry.Text == null || NewUsernameEntry.Text == null || NewUseremailEntry.Text == null)
        {
            await DisplayAlert("Error", "You have to fill all the boxes", "OK");
        }
        // Validates if the password complies with all the required parameters
        else if (!IsValidPassword(NewPasswordEntry.Text))
        {
            await DisplayAlert("Error", "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.", "OK");
        }
        // Check if the user has accepted the privacy policy
        else if (PolicyAgreementCheckBox.IsChecked == false)
        {
            await DisplayAlert("Error", "You must agree to the Protection Policy to register", "OK");
        }
        else
        {
            // Creates a new User object with provided credentials
            User newUser = new User(NewUsernameEntry.Text, NewUseremailEntry.Text, NewPasswordEntry.Text);

            // Adds new user to the static Users list in MainPage
            MainPage.Users.Add(newUser);

            // Saves the new user in the users list
            MainPage.SaveUserData();

            // Displays success message
            await DisplayAlert("Success", $"Registered {NewUsernameEntry.Text}", "OK");

            // Navigates back to the login page
            await Shell.Current.GoToAsync(".."); // navigate back to login
        }
    }
    
}

