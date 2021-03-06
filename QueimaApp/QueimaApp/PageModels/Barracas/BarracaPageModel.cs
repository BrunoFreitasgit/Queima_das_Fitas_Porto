﻿using FreshMvvm;
using PropertyChanged;
using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK.CustomMap;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class BarracaPageModel : FreshBasePageModel
    {
        public Barraca Barraca { get; set; }

        public string Titulo { get; set; }
        public bool IsBusy { get; set; }
        public bool TemEvento { get; set; }
        public bool TemLocalizacao { get; set; }
        Command _OpenUrlCommand;
        public BarracaPageModel()
        {

        }
        public override void Init(object initData)
        {
            if (initData != null)
            {
                Barraca = (Barraca)initData;
                Titulo = Barraca.Nome;
                if (Barraca.Longitude != 0 && Barraca.Latitude != 0)
                {
                    TemLocalizacao = true;

                    // mapa
                    Pins = new ObservableCollection<TKCustomMapPin>();
                    var Pin = new TKCustomMapPin
                    {
                        IsVisible = true,
                        Title = Barraca.Nome,
                        Position = new Position(Barraca.Latitude, Barraca.Longitude),
                        ShowCallout = true
                    };
                    Pins.Add(Pin);
                    MapCenter = new Position(Barraca.Latitude, Barraca.Longitude);
                    MapRegion = MapSpan.FromCenterAndRadius(Pin.Position, Distance.FromKilometers(0.5));
                }
                else
                {
                    TemLocalizacao = false;
                }
                if (!string.IsNullOrWhiteSpace(Barraca.FacebookEventURL))
                {
                    TemEvento = true;
                }
                else
                {
                    TemEvento = false;
                }
            }
            else
            {
                Barraca = new Barraca();
            }

            IsBusy = false;
        }

        public Command OpenUrlCommand
        {
            get
            {
                return _OpenUrlCommand ??
                    (_OpenUrlCommand = new Command(() => ExecuteOpenUrlCommand()));
            }
        }

        private void ExecuteOpenUrlCommand()
        {
            if (string.IsNullOrWhiteSpace(Barraca.FacebookEventURL))
            {
                return;
            }
            else
            {
                Uri url = new Uri(Barraca.FacebookEventURL);
                Device.OpenUri(url);
            }
        }
        // mapa
        public ObservableCollection<TKCustomMapPin> Pins { get; set; }
        public MapSpan MapRegion { get; set; }
        public Position MapCenter { get; set; }
        public Position GetPosition()
        {
            if (!TemLocalizacao)
                return new Position(0, 0);

            IsBusy = true;

            Position p;

            p = new Position(Barraca.Latitude, Barraca.Longitude);

            IsBusy = false;

            return p;
        }

    }
}
