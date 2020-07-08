using Library.Interfaces.Services;
using Refit;

namespace Library.Services
{
    public class HermesService : IHermesService
    {
        public T GetClient<T>(string requestTo) where T : class
        {
            return RestService.For<T>(requestTo);
        }
    }
}