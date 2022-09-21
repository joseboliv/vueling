namespace Api.GNB.Module.Swagger
{
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System;

    public sealed class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private const string UriString = "https://bitbucket.org/vueling-otd-backend20/jos-bolvar-salazar/wiki/Home";

        private const string UriString1 = "https://bitbucket.org/vueling-otd-backend20/jos-bolvar-salazar/wiki/Home";

        private readonly IApiVersionDescriptionProvider _provider;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigureSwaggerOptions" /> class.
        /// </summary>
        /// <param name="provider">
        ///     The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger
        ///     documents.
        /// </param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this._provider = provider;

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently
            foreach (ApiVersionDescription description in this._provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            OpenApiInfo info = new OpenApiInfo
            {
                Title = "Api GNB",
                Version = description.ApiVersion.ToString(),
                Description = "Test Vueling.",
                Contact = new OpenApiContact { Name = "Jose Bolivar", Email = "jose_boliv@hotmail.com" },
                TermsOfService = new Uri(UriString),
                License = new OpenApiLicense
                {
                    Name = "Apache License",
                    Url = new Uri(
                        UriString1)
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}
