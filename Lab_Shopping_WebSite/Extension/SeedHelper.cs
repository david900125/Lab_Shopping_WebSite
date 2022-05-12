using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
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
}




//var types = typeof(IModel).Assembly.GetTypes().Where(type => type.IsClass && type.IsSubclassOf(typeof(IModel)));

//foreach (var type in types)
//{
//    var DbsetMyType = typeof(DbSet<>).MakeGenericType(type);
//    PropertyInfo info = typeof(DataContext).GetProperty(type.Name, DbsetMyType);
//    if (info != null)
//    {
//        var dbSet = (IEnumerable<dynamic>)info.GetValue(_db);
//        if (!dbSet.Any())
//        {
//            string fullPath = Path.Combine(host.ContentRootPath, "Seed", type.Name + ".json");
//            if (File.Exists(fullPath))
//            {
//                using (StreamReader reader = new StreamReader(fullPath))
//                {
//                    json = reader.ReadToEnd();
//                    // reflection JsonConvert.Deserialize<T>( string json );
//                    var deserializer = typeof(JsonConvert).GetMethods(BindingFlags.Public | BindingFlags.Static)
//                        .Where(i => i.Name.Equals("DeserializeObject", StringComparison.InvariantCulture))
//                        .Where(i => i.IsGenericMethod)
//                        .Where(i => i.GetParameters().Select(a => a.ParameterType).SequenceEqual(new[] { typeof(string) }))
//                        .Single();
//                    // reflection  List<type> 
//                    var ListMyType = typeof(List<>).MakeGenericType(type);
//                    // set reflection JsonConvert.Deserialize< List<type>  >( string json );
//                    deserializer = deserializer.MakeGenericMethod(ListMyType);
//                    var results = deserializer.Invoke(null, new object[] { json });
//                    if (results != null)
//                    {
//                        MethodInfo methodAdd = typeof(DbSet<>).GetMethods()
//                                               .Single(m => m.Name == "AddRange" && m.GetParameters().Count() == 1);
//                        methodAdd.Invoke(dbSet, new[] { results });
//                        await _db.SaveChangesAsync();
//                    }
//                }
//            }
//            else
//            {
//                //do nothing
//            }
//        }
//    }
//    else
//    {
//        //do nothing
//    }
//}
