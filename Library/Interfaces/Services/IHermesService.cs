namespace Library.Interfaces.Services
{
    public interface IHermesService
    {
        T GetClient<T>(string requestTo) where T : class;
    }
}