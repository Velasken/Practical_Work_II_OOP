namespace CalculatorApp;

public partial class ConversorPage : ContentPage
{
	public ConversorPage()
    {
        InitializeComponent();
    }

    private async void OnOperationsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("OperationsPage"); 
    }
    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(".."); 
    }
}

