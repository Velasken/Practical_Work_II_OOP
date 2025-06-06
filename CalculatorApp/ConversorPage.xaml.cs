using oppguidedpw;

namespace CalculatorApp;

public partial class ConversorPage : ContentPage
{
    // Instance of the Converter class used for performing conversions
    Converter converter = new Converter();

    // Instance of the Operations class to manage the operations
    Operations ops = new Operations(";");
	public ConversorPage()
    {
        InitializeComponent();
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        ops.SaveOperations("Practical_Work_II_OOP/Files/operations.csv");
        MainPage.SaveUserData();
        Application.Current.Quit();
    }

    // Navigates to the operations page
    private async void OnOperationsClicked(object sender, EventArgs e)
    {
        //Saves the done operations in a file
        ops.SaveOperations("Practical_Work_II_OOP/Files/operations.csv");
        
        await Shell.Current.GoToAsync("OperationsPage"); 
    }
    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        ops.SaveOperations("Practical_Work_II_OOP/Files/operations.csv");
        MainPage.SaveUserData();
        await Shell.Current.GoToAsync(".."); 
    }

    // Input number buttons
    private void On7Clicked(object sender, EventArgs e)
    {
        NumberLabel.Text +=7;
    }
    private void On8Clicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +=8;
    }
    private void On9Clicked(object sender, EventArgs e)
    {
        NumberLabel.Text +=9;
    }
    private void On4Clicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +=4;
    }
    private void On5Clicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +=5;
    }
    private void On6Clicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +=6;
    }
    private void On1Clicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +=1;
    }
    private void On2Clicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +=2;
    }
    private void On3Clicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +=3;
    }
    private void On0Clicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +=0;
    }

    // Clear the NumberLabel text
    private void OnACClicked(object sender, EventArgs e) 
    {
        NumberLabel.Text = string.Empty;
    }

    // Minus simbol for two complement operations
    private void OnMinusClicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +="-";
    }

    // Hexadecimal inputs
    private void OnAClicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +="A";
    }
    private void OnBClicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +="B";
    }
    private void OnCClicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +="C";
    }
    private void OnDClicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +="D";
    }
    private void OnEClicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +="E";
    }
    private void OnFClicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +="F";
    }

    //Operations selection bottons
    private async void OnDecimalToBinaryClicked(object sender, EventArgs e) 
    {
        //Operation to be done in converter.cs
        int operation = 1;

        // Input number to convert
        string input = NumberLabel.Text;
        string output = "";
        int error = 0;
        string errorMessage = "";

        try
        {
            // Perform the conversion
            output = converter.PerformConversion(operation, input);

            // Display the result in the label
            NumberLabel.Text = output;
        }

        //Error handling
        catch(OverflowException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");

            // Clean the label when there has been an error 
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }

        // Add the done operation to the operation file
        ops.AddOperations(input, output, operation, error, errorMessage);

        // Increment the user's operations count
        MainPage.LoggedUser.operationsCount++;
    }
    private async void OnDecimalToTwoComplementClicked(object sender, EventArgs e) 
    {
        int operation = 4;
        string input = NumberLabel.Text;
        string output = "";
        int error = 0;
        string errorMessage = "";

        try
        {
            output = converter.PerformConversion(operation, input);
            NumberLabel.Text = output;
        }
        catch(OverflowException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }

        ops.AddOperations(input, output, operation, error, errorMessage);
        MainPage.LoggedUser.operationsCount++;
    }
    private async void OnDecimalToOctalClicked(object sender, EventArgs e) 
    {
        int operation = 2;
        string input = NumberLabel.Text;
        string output = "";
        int error = 0;
        string errorMessage = "";

        try
        {
            output = converter.PerformConversion(operation, input);
            NumberLabel.Text = output;
        }
        catch(OverflowException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }

        ops.AddOperations(input, output, operation, error, errorMessage);
        MainPage.LoggedUser.operationsCount++;
    }
    private async void OnDecimalToHexadecimalClicked(object sender, EventArgs e) 
    {
        int operation = 3;
        string input = NumberLabel.Text;
        string output = "";
        int error = 0;
        string errorMessage = "";

        try
        {
            output = converter.PerformConversion(operation, input);
            NumberLabel.Text = output;
        }
        catch(OverflowException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }

        ops.AddOperations(input, output, operation, error, errorMessage);
        MainPage.LoggedUser.operationsCount++;
    }
    private async void OnBinaryToDecimalClicked(object sender, EventArgs e) 
    {
        int operation = 5;
        string input = NumberLabel.Text;
        string output = "";
        int error = 0;
        string errorMessage = "";

        try
        {
            output = converter.PerformConversion(operation, input);
            NumberLabel.Text = output;
        }
        catch(OverflowException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }

        ops.AddOperations(input, output, operation, error, errorMessage);
        MainPage.LoggedUser.operationsCount++;
    }
    private async void OnTwoComplementToDecimalClicked(object sender, EventArgs e) 
    {
        int operation = 6;
        string input = NumberLabel.Text;
        string output = "";
        int error = 0;
        string errorMessage = "";

        try
        {
            output = converter.PerformConversion(operation, input);
            NumberLabel.Text = output;
        }
        catch(OverflowException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }

        ops.AddOperations(input, output, operation, error, errorMessage);
        MainPage.LoggedUser.operationsCount++;
    }
    private async void OnOctalToDecimalClicked(object sender, EventArgs e) 
    {
        int operation = 7;
        string input = NumberLabel.Text;
        string output = "";
        int error = 0;
        string errorMessage = "";

        try
        {
            output = converter.PerformConversion(operation, input);
            NumberLabel.Text = output;
        }
        catch(OverflowException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }

        ops.AddOperations(input, output, operation, error, errorMessage);
        MainPage.LoggedUser.operationsCount++;
    }
    private async void OnHexadecimalToDecimalClicked(object sender, EventArgs e) 
    {
        int operation = 8;
        string input = NumberLabel.Text;
        string output = "";
        int error = 0;
        string errorMessage = "";

        try
        {
            output = converter.PerformConversion(operation, input);
            NumberLabel.Text = output;
        }
        catch(OverflowException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            error = 1;
            errorMessage = ex.Message;
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }

        ops.AddOperations(input, output, operation, error, errorMessage);
        MainPage.LoggedUser.operationsCount++;
    }

}

