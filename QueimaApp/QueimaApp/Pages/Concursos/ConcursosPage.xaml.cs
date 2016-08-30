using FreshMvvm;
using QueimaApp.PageModels;
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
    public partial class ConcursosPage : TabbedPage
    {
        public ConcursosPage()
        {
            ToolbarItems.Add(new ToolbarItem("", "Home.png", () =>
            {
                Application.Current.MainPage = new NavigationPage(new LaunchPage((App)Application.Current));
            }));
            var djPage = FreshPageModelResolver.ResolvePageModel<ConcursoDjPageModel>();
            var cartazPage = FreshPageModelResolver.ResolvePageModel<ConcursoCartazPageModel>();
            var bandasPage = FreshPageModelResolver.ResolvePageModel<ConcursoBandasPageModel>();
            djPage.Title = "DJ";
            cartazPage.Title = "Cartaz";
            bandasPage.Title = "Bandas";
            djPage.Icon = "icon.png";
            cartazPage.Icon = "icon.png";
            bandasPage.Icon = "icon.png";
            this.BarBackgroundColor = (Color)Application.Current.Resources["BrandColorDark"];
            this.Children.Add(djPage);
            this.Children.Add(cartazPage);
            this.Children.Add(bandasPage);
            InitializeComponent();
        }
    }
}
