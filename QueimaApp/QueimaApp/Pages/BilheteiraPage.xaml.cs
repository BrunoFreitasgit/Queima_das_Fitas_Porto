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
            var contactPage = FreshPageModelResolver.ResolvePageModel<PontoVendaListPageModel>();
            var quotePage = FreshPageModelResolver.ResolvePageModel<QuoteListPageModel>();
            contactPage.Title = "Pontos de Venda";
            quotePage.Title = "Quote";
            contactPage.Icon = "icon.png";
            quotePage.Icon = "icon.png";
            this.Children.Add(contactPage);
            this.Children.Add(quotePage);
            InitializeComponent();
        }
    }
}
