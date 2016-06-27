using FreshMvvm;
using QueimaApp.DataAccess;
using QueimaApp.Interfaces;
using QueimaApp.Pages;
using QueimaApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace QueimaApp
{

    public partial class App : Application
    {
        static QueimaRepository QueimaDbUtil;

        public static QueimaRepository QueimaDA
        {
            get
            {
                if (QueimaDbUtil == null)
                {
                    QueimaDbUtil = new QueimaRepository();
                }
                return QueimaDbUtil;
            }
        }

        public App()
        {
            FreshIOC.Container.Register<IDatabaseService, DatabaseService>();
            //MainPage = new CustomImplementedNav();
            MainPage = new MasterPage();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
