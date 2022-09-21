namespace Utilities.Http
{
    using System.Threading.Tasks;

    public interface IHttpClientServices
    {
        Task<Response> GetUnAuthAsync<Response>(string pathUrl);
    }
}