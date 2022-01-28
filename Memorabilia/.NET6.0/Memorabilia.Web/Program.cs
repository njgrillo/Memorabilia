using Blazored.Toast;
using Demo.Framework.Web;
using MediatR;
using Memorabilia.Application.Features.User;
using Memorabilia.Application.Features.User.Register;
using Memorabilia.Domain;
using Memorabilia.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredToast();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer("name=ConnectionStrings:Memorabilia"));
builder.Services.AddTransient<IContext, Context>();
builder.Services.AddTransient<CommandRouter>();
builder.Services.AddTransient<QueryRouter>();
builder.Services.AddMediatR();

builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<AddUser>();

builder.Services.AddTransient<GetUser>();

//services.AddTransient<SaveBill>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
