﻿using FreshMvvm;
using QueimaApp.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QueimaApp.Pages
{
    public class MasterPage : FreshMasterDetailNavigationContainer
    {
        List<MasterPageItem> pageIcons = new List<MasterPageItem>();
        private ListView listview;

        public MasterPage()
        {
            this.Init("Menu", "Menu.png");
            AddPages();
            var introPage = FreshPageModelResolver.ResolvePageModel<IntroPageModel>();
            //var atividadesPage = FreshPageModelResolver.ResolvePageModel<AtividadesListPageModel>();
            if (Device.OS == TargetPlatform.iOS)
            {
                PushPage(new NavigationPage(introPage), null, true);
            }
            else
            {
                PushPage(introPage, null, true);
            }

        }

        private void AddPages()
        {
            AddPageWithIcon<AtividadesListPageModel>("Atividades Académicas", "icon.png", null);
            AddPageWithIcon<CartazPageModel>("Cartaz", "icon.png", null);
            AddPageWithIcon<BarracasListPageModel>("Barracas", "icon.png", null);
            AddPageWithIcon<BilheteiraPageModel>("Bilheteira", "icon.png", null);
            AddPageWithIcon<SocialPageModel>("Social", "icon.png", null);
            AddPageWithIcon<ConcursosPageModel>("Concursos", "icon.png", null);
            AddPageWithIcon<TransportesPageModel>("Transportes", "icon.png", null);
        }
        
        protected override void CreateMenuPage(string menuPageTitle, string menuIcon = null)
        {
            listview = new ListView();
            var _menuPage = new ContentPage();
            _menuPage.Title = menuPageTitle;
            _menuPage.BackgroundColor = Color.FromHex("#c8c8c8");

            listview.ItemsSource = pageIcons;

            var cell = new DataTemplate(typeof(ImageCell));
            cell.SetValue(TextCell.TextColorProperty, Color.Black);
            cell.SetBinding(ImageCell.TextProperty, "Title");
            cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");


            listview.ItemTemplate = cell;
            listview.ItemSelected += onItemSelected;

            _menuPage.Content = listview;

            var navPage = new NavigationPage(_menuPage) { Title = "Menu" };

            if (!string.IsNullOrEmpty(menuIcon))
                navPage.Icon = menuIcon;

            Master = navPage;
        }

        private void onItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem == null)
            {
                return;
            }
            if (Pages.ContainsKey(((MasterPageItem)args.SelectedItem).Title))
            {
                Detail = Pages[((MasterPageItem)args.SelectedItem).Title];
            }
            IsPresented = false;
            listview.SelectedItem = null;
        }

        protected override Page CreateContainerPage(Page page)
        {
            var navigation = new NavigationPage(page);
            if (Device.OS == TargetPlatform.iOS)
            {
                navigation.BarTextColor = (Color)Application.Current.Resources["BrandColorDark"];
            }
            else
            {
                navigation.BarTextColor = Color.White;
                navigation.BarBackgroundColor = (Color)Application.Current.Resources["BrandColorDark"];
            }

            return navigation;
        }

        public void AddPageWithIcon<T>(string title, string icon = "", object data = null) where T : FreshBasePageModel
        {
            base.AddPage<T>(title, data);
            pageIcons.Add(new MasterPageItem
            {
                Title = title,
                IconSource = icon
            });
        }
    }
}
