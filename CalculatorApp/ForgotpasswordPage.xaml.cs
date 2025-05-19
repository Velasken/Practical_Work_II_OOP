namespace CalculatorApp;

public partial class ForgotpasswordPage : ContentPage
{
	public ForgotpasswordPage()
    {
        InitializeComponent();
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }
    
}

