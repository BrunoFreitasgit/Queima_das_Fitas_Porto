using QueimaApp.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QueimaApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AtividadesListPage : BasePage
    {
        public AtividadesListPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            listView.SelectedItem = null;
            base.OnAppearing();
        }
    }
}
