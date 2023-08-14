using FantasyApp.BookApi;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.Net.Http.Headers;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FantasyApp.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<FantasyAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FantasyAppContext") ?? throw new InvalidOperationException("Connection string 'FantasyAppContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "client/dist";
});

builder.Services.AddHttpClient<IGoogleBooksApi, GoogleBooksApi>(httpClient => {
    httpClient.BaseAddress = new Uri("https://www.googleapis.com");
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var spaPath = "/app";

if (app.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapWhen(y => y.Request.Path.StartsWithSegments(spaPath), client =>
    {
        client.UseSpa(spa =>
        {
            spa.UseProxyToSpaDevelopmentServer("https://localhost:6363");
        });
    });
}
else
{
    app.Map(new PathString(spaPath), client =>
    {
        client.UseSpaStaticFiles();
        client.UseSpa(spa =>
        {
            spa.Options.SourcePath = "client";
            spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ResponseHeaders headers = ctx.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue
                    {
                        NoCache = true,
                        NoStore = true,
                        MustRevalidate = true,
                    };
                }
            };
        });
    });
}

app.Run();
