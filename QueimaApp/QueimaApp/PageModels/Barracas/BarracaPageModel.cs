using FreshMvvm;
using PropertyChanged;
using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.PageModels
{
    [ImplementPropertyChanged]
    public class BarracaPageModel : FreshBasePageModel
    {
        public Barraca Barraca { get; set; }
        public string Titulo { get; set; }
        public override void Init(object initData)
        {
            if (initData != null)
            {
                Barraca = (Barraca)initData;
                Titulo = Barraca.Nome;
            }
            else
            {
                Barraca = new Barraca();
            }
        }
    }
}
