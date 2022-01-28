using JetBrains.Annotations;
using System.Net.Http;

namespace Demo.Framework.Net.Http
{
    public interface IRestClient
    {
        string EndpointName { get; }

        void ConfigureClient([NotNull] IHttpClient client);

        void ConfigureHandler([NotNull] HttpClientHandler handler);
    }
}
