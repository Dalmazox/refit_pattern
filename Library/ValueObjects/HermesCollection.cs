using System;
using System.Collections.Generic;
using Library.Interfaces.Services.Requests;
using Library.Services.Requests;

namespace Library.ValueObjects
{
    public class HermesCollection : IDisposable
    {
        private readonly ICollection<HermesServiceBind> _collection;

        internal HermesCollection()
        {
            _collection = new List<HermesServiceBind>();
        }

        public HermesCollection AddBind<TInterface, TConcrete>()
            where TInterface : IRequestService
            where TConcrete : RequestService, TInterface
        {
            _collection.Add(new HermesServiceBind(typeof(TInterface), typeof(TConcrete)));
            return this;
        }

        public bool HasConcreteImplemented(Type interfaceBind)
        {
            var found = false;

            foreach (var item in _collection)
            {
                found = interfaceBind == item.InterfaceType;

                if (found) break;
            }

            return found;
        }

        public Type GetImplementationType(Type interfaceBind)
        {
            foreach (var item in _collection)
                if (interfaceBind == item.InterfaceType)
                    return item.ConcreteType;

            return null;
        }

        public void Dispose()
        {
            _collection.Clear();
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}