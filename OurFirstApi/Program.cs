using Microsoft.AspNetCore.Server.Kestrel.Core;
using OurFirstApi.Middlewares;
using MediatR;
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("copyright.json", false, true);

var config = builder.Configuration;
config.GetValue<string>("AllowedHosts");
builder.Services.AddSingleton<IConfiguration>(config);
// Add services to the container.
var secretKey = config.GetValue<string>("SecretKey"); //T�M DOSYA YER�NE BEL�RL� OLANI D�REKT OKUMAYI SA�LADI.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program));
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<GlobalExceptionHandler>();
//BURAYA EKLED�K B�Z�MK�N�

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//BU �STEKK�LER MIDDLEWARE - SIRASINI B�Z BEL�RLEYEB�L�R�Z.
// CLIENT -REQUEST-> MW ... --> [ENDPOINTS]-|
//              RESPONSE <---- MW5 ---------|

app.Run();



/*
 * Client=>Request=> M1=>M2=M3=> M....   => [endpoints]
 *        Response<=================== <==M5===========================
 */
 
 /*
  * IActionFilter
  */

