using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueimaApp.Helpers
{
    public static class Constants
    {
        // URL of REST service
        public static string RestUrl = "http://localhost:3080/api/atividadesacademicas";

        public static string TransportesUrl = "Transportes";

        public static string ArtistasUrl = "Artistas";

        public static string MediaUrl = "Media";

        public static string ConcursosUrl = "Concursos";

        public static string BilheteiraUrl = "Bilheteira";

        public static string AtividadesUrl = " AtividadesAcademicas";
    }


    // Necessário criar conta no Instagram para versão release (login necessário 'access_token')
    public static class InstagramApi
    {
        public static string ClientId = "791ca28b9e26497d8148d76edfb0c4b0";
        public static string ClientSecret = " 89735ff388da484c84b40eefad010fd1";
        public static string AccessToken = "3711743001.791ca28.b727ae1f0def4a5f9db04650c8ceca5f";
        public static string RedirectUrl = "http://www.fap.pt";
    }
}
