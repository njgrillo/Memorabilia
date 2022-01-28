using JetBrains.Annotations;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Demo.Framework.Net.Http
{
    public interface IHttpClient : IDisposable
    {
        Task<HttpResponseMessage> Delete([NotNull] string requestUri);

        Task<HttpResponseMessage> Get([NotNull] string requestUri);

        Task<byte[]> GetByteArray([NotNull] string requestUri);

        Task<Stream> GetStream([NotNull] string requestUri);

        Task<string> GetString([NotNull] string requestUri);

        Task<HttpResponseMessage> Post([NotNull] string requestUri, [NotNull] HttpContent content);

        Task<HttpResponseMessage> Put([NotNull] string requestUri, [NotNull] HttpContent content);

        //void SetBaseAddress([NotNull] RequestUrl baseAddress);

        void SetHeader([NotNull] string name, [NotNull] string value);

        void SetMaxBufferSize(long size);

        void SetTimeout(TimeSpan timeout);
    }
}
