using oppguidedpw;

namespace CalculatorApp;

public partial class ConversorPage : ContentPage
{
    Converter converter = new Converter();
    //Operations operations = new Operations();
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
    private void OnACClicked(object sender, EventArgs e) 
    {
        NumberLabel.Text = string.Empty;
    }
    private void OnMinusClicked(object sender, EventArgs e) 
    {
        NumberLabel.Text +="-";
    }
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
    private async void OnDecimalToBinaryClicked(object sender, EventArgs e) 
    {
        try
        {
            string res = converter.PerformConversion(1, NumberLabel.Text);
            NumberLabel.Text = res;
        }
        catch(OverflowException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
    }
    private async void OnDecimalToTwoComplementClicked(object sender, EventArgs e) 
    {
        try
        {
            string res = converter.PerformConversion(4,NumberLabel.Text);
            NumberLabel.Text = res;
        }
        catch(OverflowException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
    }
    private async void OnDecimalToOctalClicked(object sender, EventArgs e) 
    {
        try
        {
            string res = converter.PerformConversion(2,NumberLabel.Text);
            NumberLabel.Text = res;
        }
        catch(OverflowException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
    }
    private async void OnDecimalToHexadecimalClicked(object sender, EventArgs e) 
    {
        try
        {
            string res = converter.PerformConversion(3,NumberLabel.Text);
            NumberLabel.Text = res;
        }
        catch(OverflowException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
    }
    private async void OnBinaryToDecimalClicked(object sender, EventArgs e) 
    {
        try
        {
            string res = converter.PerformConversion(5,NumberLabel.Text);
            NumberLabel.Text = res;
        }
        catch(OverflowException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
    }
    private async void OnTwoComplementToDecimalClicked(object sender, EventArgs e) 
    {
        try
        {
            string res = converter.PerformConversion(6,NumberLabel.Text);
            NumberLabel.Text = res;
        }
        catch(OverflowException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
    }
    private async void OnOctalToDecimalClicked(object sender, EventArgs e) 
    {
        try
        {
            string res = converter.PerformConversion(7,NumberLabel.Text);
            NumberLabel.Text = res;
        }
        catch(OverflowException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
    }
    private async void OnHexadecimalToDecimalClicked(object sender, EventArgs e) 
    {
        try
        {
            string res = converter.PerformConversion(8,NumberLabel.Text);
            NumberLabel.Text = res;
        }
        catch(OverflowException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch(FormatException ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
            NumberLabel.Text = string.Empty;
        }
    }

}

