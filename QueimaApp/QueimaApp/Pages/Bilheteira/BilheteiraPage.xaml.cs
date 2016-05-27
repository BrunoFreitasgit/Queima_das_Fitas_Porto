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
    public partial class BilheteiraPage : TabbedPage
    {
        public BilheteiraPage()
        {
            ToolbarItems.Add(new ToolbarItem("", "Home.png", () =>
            {
                Application.Current.MainPage = new NavigationPage(new LaunchPage((App)Application.Current));
            }));

            var pontosVendaPage = FreshPageModelResolver.ResolvePageModel<PontoVendaListPageModel>();
            var bilhetesPage = FreshPageModelResolver.ResolvePageModel<BilhetesPageModel>();
            pontosVendaPage.Title = "Pontos de Venda";
            bilhetesPage.Title = "Bilhetes";
            pontosVendaPage.Icon = "icon.png";
            bilhetesPage.Icon = "icon.png";
            this.Children.Add(pontosVendaPage);
            this.Children.Add(bilhetesPage);
            InitializeComponent();
        }
    }
}
