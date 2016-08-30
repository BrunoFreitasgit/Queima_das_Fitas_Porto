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
    public partial class TransportesPage : TabbedPage
    {
        public TransportesPage()
        {
            InitializeComponent();
            ToolbarItems.Add(new ToolbarItem("", "Home.png", () =>
            {
                Application.Current.MainPage = new NavigationPage(new LaunchPage((App)Application.Current));
            }));
            var taxiPage = FreshPageModelResolver.ResolvePageModel<TransporteTaxiPageModel>();
            var stcpPage = FreshPageModelResolver.ResolvePageModel<TransporteSTCPPageModel>();
            var metroPage = FreshPageModelResolver.ResolvePageModel<TransporteMetroPageModel>();
            taxiPage.Title = "Taxi";
            stcpPage.Title = "STCP";
            metroPage.Title = "Metro";
            taxiPage.Icon = "icon.png";
            stcpPage.Icon = "icon.png";
            metroPage.Icon = "icon.png";
            this.BarBackgroundColor = (Color)Application.Current.Resources["BrandColorDark"];
            this.Children.Add(stcpPage);
            this.Children.Add(metroPage);
            this.Children.Add(taxiPage);
        }
    }
}
