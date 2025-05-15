namespace CalculatorApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
		Routing.RegisterRoute("ConversorPage", typeof(ConversorPage));
		Routing.RegisterRoute("OperationsPage", typeof(OperationsPage));
	}
}
