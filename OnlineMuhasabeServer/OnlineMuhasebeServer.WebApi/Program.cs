using Microsoft.AspNetCore.Identity;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.WebApi.Configurations;
using OnlineMuhasebeServer.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);

// Add services to the container.



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionMiddleware();

app.UseHttpsRedirection();


app.UseCors();

app.MapControllers();

using (var scoped = app.Services.CreateScope())
{
    var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    if (!userManager.Users.Any())
    {
        userManager.CreateAsync(new AppUser
        {
            UserName = "admin",
            Email = "admin@admin.com",
            Id = Guid.NewGuid().ToString(),
            NameLastName = "Mustafa Kosem"
        }, "Password12*").Wait();
    }
}
app.Run();

