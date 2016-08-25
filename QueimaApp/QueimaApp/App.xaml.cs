using FreshMvvm;
using QueimaApp.DataAccess;
using QueimaApp.Interfaces;
using QueimaApp.Pages;
using QueimaApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace QueimaApp
{

    public partial class App : Application
    {
        static QueimaRepository QueimaDb;

        public static QueimaRepository QueimaDA
        {
            get
            {
                if (QueimaDb == null)
                {
                    QueimaDb = new QueimaRepository();
                }
                return QueimaDb;
            }
        }

        public App()
        {
            InitializeComponent();
            FreshIOC.Container.Register<IDatabaseService, DatabaseService>();
            FreshIOC.Container.Register<IRestService, RestService>();
            FreshIOC.Container.Register<IQueimaRepository, QueimaRepository>();
            //FreshIOC.Container.Register<>
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
