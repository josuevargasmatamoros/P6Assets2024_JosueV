using P6Assets2024_JosueV.Views;
namespace P6Assets2024_JosueV
    
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
