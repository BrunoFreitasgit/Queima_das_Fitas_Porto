using FreshMvvm;
using PropertyChanged;
using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class BarracaPageModel : FreshBasePageModel
    {
        public Barraca Barraca { get; set; }

        public string Titulo { get; set; }

        public bool TemEvento { get; set; }
        public bool TemLocalizacao { get; set; }
        Command _OpenUrlCommand;
        public override void Init(object initData)
        {
            if (initData != null)
            {
                Barraca = (Barraca)initData;
                Titulo = Barraca.Nome;
                if (Barraca.Longitude != 0 && Barraca.Latitude != 0)
                {
                    TemLocalizacao = true;
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
    }
}
