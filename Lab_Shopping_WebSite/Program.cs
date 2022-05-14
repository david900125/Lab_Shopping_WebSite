using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Apis;
using Lab_Shopping_WebSite.Services;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Extension;
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;


// .NET 6 IConfiguration
var builder = WebApplication.CreateBuilder(args);

// Register Services
RegisterServices(builder.Services);

// Swagger 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization"
        });

    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
});
builder.Services.AddControllers();

// Configure JSON options.
builder.Services.Configure<JsonOptions>(options =>
{
    //options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.WriteIndented = true;
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    options.SerializerOptions.PropertyNamingPolicy = null;
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

// JwtBareer
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
        {
            // 設定 JWT Bearer Token 的檢查選項
            options.IncludeErrorDetails = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                ValidateIssuer = true, //發行者驗證
                ValidIssuer = builder.Configuration.GetValue<string>("JwtSettings:Issuer"),
                ValidateAudience = false,
                ValidateLifetime = true, //存活時間驗證
                ValidateIssuerSigningKey = false, //金鑰驗證
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JwtSettings:SignKey")))
            };
        });

// Authorization
builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("OnlyAdminRole", p => p.RequireRole("Admin"));
    o.AddPolicy("AdminRole", p => p.RequireRole("Admin", "User"));
    o.AddPolicy("UserRole", p => p.RequireRole("User"));
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
{
    /*
     * Use Dependency Injection in SeedHelper , But will be  "Object reference not set to an instance of an object" Error
     * so Change into in line 71 : Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)
     * SeedHelper.HelperInject(app.Services.GetService<IWebHostEnvironment>());
     */
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
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Upload")),
    RequestPath = "/api/file"
});
// 認證中介軟體
app.UseAuthentication();
// 授權中介軟體
app.UseAuthorization();
// CORS 
app.UseCors("Policy");
// Auth
app.UseAuthMiddleware();

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
    // Jwt
    svcs.AddSingleton<Jwt>();
    // Add HttpContext
    svcs.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    // Add Apis
    svcs.AddTransient<IApi, ArticleApi>();
    svcs.AddTransient<IApi, MemberApi>();
    svcs.AddTransient<IApi, CommodityApi>();
    svcs.AddTransient<IApi, FileApi>();
    svcs.AddTransient<IApi, SalesApi>();
    svcs.AddTransient<IApi, CouponApi>();
    svcs.AddTransient<IApi, ColorApi>();
    // Add Sevices
    svcs.AddTransient<IService<BlogService>, BlogService>();
    svcs.AddTransient<IService<TagsService>, TagsService>();
    svcs.AddTransient<IService<FileServices>, FileServices>();
    svcs.AddTransient<IService<SalesService>, SalesService>();
    svcs.AddTransient<IService<ColorServices>, ColorServices>();
    svcs.AddTransient<IService<MemberService>, MemberService>();
    svcs.AddTransient<IService<CouponServices>, CouponServices>();
    svcs.AddTransient<IService<CommodityService>, CommodityService>();
    // authdto
    svcs.AddScoped<AuthDto>();
}
