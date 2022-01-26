using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaDeCadastro
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WelcomePage()) { BarBackgroundColor = Color.FromHex("#000000") };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
