using MediSys.Infra;
using MediSys.Infra.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddAppConnections(builder.Configuration)
    .AddAndConfigureControllers();

var app = builder.Build();
app.UseDocumentation();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
