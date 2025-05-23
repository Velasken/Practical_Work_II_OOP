using System.IO;

namespace CalculatorApp;

public partial class ForgotpasswordPage : ContentPage
{
    public ForgotpasswordPage()
    {
        InitializeComponent();
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

    // Event handler for the Submit button
    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        string usernameToUpdate = UsernameEntry.Text; // Username entered by the user
        string newPassword = NewPasswordEntry.Text; // New password entered by the user
        string path = "Practical_Work_II_OOP/Files/user_data.csv";
        string separator = ",";

        bool userFound = false; // Check if the user exists

        // Update the user in use first
        for (int i = 0; i < MainPage.Users.Count; i++)
        {
            if (MainPage.Users[i].username == usernameToUpdate)
            {
                MainPage.Users[i].password = newPassword; // Set the new password
                userFound = true; // User exists
            }
        }

        // Handle possible unwanted scenarios
        if (!userFound)
        {
            await DisplayAlert("Error", "Wrong username", "OK");
        }
        else if(NewPasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
            await DisplayAlert("Error", "The password confirmations has to be the same as the introduced password", "OK");
        }
        else if(NewPasswordEntry.Text == null || ConfirmPasswordEntry.Text == null || UsernameEntry.Text == null)
        {
            await DisplayAlert("Error", "You have to fill all the boxes", "OK");
        }
        else if (!IsValidPassword(NewPasswordEntry.Text))
        {
            await DisplayAlert("Error", "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.", "OK");
        }
        else
        {
            // Update CSV file
            try
            {
                string[] lines = File.ReadAllLines(path); // Read all lines from the file

                for (int j = 0; j < lines.Length; j++)
                {
                    string line = lines[j];
                    string[] parts = line.Split(separator);

                    if (parts.Length >= 3 && parts[0] == usernameToUpdate)
                    {
                        parts[2] = newPassword; // Update the password 

                        // Reconstruct the files lines with the new lines 
                        string newLine = parts[0];
                        for (int s = 1; s < parts.Length; s++)
                        {
                            newLine += separator + parts[s];
                        }

                        lines[j] = newLine; // Replace the old line with the updated one
                    }
                }

                File.WriteAllLines(path, lines);

                await DisplayAlert("Success", "Password updated successfully.", "OK");
                await Shell.Current.GoToAsync(".."); // Write the updated lines back to the file
            }
            catch (IOException ex)
            {
               await DisplayAlert("File Error", ex.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        // Saves current user data before exiting
        MainPage.SaveUserData();

        // Exits the application
        Application.Current.Quit();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(".."); // Navigate back to Login
    }
}