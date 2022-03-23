using BlazerBank.Command.Accounts.Command;
using BlazerBank.Command.Cards.Command;
using BlazerBank.Command.Customers.Command;
using BlazerBank.Command.Transactions.Command;
using BlazerBank.Domain.ILogger;
using BlazerBank.Infrastructure.Data;
using BlazerBank.Infrastructure.LoggerManager;
using BlazerBank.Infrastructure.Repositories;
using BlazerBank.Query.Accounts.Query;
using BlazerBank.Query.Cards.Query;
using BlazerBank.Query.Customers.Query;
using BlazerBank.Query.Transactions.Query;
using MediatR;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();



builder.Services.AddTransient<CustomerRepository>();
builder.Services.AddTransient<AccountRepository>();
builder.Services.AddTransient<CardRepository>();
builder.Services.AddTransient<TransactionRepository>();

builder.Services.AddMediatR(typeof(CreateAccountCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteAccountCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateAccountCommand).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(CreateCustomerCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteCustomerCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateCustomerCommand).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(CreateCardCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteCardCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateCardCommand).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(CreateTransactionCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteTransactionCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateTransactionCommand).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(GetAccountByIDQuery).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetAllAccountsQuery).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(GetCardByIDQuery).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetAllCardsQuery).GetTypeInfo().Assembly);

builder.Services.AddMediatR(typeof(GetCustomerByIDQuery).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetAllCustomersQuery).GetTypeInfo().Assembly);


builder.Services.AddMediatR(typeof(GetTransactionByIDQuery).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetAllTransactionsQuery).GetTypeInfo().Assembly);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<BlazerBankDBContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
