using NBA_Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace NBA_Repository
{
    public class NbaPlayerRepositoryWebApi : INbaPlayerRepository
    {
        string _urlService; 
        public NbaPlayerRepositoryWebApi (IConfiguration configuration)
        {
            this._urlService = configuration["UrlExternal"]; 
        }
        public async Task <List<NBA_Player>> getNbaPlayers()
        {
            List<NBA_Player> listNbaPlayer = new List<NBA_Player>();
            JsonSerializer objSerializer = new JsonSerializer(); 
            HttpClient client = new HttpClient();           
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            

            HttpResponseMessage response = await client.GetAsync (this._urlService);
            if (response.IsSuccessStatusCode)
            {
                string resultado = await response.Content.ReadAsStringAsync();
                //TODO: 20210908 Use another way to edit the json
                //Editing the json in order to be parsered as a List by Newton.JsonConvert 
                resultado = resultado.Substring(10);                 
                resultado = resultado.Replace("]}", "]");
                listNbaPlayer = JsonConvert.DeserializeObject<List<NBA_Player>>(resultado);               
            }
            return listNbaPlayer;
        }
    }
}
