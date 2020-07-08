using System;
using Library.Interfaces.Handlers;

namespace Library.Interfaces.Factories
{
    public interface IHermesHandlerFactory : IDisposable
    {
        IHermesHandler Create();
    }
}