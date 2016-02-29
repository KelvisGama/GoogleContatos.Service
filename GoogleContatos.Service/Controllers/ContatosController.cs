using Google.Contacts;
using Google.GData.Apps;
using Google.GData.Client;
using GoogleContatos.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoogleContatos.Service.Controllers
{
    public class ContatosController : ApiController
    {

        public IEnumerable<Contato> Get(string Code)
        {
            try
            {
                Uri redirectedUrl = new Uri(Parametros.redirectUri + "?code=" + Code + "#");


                if (string.IsNullOrEmpty( Parametros.parameters.AccessToken))
                {
                   OAuthUtil.GetAccessToken(redirectedUrl.Query, Parametros.parameters);
                }
                

                RequestSettings settings = new RequestSettings(Parametros.applicationName, Parametros.parameters);
                ContactsRequest cr = new ContactsRequest(settings);

                Feed<Contact> f = cr.GetContacts();
                List<Contato> contatos = new List<Contato>();
                foreach (Contact c in f.Entries)
                {
                    Contato contato = new Contato();
                    // Nome do Contato
                    if (c.Name != null){
                        if(!string.IsNullOrEmpty(c.Name.FullName)){
                            contato.Nome = c.Name.FullName;
                        }else if(!string.IsNullOrEmpty(c.Name.GivenName)){
                            contato.Nome = c.Name.GivenName;
                        }else{
                             contato.Nome = "SEM NOME";
                        }
                        
                    }

                    //Telefone
                    if(c.Phonenumbers.Count > 0){
                        contato.TelefonePrincial = !string.IsNullOrEmpty(c.Phonenumbers[0].Uri) ? c.Phonenumbers[0].Uri : "SEM NÚMERO";
                    }
                    else
                    {
                        contato.TelefonePrincial = "SEM NÚMERO";
                    }

                    //Email
                    if (c.Emails.Count > 0)
                    {
                        contato.Email = !string.IsNullOrEmpty(c.Emails[0].Address) ? c.Emails[0].Address : "SEM EMAIL";
                    }
                    else
                    {
                        contato.Email = "SEM EMAIL";
                    }
                    
                    contatos.Add(contato);
                    
                }
                return contatos;


            }
            catch (AppsException a)
            {
                throw new AppsException(a.ErrorCode, a.InvalidInput, a.Reason);
            }


        }

    }
}
