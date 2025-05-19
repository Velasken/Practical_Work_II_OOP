namespace CalculatorApp;

public partial class OperationsPage : ContentPage
{
    public OperationsPage()
    {
        InitializeComponent();
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }
    private async void OnConversorClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ConversorPage"); 
    }
    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("../.."); 
    }
    
}

