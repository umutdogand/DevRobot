namespace MvcTool.Helper
{
    using Microsoft.Extensions.DependencyInjection;

    public static class SessionScopeFactory
    {
        private static IServiceScopeFactory _factory;

        public static IServiceScopeFactory Current => _factory;

        internal static void Configure(IServiceScopeFactory factory)
        {
            _factory = factory;
        }
    }
}