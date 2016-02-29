using Google.GData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleContatos.Service
{
    public static class Parametros
    {
        public static string applicationName = "GoogleContatos";
        public static string clientId = "313298766019-d9dec4n6u3o67lapl60hag5kjhuor6kq.apps.googleusercontent.com";
        public static string clientSecret = "pIl0RaAHklo5Dbxst18nvcdT";
        public static string redirectUri = "http://www.kelvisgama.com.br/Contatos";
        public static string scopes = "https://www.google.com/m8/feeds/";

        public static OAuth2Parameters parameters = new OAuth2Parameters()
        {
            ClientId = Parametros.clientId,
            ClientSecret = Parametros.clientSecret,
            RedirectUri = Parametros.redirectUri,
            Scope = Parametros.scopes,
            ApprovalPrompt = "force"
        };

        
    }
}