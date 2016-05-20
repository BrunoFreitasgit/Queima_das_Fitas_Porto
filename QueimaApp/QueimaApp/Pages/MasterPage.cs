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
        public MasterPage()
        {
            this.Init("Menu", "Menu.png");
            AddPages();
        }

        private void AddPages()
        {
            this.AddPageWithIcon<ContactListPageModel>("Contacts","icon.png", null);
            this.AddPageWithIcon<QuoteListPageModel>("Quotes","icon.png", null);
            this.AddPageWithIcon<AtividadesListPageModel>("Atividades Académicas", "icon.png", null);
        }


        protected override void CreateMenuPage(string menuPageTitle, string menuIcon = null)
        {
            var listview = new ListView();
            var _menuPage = new ContentPage();
            _menuPage.Title = menuPageTitle;
            _menuPage.BackgroundColor = Color.FromHex("#c8c8c8");

            listview.ItemsSource = pageIcons;

            var cell = new DataTemplate(typeof(ImageCell));
            cell.SetValue(TextCell.TextColorProperty, Color.Black);
            cell.SetBinding(ImageCell.TextProperty, "Title");
            cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");


            listview.ItemTemplate = cell;
            listview.ItemSelected += (sender, args) =>
            {
                if (Pages.ContainsKey(((MasterPageItem)args.SelectedItem).Title))
                {
                    Detail = Pages[((MasterPageItem)args.SelectedItem).Title];
                }
                IsPresented = false;
            };

            _menuPage.Content = listview;

            var navPage = new NavigationPage(_menuPage) { Title = "Menu" };

            if (!string.IsNullOrEmpty(menuIcon))
                navPage.Icon = menuIcon;

            Master = navPage;
        }
        protected override Page CreateContainerPage(Page page)
        {
            var navigation = new NavigationPage(page);
            navigation.BarTextColor = Color.White;

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
