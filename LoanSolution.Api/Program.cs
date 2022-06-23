using LoanSolution.Core.Repositories;
using LoanSolution.Core.Validators;
using LoanSolution.Persistence.Repositories;
using LoanSolution.Persistence.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IMandatoryValidator, DefaultMandatoryValidator>();
builder.Services.AddTransient<IPhoneNumberValidator, DefaultPhoneNumberValidator>();
builder.Services.AddTransient<ILoanSettingRepository, LoanSettingConfiguration>();
builder.Services.AddTransient<IBusinessNumberValidator, ExternalBusinessNumberValidator>();
builder.Services.AddTransient<ILoanValidator, DefaultLoanValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
