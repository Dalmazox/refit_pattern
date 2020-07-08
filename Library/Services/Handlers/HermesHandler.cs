using System;
using Library.Interfaces.Handlers;
using Library.Services.Requests;
using Library.ValueObjects;

namespace Library.Services.Handlers
{
    public class HermesHandler : IHermesHandler
    {
        private HermesCollection _collection;

        public HermesHandler(HermesCollection collection)
        {
            _collection = collection;
        }

        T IHermesHandler.Service<T>()
        {
            Type typeService = null;
            var typeT = typeof(T);

            if ((_collection != null) && (_collection.HasConcreteImplemented(typeT)))
                typeService = _collection.GetImplementationType(typeT)
                    ?? throw new ArgumentNullException($"{typeof(T).ToString()} não foi implementado");

            if (!typeService.IsSubclassOf(typeof(RequestService)))
                throw new ArgumentException($"{typeService.ToString()} não implementa {typeof(RequestService).ToString()}");

            return (T)Activator.CreateInstance(typeService);
        }

        public void Dispose()
        {
            _collection.Dispose();
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}