namespace Data.GNB.Seeder
{
    using Data.GNB.Context;
    using Microsoft.Extensions.Configuration;
    using System.Threading.Tasks;
    using Utilities.Logger;

    public class DbGenerate : IDbGenerate
    {
        private readonly GNBDbContext context;
        private readonly IConfiguration configuration;
        private readonly ILoggerGNB<DbGenerate> logger;

        public DbGenerate(
            GNBDbContext context,
            IConfiguration configuration,
            ILoggerGNB<DbGenerate> logger
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
