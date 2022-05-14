using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Reflection;

namespace Lab_Shopping_WebSite.Extension
{
    public static class DataInitializer
    {
        public static async Task SeedData(this DataContext _db, IWebHostEnvironment host)
        {
            string json = "";
            var DbSets = typeof(DataContext).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var dbset in DbSets)
            {
                IEnumerable<dynamic> dbvalue = (IEnumerable<dynamic>)dbset.GetValue(_db);
                if (!dbvalue.Any())
                {
                    Type type = dbset.PropertyType.GetGenericArguments()[0];
                    string fullPath = Path.Combine(host.ContentRootPath, "Seed", type.Name + ".json");
                    if (File.Exists(fullPath))
                    {
                        using (StreamReader reader = new StreamReader(fullPath))
                        {
                            json = reader.ReadToEnd();
                            var deserializer = typeof(JsonConvert).GetMethods(BindingFlags.Public | BindingFlags.Static)
                                                .Where(i => i.Name.Equals("DeserializeObject", StringComparison.InvariantCulture))
                                                .Where(i => i.IsGenericMethod)
                                                .Where(i => i.GetParameters().Select(a => a.ParameterType).SequenceEqual(new[] { typeof(string) }))
                                                .Single();
                            // reflection  List<type> 
                            var ListMyType = typeof(List<>).MakeGenericType(type);
                            // set reflection JsonConvert.Deserialize< List<type>  >( string json );
                            deserializer = deserializer.MakeGenericMethod(ListMyType);
                            var results = deserializer.Invoke(null, new object[] { json });

                            var setter = typeof(DataContext).GetMethods(BindingFlags.Public | BindingFlags.Static)
                                                .Where(i => i.Name.Equals("Set", StringComparison.InvariantCulture))
                                                .Where(i => i.IsGenericMethod).Single();
                            setter.MakeGenericMethod(type);
                            // var method = dbset.PropertyType.GetMethod();

                            await _db.SaveChangesAsync();
                        }
                    }
                }
            }
        }
    }


    public static class SeedHelper
    {
        private static IWebHostEnvironment host;

        public static void HelperInject(IWebHostEnvironment _host)
        {
            if (_host == null)
                throw new ArgumentNullException("_context");
            host = _host;
        }

        public static void Seed<T>(this EntityTypeBuilder<T> builder)
            where T : class
        {

            Type type = typeof(T);
            string json = "";
            string rootpath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string fullPath = Path.Combine(rootpath, "Seed", type.Name + ".json");
            //string fullPath = Path.Combine(host.ContentRootPath, "Seed", type.Name + ".json");
            if (File.Exists(fullPath))
            {
                using (StreamReader reader = new StreamReader(fullPath))
                {
                    json = reader.ReadToEnd();
                    List<T> jobject = JsonConvert.DeserializeObject<List<T>>(json);
                    jobject.ForEach(t => 
                    {
                        PropertyInfo info = t.GetType().GetProperty("CreateTime");
                        if (info != null)
                        {
                            info.SetValue(t, DateTime.Now, null);
                        }

                        info = t.GetType().GetProperty("Creator");
                        if (info != null)
                        {
                            info.SetValue(t, 1, null);
                        }
                    });
                    builder.HasData(jobject);
                }
            }
        }
    }
}


