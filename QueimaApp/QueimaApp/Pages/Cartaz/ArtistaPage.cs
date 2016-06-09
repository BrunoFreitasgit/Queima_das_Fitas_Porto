using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QueimaApp.Pages
{
    public class ArtistaPage : ContentPage
    {
        public ArtistaPage()
        {
            this.SetBinding(Page.TitleProperty, "Titulo");
            AbsoluteLayout artistalayout = new AbsoluteLayout
            {
                HeightRequest = 250,
                BackgroundColor = Color.Black
            };

            var title = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.White
            };
            title.SetBinding(Label.TextProperty, "Artista.Nome");

            var where = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#ddd"),
            };
            where.SetBinding(Label.TextProperty, "Artista.Palco");

            var image = new Image()
            {
                Aspect = Aspect.AspectFill,
            };
            image.SetBinding(Image.SourceProperty, "Artista.ImagemUri");

            var overlay = new BoxView()
            {
                Color = Color.Black.MultiplyAlpha(.7f)
            };
            var biografia = new Label()
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                Text = "Biografia",
                Margin = new Thickness(10, 5),
                TextColor = Color.FromHex("#ddd")
            };
            var description = new Frame()
            {

                Padding = new Thickness(10, 5),
                HasShadow = false,
                BackgroundColor = Color.Transparent,
            };

            var descricao = new Label()
            {
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                TextColor = Color.FromHex("#ddd"),
            };
            descricao.SetBinding(Label.TextProperty, "Artista.Biografia");
            description.Content = descricao;


            var linksLabel = new Label()
            {
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                TextColor = Color.FromHex("#ddd"),
                Margin = new Thickness(10, 5),
                Text = "Links"
            };

            var fbLabel = new Label()
            {
                Text = "Facebook",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                TextColor = Color.FromHex("#ddd"),
            };
            var twitterLabel = new Label()
            {
                Text = "Twitter",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                TextColor = Color.FromHex("#ddd"),
            };

            var spotifyLabel = new Label()
            {
                Text = "Spofity",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                TextColor = Color.FromHex("#ddd"),
            };

            var fb = new Image()
            {
                Source = ImageSource.FromFile("icon.png"),
                HeightRequest = 20,
                WidthRequest = 20
            };

            var twitter = new Image()
            {
                Source = ImageSource.FromFile("icon.png"),
                HeightRequest = 20,
                WidthRequest = 20
            };

            var spotify = new Image()
            {
                Source = ImageSource.FromFile("icon.png"),
                HeightRequest = 20,
                WidthRequest = 20
            };
            var linkfb_layout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(10, 5)
            };
            var linktwitter_layout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(10, 5)
            };
            var linkspotify_layout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(10, 5)
            };
            linkfb_layout.Children.Add(fbLabel);
            linkfb_layout.Children.Add(fb);
            linkspotify_layout.Children.Add(spotifyLabel);
            linkspotify_layout.Children.Add(spotify);
            linktwitter_layout.Children.Add(twitterLabel);
            linktwitter_layout.Children.Add(twitter);



            AbsoluteLayout.SetLayoutFlags(overlay, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(overlay, new Rectangle(0, 1, 1, 0.3));

            AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0f, 0f, 1f, 1f));

            AbsoluteLayout.SetLayoutFlags(title, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(title,
                new Rectangle(0.1, 0.85, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize)
            );

            AbsoluteLayout.SetLayoutFlags(where, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(where,
                new Rectangle(0.1, 0.95, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize)
            );

            artistalayout.Children.Add(image);
            artistalayout.Children.Add(overlay);
            artistalayout.Children.Add(title);
            artistalayout.Children.Add(where);

            Content = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.FromHex("#333"),
                Children = {
                    artistalayout,
                    biografia,
                    description,
                    linksLabel,
                    linkspotify_layout,
                    linktwitter_layout,
                    linkfb_layout
                }
            };

        }
    }
}
