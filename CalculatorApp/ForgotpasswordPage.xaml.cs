using System.IO;

namespace CalculatorApp;

public partial class ForgotpasswordPage : ContentPage
{
    public ForgotpasswordPage()
    {
        InitializeComponent();
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
                break;
            }
        }

        if (!userFound)
        {
            await DisplayAlert("Error", "Wrong username", "OK");
            return;
        }

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
                    break;
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

    private async void OnExitClicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}