using System.IO;

namespace CalculatorApp;

public partial class ForgotpasswordPage : ContentPage
{
    public ForgotpasswordPage()
    {
        InitializeComponent();
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
        string usernameToUpdate = UsernameEntry.Text;
        string newPassword = NewPasswordEntry.Text;
        string path = "Practical_Work_II_OOP/Files/user_data.csv";
        string separator = ",";

        bool userFound = false;

        // First update in-memory list
        for (int i = 0; i < MainPage.Users.Count; i++)
        {
            if (MainPage.Users[i].username == usernameToUpdate)
            {
                MainPage.Users[i].password = newPassword;
                userFound = true;
                //break;
            }
        }

        if (!userFound)
        {
            await DisplayAlert("Error", "Wrong username", "OK");
            return;
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
            // Then update CSV file
            try
            {
                string[] lines = File.ReadAllLines(path);

                for (int j = 0; j < lines.Length; j++)
                {
                    string line = lines[j];
                    string[] parts = line.Split(separator);

                    if (parts.Length >= 3 && parts[0] == usernameToUpdate)
                    {
                        parts[2] = newPassword;

                        string newLine = parts[0];
                        for (int x = 1; x < parts.Length; x++)
                        {
                            newLine += separator + parts[x];
                        }

                        lines[j] = newLine;
                        //break;
                    }
                }

                File.WriteAllLines(path, lines);

                await DisplayAlert("Success", "Password updated successfully.", "OK");
                await Shell.Current.GoToAsync("..");
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
        Application.Current.Quit();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}