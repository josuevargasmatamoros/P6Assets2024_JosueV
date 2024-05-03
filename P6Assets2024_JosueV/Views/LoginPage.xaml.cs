namespace P6Assets2024_JosueV.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void SwVerPassword_Toggled(object sender, ToggledEventArgs e)
    {
        if(SwVerPassword.IsToggled)
        {
            TxtPassword.IsPassword = false;
        }
        else
        {
            TxtPassword.IsPassword = true;
        }
    }

    private async void BtnIngresar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OptionPage());
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

    private async void BtnSingUp_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserSingUp());
    }
}