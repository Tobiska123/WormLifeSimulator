using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WormLifeSimulator.Entity;

namespace WormLifeSimulator.WormLogic
{
    public class ExternalLogic : IWormLogic
    {
        public (string, bool) GetAction(Worm worm, WorldDto data)
        {
            Task<WormBehevior> tmp = this.RequireAsync(worm, data);
            return (tmp.Result.direction, tmp.Result.split);
        }

        public async Task<WormBehevior> RequireAsync(Worm worm, WorldDto data)
        {
            String url = String.Format("http://localhost:8083/{0}/GetAction", worm.Name);//todo вынести в конфиг
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            using (HttpClient client = new HttpClient())
            {
                    string cont = JsonSerializer.Serialize(data);
                    var stringContent = new StringContent(cont, Encoding.UTF8, "application/json");
                    var task = await client.PostAsync(url, stringContent);
                    string result = task.Content.ReadAsStringAsync().Result;
                    return JsonSerializer.Deserialize<WormBehevior>(task.Content.ReadAsStringAsync().Result, jsonSerializerOptions);
            }
        }
    }
}
