using System;
using FreshMvvm;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using QueimaApp.PageModels;

namespace QueimaApp.Navigation
{
    /// <summary>
    /// This is a sample custom implemented Navigation. It combines a MasterDetail and a TabbedPage.
    /// </summary>
    public class CustomImplementedNav : Xamarin.Forms.MasterDetailPage, IFreshNavigationService
    {
        FreshTabbedNavigationContainer _tabbedNavigationPage;
        Page _pontosVendaPage, _bilhetesPage;

        public CustomImplementedNav()
        {
            NavigationServiceName = "CustomImplementedNav";
            SetupTabbedPage();
            CreateMenuPage("Menu");
            RegisterNavigation();
        }

        void SetupTabbedPage()
        {
            _tabbedNavigationPage = new FreshTabbedNavigationContainer();
            _pontosVendaPage = _tabbedNavigationPage.AddTab<QuoteListPageModel>("Pontos de Venda", "icon.png");
            _bilhetesPage = _tabbedNavigationPage.AddTab<ContactListPageModel>("Bilhetes", "icon.png");
            this.Detail = _tabbedNavigationPage;
        }

        protected void RegisterNavigation()
        {
            FreshIOC.Container.Register<IFreshNavigationService>(this, NavigationServiceName);
        }

        protected void CreateMenuPage(string menuPageTitle)
        {
            var _menuPage = new ContentPage();
            _menuPage.Title = menuPageTitle;
            var listView = new ListView();
            _menuPage.BackgroundColor = Color.FromHex("#c8c8c8");

            listView.ItemsSource = new string[] { "Contacts", "Quotes", "Modal Demo" };

            listView.ItemSelected += async (sender, args) =>
            {

                switch ((string)args.SelectedItem)
                {
                    case "Contacts":
                        _tabbedNavigationPage.CurrentPage = _pontosVendaPage;
                        break;
                    case "Quotes":
                        _tabbedNavigationPage.CurrentPage = _bilhetesPage;
                        break;
                    case "Modal Demo":
                        var modalPage = FreshPageModelResolver.ResolvePageModel<ModalPageModel>();
                        await PushPage(modalPage, null, true);
                        break;
                    default:
                        break;
                }

                IsPresented = false;
            };

            _menuPage.Content = listView;

            Master = new NavigationPage(_menuPage) { Title = "Menu" };
        }

        public virtual async Task PushPage(Xamarin.Forms.Page page, FreshBasePageModel model, bool modal = false, bool animated = true)
        {
            if (modal)
                await Navigation.PushModalAsync(new NavigationPage(page), animated);
            else
                await ((NavigationPage)_tabbedNavigationPage.CurrentPage).PushAsync(page, animated);
        }

        public virtual async Task PopPage(bool modal = false, bool animate = true)
        {
            if (modal)
                await Navigation.PopModalAsync();
            else
                await ((NavigationPage)_tabbedNavigationPage.CurrentPage).PopAsync();
        }

        public virtual async Task PopToRoot(bool animate = true)
        {
            await ((NavigationPage)_tabbedNavigationPage.CurrentPage).PopToRootAsync(animate);
        }

        public string NavigationServiceName { get; private set; }

        public void NotifyChildrenPageWasPopped()
        {
            if (Master is NavigationPage)
                ((NavigationPage)Master).NotifyAllChildrenPopped();
            foreach (var page in _tabbedNavigationPage.Children)
            {
                if (page is NavigationPage)
                    ((NavigationPage)page).NotifyAllChildrenPopped();
            }
        }
    }
}

