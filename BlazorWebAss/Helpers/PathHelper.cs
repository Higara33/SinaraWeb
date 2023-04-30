using Newtonsoft.Json;

namespace BlazorWebAss.Helpers
{
    public class PathHelper
    {
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "sinaraconfig.json")))
            {
                string json = r.ReadToEnd();
                List<Services> items = JsonConvert.DeserializeObject<List<Services>>(json);
            }
        }

        public class Services
        {
            public string service;
        }
    }
}
