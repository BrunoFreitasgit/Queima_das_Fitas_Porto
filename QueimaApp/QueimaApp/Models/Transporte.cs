using PropertyChanged;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Models
{
    [Table("Transportes")]
    [ImplementPropertyChanged]
    public class Transporte
    {
        [PrimaryKey]
        public int Id { get; set; }
        // Nome do Tipo de Transporte (STCP, Metro ou Taxi)
        public TipoTransporte TipoTransporte { get; set; }
        // Link para informações adicionais
        public string Url { get; set; }
        // Descrição do serviço de Transporte
        public string Descricao { get; set; }
        // Imagem descritiva do Transporte
        public string ImagemUrl { get; set; }
        public Transporte()
        {

        }
    }

    // Tipos de Transporte 
    public enum TipoTransporte
    {
        STCP,
        Metro,
        Taxi
    }
}
