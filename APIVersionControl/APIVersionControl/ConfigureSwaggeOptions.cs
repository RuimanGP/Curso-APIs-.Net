using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using static APIVersionControl.ConfigureSwaggeOptions;
using Microsoft.OpenApi.Models;

namespace APIVersionControl
{

    public class ConfigureSwaggeOptions: IConfigureNameOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        public ConfigureSwaggeOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "My .Net Api restful",
                Version = description.ApiVersion.ToString(),
                Description = "This is my  first API versioning control",
                Contact = new OpenApiContact()
                {
                    Email = "m@ma.com",
                    Name = "M",
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += "This API version has been depretccated";
            }
        }
        public void Configure(SwaggerGenOptions options)
        {
            // Add swagger Documentation for each API versión we have
            foreach(var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        public void Configure (string name, SwaggerGenOptions options)
        {
            Configure(options);
        }
  
    }

    public interface IConfigureNameOptions<T>
    {
    }
}
