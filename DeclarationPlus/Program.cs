using Common.Core.CQRS;
using DeclarationPlus.Infrastructure.FakeRepository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDeclarationPlusFakeRepositoriesServices(builder.Configuration);
builder.Services.AddQueries();
builder.Services.AddCommands();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

