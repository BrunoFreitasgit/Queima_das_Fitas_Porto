using FreshMvvm;
using ModernHttpClient;
using Newtonsoft.Json;
using QueimaApp.Interfaces;
using QueimaApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Services
{
    public class RestService : IRestService
    {
        HttpClient client;

        public List<Artista> Artistas { get; private set; }
        public List<AtividadeAcademica> AtividadesAcademicas { get; private set; }
        public List<Media> Media { get; private set; }
        public List<Concurso> Concursos { get; private set; }
        public Bilheteira Bilheteira { get; private set; }
        public List<Transporte> Transportes { get; private set; }

        public RestService()
        {
            client = new HttpClient(new NativeMessageHandler());
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Transporte>> TransportesRefreshAsync()
        {
            Transportes = new List<Transporte>();

            // RestUrl = http://developer.xamarin.com:8081/api/
            var uri = new Uri(string.Format(Helpers.Constants.RestUrl, Helpers.Constants.TransportesUrl));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Transportes = JsonConvert.DeserializeObject<List<Transporte>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Transportes;
        }

        public async Task<List<Artista>> ArtistasRefreshAsync()
        {
            Artistas = new List<Artista>();

            // RestUrl = http://developer.xamarin.com:8081/api/
            var uri = new Uri(string.Format(Helpers.Constants.RestUrl, Helpers.Constants.ArtistasUrl));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Artistas = JsonConvert.DeserializeObject<List<Artista>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Artistas;
        }

        public async Task<List<AtividadeAcademica>> AtividadesRefreshAsync()
        {
            AtividadesAcademicas = new List<AtividadeAcademica>();

            // RestUrl = http://developer.xamarin.com:8081/api/
            var uri = new Uri(string.Format(Helpers.Constants.RestUrl, Helpers.Constants.AtividadesUrl));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    AtividadesAcademicas = JsonConvert.DeserializeObject<List<AtividadeAcademica>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return AtividadesAcademicas;
        }

        public async Task<Bilheteira> BilheteiraRefreshAsync()
        {
            Bilheteira = new Bilheteira();

            // RestUrl = http://developer.xamarin.com:8081/api/
            var uri = new Uri(string.Format(Helpers.Constants.RestUrl, Helpers.Constants.BilheteiraUrl));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Bilheteira = JsonConvert.DeserializeObject<Bilheteira>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Bilheteira;
        }

        public async Task<List<Concurso>> ConcursosRefreshAsync()
        {
            Concursos = new List<Concurso>();

            // RestUrl = http://developer.xamarin.com:8081/api/
            var uri = new Uri(string.Format(Helpers.Constants.RestUrl, Helpers.Constants.ConcursosUrl));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Concursos = JsonConvert.DeserializeObject<List<Concurso>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Concursos;
        }

        public async Task<List<Media>> MediaRefreshAsync()
        {
            Media = new List<Media>();

            // RestUrl = http://developer.xamarin.com:8081/api/
            var uri = new Uri(string.Format(Helpers.Constants.RestUrl, Helpers.Constants.MediaUrl));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Media = JsonConvert.DeserializeObject<List<Media>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Media;
        }
    }
}

