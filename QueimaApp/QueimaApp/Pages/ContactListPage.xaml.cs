using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace QueimaApp.Pages
{
    public partial class ContactListPage : BasePage
    {

        public ContactListPage()
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
