using MovieRazor.Extensions;
using MovieRazor.Repositories;
using MovieRazor.Repositories.Interfaces;
using MovieRazor.Services;
using MovieRazor.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ICustomLogger, CustomLogger>();
builder.Services.AddSingleton<IMovieRepository, MovieRepository>();

// builder.Services.RegisterRepos();

// Add services to the container.
builder.Services.AddRazorPages().
    AddRazorPagesOptions(option =>
    {
        option.Conventions.AddPageRoute("/Movies", "");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


/*// добавляет базовый функционал MVC
builder.Services.AddMvc();

// добавляет поддержку для MVC контроллеров
builder.Services.AddControllers();

// добавляет поддержку логирования
builder.Services.AddLogging();

// добавляет поддержку SignalR
builder.Services.AddSignalR();

// защита от скриптинга
builder.Services.AddAntiforgery(option =>
{ 
    option.FormFieldName = "AntiforgeryFieldName"; 
    option.HeaderName = "X-CSRF-TOKEN-HEADERNAME"; 
});*/