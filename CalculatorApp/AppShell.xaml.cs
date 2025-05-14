namespace CalculatorApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
		Routing.RegisterRoute("Conversor", typeof(ConversorPage));
		Routing.RegisterRoute("Operations", typeof(OperationsPage));
	}
}
