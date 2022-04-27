using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;

using Lab_Shopping_WebSite.Apis;
using Lab_Shopping_WebSite.Services;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;


// .NET 6 IConfiguration
var builder = WebApplication.CreateBuilder(args);

// Register Services
RegisterServices(builder.Services);
// Swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Configure JSON options.
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.WriteIndented = true;
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Cors
builder.Services.AddCors(option => option.AddPolicy("Policy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
}));

// 資料庫連線
builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Authorization
// builder.Services.AddAuthorization(o => o.AddPolicy("AdminsOnly",
//                                   b => b.RequireClaim("admin", "true")));

var app = builder.Build();
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
{
    DataContext dbContext = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
    dbContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // 異常處理中介軟體
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
else
{
    // 全域性異常處理中介軟體
    app.UseExceptionHandler("error");
}
// HTTP 要求重新導向至 HTTPS
app.UseHttpsRedirection();
//啟用靜態檔案
app.UseStaticFiles();
// 認證中介軟體
app.UseAuthentication();
// 授權中介軟體
app.UseAuthorization();
// CORS 
app.UseCors("Policy");

// Get Apis By Injected
var apis = app.Services.GetServices<IApi>();

foreach (var api in apis)
{
    if (api is null) throw new InvalidProgramException("Api is not found");

    api.Register(app);
}


app.Run();


void RegisterServices(IServiceCollection svcs)
{
    // Add HttpContext
    svcs.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    // Add Apis
    svcs.AddTransient<IApi, ClientApi>();
    svcs.AddTransient<IApi, TestApi>();
    svcs.AddTransient<IApi, ArticleApi>();


    // Add Sevices
    svcs.AddTransient<IService, BlogService>();
    svcs.AddTransient<IService, MemberService>();
}
