using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Azure.Identity;
using System;

[assembly: FunctionsStartup(typeof(SampleAzureFunction.Startup))]

namespace SampleAzureFunction
{
    class Startup : FunctionsStartup
    {
        public IConfiguration Configuration { get; }

        public Startup()
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("local.settings.json", true);
            Configuration = config.Build();
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton(provider =>
            {
                var credential = new DefaultAzureCredential();
                var storageAccountName = Configuration["FUNCTION_STORAGE_ACCOUNT_NAME"];
                var serviceUri = new Uri($"https://{storageAccountName}.blob.core.windows.net");
                var blobServiceClient = new BlobServiceClient(serviceUri, credential);
                return blobServiceClient;
            });
        }
    }
}
