using FreshMvvm;
using PropertyChanged;
using QueimaApp.Interfaces;
using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class CartazPalcoPageModel : FreshBasePageModel
    {
        IDatabaseService _databaseService;
        Artista _selectedArtista;
        public ObservableCollection<Artista> Artistas { get; set; }
        public CartazPalcoPageModel(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public override void Init(object initData)
        {
            Artistas = new ObservableCollection<Artista>(_databaseService.GetArtistasByPalco(Palco.PalcoPrincipal));
        }

        public Artista SelectedArtista
        {
            get
            {
                return _selectedArtista;
            }
            set
            {
                _selectedArtista = value;
                if (value != null)
                    ArtistaSelected.Execute(value);
            }
        }
        public Command<Artista> ArtistaSelected
        {
            get
            {
                return new Command<Artista>(async (artista) =>
                {
                    await CoreMethods.PushPageModel<ArtistaPageModel>(artista);
                    _selectedArtista = null;
                });
            }
        }
    }
}
