namespace Data.Ingenio.Seeder
{
    using Data.Ingenio.Context;
    using Microsoft.Extensions.Configuration;
    using System.Threading.Tasks;
    using Utilities.Logger;

    public class DbGenerate : IDbGenerate
    {
        private readonly IngenioDbContext context;
        private readonly IConfiguration configuration;
        private readonly ILoggerIngenio<DbGenerate> logger;

        public DbGenerate(
            IngenioDbContext context,
            IConfiguration configuration,
            ILoggerIngenio<DbGenerate> logger
            )
        {
            this.context = context;
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task Generate()
        {
            logger.LogInformation("");
            if (configuration.GetValue<bool>("RegenerateDatabase"))
            {
                logger.LogWarning("");
                await context.Database.EnsureDeletedAsync();
            }
            await context.Database.EnsureCreatedAsync();
            logger.LogInformation("");
        }
    }
}
