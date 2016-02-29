using Google.GData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoogleContatos.Service.Controllers
{
    public class AuthenticationController : ApiController
    {
        /// <summary>
        /// Gera URL de Autenticação do Google (OAuth2)
        /// </summary>
        /// <returns></returns>
        public string Get()
        {

            try
            {
                string url = OAuthUtil.CreateOAuth2AuthorizationUrl(Parametros.parameters);
                return url;
            }
            catch (Exception e)
            {
                
                throw new Exception("Ocorreu um erro ao tentar gerar a URL de Autenticação. \n" + e.Message,e.InnerException);
            }
        }
               
    }
}
