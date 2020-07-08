using System;
using Library.Interfaces.Services.Requests;

namespace Library.Interfaces.Handlers
{
    public interface IHermesHandler : IDisposable
    {
        T Service<T>() where T : class, IRequestService;
    }
}