using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QueimaApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginFacebookMockPage : ContentPage
    {
        public LoginFacebookMockPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            TestConnection();
            base.OnAppearing();
        }
        private void TestConnection()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Alerta", "Tem acesso", "Ok");
            }

        }
    }
}
