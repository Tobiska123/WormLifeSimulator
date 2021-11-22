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
    class ExternalLogic : IWormLogic
    {
        public (string, bool) GetAction(WorldDto data)
        {
            WormBehevior tmp = this.Require(data);
            return (tmp.Direction, tmp.Split);
        }

        public WormBehevior Require(WorldDto data)
        {
            String url = "https://localhost:8083/";//todo вынести в конфиг
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            using (HttpClient client = new HttpClient())
            {
                    var content = JsonSerializer.Serialize(data);
                    var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                    var task = client.PostAsync(url, stringContent);
                    task.Wait(100);
                    return JsonSerializer.Deserialize<WormBehevior>(task.Result.Content.ReadAsStringAsync().Result, jsonSerializerOptions);
            }
        }
    }
}
