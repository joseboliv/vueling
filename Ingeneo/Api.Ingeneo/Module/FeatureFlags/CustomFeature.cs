namespace Api.GNB.Module.FeatureFlags
{
    public enum CustomFeature
    {
        /// <summary>
        ///     Use Swagger.
        /// </summary>
        Swagger,

        /// <summary>
        ///     Use SQL Server Persistence.
        /// </summary>
        SQLServer,

        /// <summary>
        ///     Uses external exchange service.
        /// </summary>
        CurrencyExchange,

        /// <summary>
        ///     Use authentication.
        /// </summary>
        Authentication,

        /// <summary>
        ///     Filter errors out.
        /// </summary>
        ErrorFilter,
    }
}
