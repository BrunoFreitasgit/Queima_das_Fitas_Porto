using QueimaApp.Converters;
using QueimaApp.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace QueimaApp.Pages
{
    public class AtividadeAcademicaPage : ContentPage
    {

        public AtividadeAcademicaPage()
        {
            this.SetBinding(Page.TitleProperty, "Titulo");
            AbsoluteLayout peakLayout = new AbsoluteLayout
            {
                HeightRequest = 250,
                BackgroundColor = Color.Black
            };

            var title = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.White
            };
            title.SetBinding(Label.TextProperty, "AtividadeAcademica.Nome");

            var where = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#ddd"),
            };
            where.SetBinding(Label.TextProperty, "AtividadeAcademica.Local");

            var infoData = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            var data = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#ddd"),
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };
            //data.SetBinding(Label.TextProperty, new Binding("AtividadeAcademica.Data",stringFormat:"Data: {0}"));
            data.SetBinding(Label.TextProperty, "AtividadeAcademica.Data");
            var datalabel = new Label
            {
                Text = "Data: ",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#ddd"),
                HorizontalOptions = LayoutOptions.Start,
            };
            infoData.Children.Add(datalabel);
            infoData.Children.Add(data);

            var infoPreco = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            var preço = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#ddd"),
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };
            var preçoLabel = new Label
            {
                Text = "Preço: ",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#ddd"),
                HorizontalOptions = LayoutOptions.Start,
            };

            preçoLabel.SetBinding(Label.IsVisibleProperty, "IsPrecoVisible");
            preço.SetBinding(Label.TextProperty, "AtividadeAcademica.Preço");
            preço.SetBinding(Label.IsVisibleProperty, "IsPrecoVisible");


            infoPreco.Children.Add(preçoLabel);
            infoPreco.Children.Add(preço);


            var infoPontoVenda = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            var pontoVenda = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromHex("#ddd"),
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };
            var pontoVendaLabel = new Label
            {
                Text = "Ponto(s) de Venda: ",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#ddd"),
                HorizontalOptions = LayoutOptions.Start,
            };
            pontoVendaLabel.SetBinding(Label.IsVisibleProperty, "IsPontoVendaVisible");
            pontoVenda.SetBinding(Label.TextProperty, "AtividadeAcademica.PontoVenda");
            pontoVenda.SetBinding(Label.IsVisibleProperty, "IsPontoVendaVisible");

            infoPontoVenda.Children.Add(pontoVendaLabel);
            infoPontoVenda.Children.Add(pontoVenda);




            var image = new Image()
            {
                Aspect = Aspect.AspectFill,
            };
            image.SetBinding(Image.SourceProperty, "AtividadeAcademica.ImagePath");

            var overlay = new BoxView()
            {
                Color = Color.Black.MultiplyAlpha(.7f)
            };

            var pin = new Image()
            {
                Source = ImageSource.FromFile("pin.png"),
                HeightRequest = 25,
                WidthRequest = 25
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "LocationCommand");
            pin.GestureRecognizers.Add(tapGestureRecognizer);


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
            descricao.SetBinding(Label.TextProperty, "AtividadeAcademica.Descricao");
            description.Content = descricao;




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

            AbsoluteLayout.SetLayoutFlags(pin, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(pin,
                new Rectangle(0.95, 0.9, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize)
            );

            peakLayout.Children.Add(image);
            peakLayout.Children.Add(overlay);
            peakLayout.Children.Add(title);
            peakLayout.Children.Add(where);
            peakLayout.Children.Add(pin);

            Content = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.FromHex("#333"),
                Children = {
                    peakLayout,
                    infoData,
                    infoPreco,
                    infoPontoVenda,
                    description
                }
            };
        }
    }
}
