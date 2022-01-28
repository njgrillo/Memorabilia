using JetBrains.Annotations;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Demo.Framework.Net.Http
{
    public abstract class RestClient : IRestClient, IDisposable
    {
        private bool _disposed;
        private IHttpClient _httpClient;

        //protected RestClient([NotNull] IRestClientBuilder clientBuilder)
        //{
        //    clientBuilder.Build(this);
        //}

        protected abstract string EndpointName { get; }

        protected IHttpClient HttpClient
        {
            get
            {
                CheckDisposed();

                return _httpClient;
            }
            private set => _httpClient = value;
        }

        string IRestClient.EndpointName => throw new NotImplementedException();

        void IRestClient.ConfigureClient(IHttpClient client)
        {
            ConfigureClient(client);

            HttpClient = client;
        }

        void IRestClient.ConfigureHandler(HttpClientHandler handler)
        {
            ConfigureHandler(handler);
        }

        protected virtual void ConfigureClient([NotNull] IHttpClient client) { }

        protected virtual void ConfigureHandler([NotNull] HttpClientHandler handler) { }

        protected async Task Delete(string requestUri)
        {
            CheckDisposed();

            using (var response = await HttpClient.Delete(requestUri).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                HttpClient?.Dispose();

            _disposed = true;
        }

        //protected Task<TResponse> Get<TResponse>(string requestUri)
        //{
        //    CheckDisposed();

        //    return HttpClient.GetObject<TResponse>(requestUri);
        //}

        private void CheckDisposed()
        {
            if (!_disposed)
                return;

            throw new ObjectDisposedException(GetType().FullName);
        }
    }
}
