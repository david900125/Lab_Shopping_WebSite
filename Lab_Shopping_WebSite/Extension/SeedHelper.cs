using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Newtonsoft.Json;
using System.Text.Json;
using System.Reflection;

namespace Lab_Shopping_WebSite.Extension
{
    public static class SeedHelper
    {
        public static void Seed<T>(this EntityTypeBuilder<T> builder)
            where T : class
        {

            Type type = typeof(T);
            string json = "";
            string rootpath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string fullPath = Path.Combine(rootpath, "Seed", type.Name + ".json");
            if (File.Exists(fullPath))
            {
                using (StreamReader reader = new StreamReader(fullPath))
                {
                    json = reader.ReadToEnd();
                    
                    List<T> jobject =  JsonSerializer.Deserialize<List<T>>(json);
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


