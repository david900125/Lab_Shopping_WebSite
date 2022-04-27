using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class ClientApi : IApi
    {
        public ClientApi()
        {
        }

        ~ClientApi()
        {
        }

        public void Register(WebApplication app)
        {
            app.MapGet("/api/clients", GetAll);
            app.MapGet("/api/clients/{id:int}", GetOne);
        }
    }
}
