using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.UI.Composition;
using Newtonsoft.Json;
using RestSharp;

namespace P6Assets2024_JosueV.Models
{
    public class UserRole
    {
        //cuando queremos comunicarnos con el API hay dos formas mas usadas
        //1. Con las librerias nativas .NET
        //2. o usando herramientas de terceros.
        //en lo personal he encontrado mas facil y eficiente el uso de restSharp

        public RestRequest? Request { get; set; }
        public int UserRoleId { get; set; }

        public string UserRoleDescription { get; set; } = null!;

        //FUNCIONES

        //cargar todos los roles de usuario

        public async Task<List<UserRole>?> GetAllUserRolesAsync() 
        {
        try
        {
                //tenemos que armar la ruta completa de consuma del API
                //para eso tenemos en WEBAPIConnection la ruta de base del API
                // y aca la completamos
                string RouterSufix = string.Format("UserRoles");

                //armamos la ruta completa de consumo del API
                string URL = Services.WebAPIConnections.ProductionURLPrefix + RouterSufix;
                //ahora tenemos la ruta completa lista

                //configuramos el request 
                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos el metodo de seguridad, en este caso tenemos apikey
                Request.AddHeader(Services.WebAPIConnections.Apikeyname, Services.WebAPIConnections.ApikeyValue);

                // y ahora ejectumas la llamada al API
                RestResponse response = await client.ExecuteAsync(Request);

                //validamos que todo haya salido bien
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    //si obtuvimos  respuesta positiva desde el API
                    var list = JsonConvert.DeserializeObject<List<UserRole>>(response.Content);

                    return list;
                }
                else
                {
                    return null;
                }
            }
        catch(Exception ex)
        {
                string ErrorMsg = ex.Message;
                throw;
        }
        }

    }
}
