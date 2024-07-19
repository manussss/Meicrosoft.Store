using Meicrosoft.Store.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositoriesInjection();
builder.Services.AddDatabaseInjection(builder.Configuration);
builder.Services.AddMediatorInjection();

builder.Services.AddApiVersioning();

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseApiVersioning();
app.UseAuthorization();
app.MapControllers();

app.Run();
