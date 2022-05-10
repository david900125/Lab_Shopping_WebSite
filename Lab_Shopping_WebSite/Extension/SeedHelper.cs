using Newtonsoft.Json;

namespace Lab_Shopping_WebSite.Extension
{
    public class SeedHelper
    {
        public SeedHelper(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

        private static IWebHostEnvironment Environment;

        public static List<TEntity> SeedData<TEntity>(string fileName)
        {
            Type type = typeof(TEntity);
            string path = Path.Combine(Environment.ContentRootPath, "Seed", type.Name.ToString(), ".json");

            List<TEntity> result = new List<TEntity>();
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<TEntity>>(json);
            }

            return result;
        }
    }
}
