using Microsoft.Extensions.DependencyInjection;

namespace ArtQuiz.Infrastructure
{
    public interface IApplicationConfigurationBuilder
    {
        IApplicationConfigurationBuilder UseApiAuthentication();
    }

    internal sealed class ApplicationConfigurationBuilder : IApplicationConfigurationBuilder
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly string _dataBaseConnectionString;

        public ApplicationConfigurationBuilder(IServiceCollection serviceCollection, string dataBaseConnectionString)
        {
            _serviceCollection = serviceCollection;
            _dataBaseConnectionString = dataBaseConnectionString;
        }

        public IApplicationConfigurationBuilder UseApiAuthentication()
        {
            return this;
        }
    }
}