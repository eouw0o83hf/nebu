namespace Nebu.Api.Services;

using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Swashbuckle.AspNetCore.Swagger;

public class SwaggerService(ISwaggerProvider sp)
{
    public void WriteSwaggerDocs(string path)
    {
        var doc = sp.GetSwagger("v1", null, "/");
        var json = doc.SerializeAsJson(OpenApiSpecVersion.OpenApi3_0);
        File.WriteAllText(path, json);
    }
}
