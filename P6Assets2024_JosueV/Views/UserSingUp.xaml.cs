using P6Assets2024_JosueV.ViewModels;
using P6Assets2024_JosueV.Models;

namespace P6Assets2024_JosueV.Views;

public partial class UserSingUp : ContentPage
{
	//PARA PODER COMUNICARSE CON LA BASE DE DATOS DEBEMOS PASAR LAS OPERACIONES
	//POR MEDIO DEL VIEWMODEL, QUE SE ENCARGA DE INTERMEDIAR DICHAS OPERACIONES

	UserViewModel? vm;


	public UserSingUp()
	{
		InitializeComponent();

		BindingContext = vm = new UserViewModel();

		//Y ahora llamamos a la funcion que se encarga de llenar el picker
		//con los datos de los roles de Usuario

		LoadUserRoles();
	}

	private async void LoadUserRoles() 
	{

		CboxUserRole.ItemsSource = await vm.GetAllUserRolesAsync();
	
	}

    private async void BtnCancel_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}