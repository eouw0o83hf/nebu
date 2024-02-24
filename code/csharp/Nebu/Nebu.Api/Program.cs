using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Minio;
using Nebu.Api.Ef;
using Nebu.Api.Models.Blobs;
using Nebu.Api.Models.Buckets;
using Nebu.Api.Models.Users;
using Nebu.Api.Services;
using Swashbuckle.AspNetCore.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NebuContext>(o =>
    o.UseNpgsql(
        builder.Configuration.GetConnectionString("Nebu")));

// temp local secret values
builder.Services.AddMinio(cfg => cfg
    .WithCredentials("3PEZwSncibPRafAEVVqE", "zWQSfoxyxTldqQJuwcCK7nF2ii6n25AzFevDcH7W")
    .WithSSL(false));

builder.Services.AddTransient<IBlobService, BlobService>();
builder.Services.AddTransient<IBucketService, BucketService>();
builder.Services.AddTransient<SwaggerService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<NebuContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapSwagger();
app.MapControllers();

// dump swagger to filesystem on api start so it's always fresh
// and we can verify in ci that nothing changed
using (var scope = app.Services.CreateScope())
{
    var swag = scope.ServiceProvider.GetRequiredService<SwaggerService>();
    swag.WriteSwaggerDocs("../../../contracts/api.json");
}

app.Run();

