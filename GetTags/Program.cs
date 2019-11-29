using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GetTags
{
    class Program
    {
        static void Main(string[] args)
        {
            // Request headers
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Training-key", "2ed936a0439b4f7e84475e8b1f938852");
            var uri = "https://northeurope.api.cognitive.microsoft.com/customvision/v1.1/Training/projects/8c0f6001-10c4-487c-8643-f869c00f0bcd/tags";
            var response = client.GetAsync(uri).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;

            var tags = JsonConvert.DeserializeObject<TagsObject>(responseBody);
            var tagNames = tags.Tags.Select(t => t.Name);
            tagNames.OrderBy(t => t).ToList().ForEach(t => Debug.WriteLine(t));
        }
    }
}
