using System;
using Library.Interfaces.Factories;
using Library.Interfaces.Handlers;
using Library.Interfaces.Services.Requests;
using Library.Services.Handlers;
using Library.Services.Requests;
using Library.ValueObjects;

namespace Library.Factories
{
    public class HermesHandlerFactory : IHermesHandlerFactory
    {
        public IHermesHandler Create()
        {
            var collection = new HermesCollection();
            BindServices(collection);
            return new HermesHandler(collection);
        }

        protected void BindServices(HermesCollection collection)
        {
            collection
                .AddBind<ITodoRequestService, TodoRequestService>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}