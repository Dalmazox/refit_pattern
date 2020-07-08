using System;

namespace Library.ValueObjects
{
    public class HermesServiceBind
    {
        public Type InterfaceType { get; private set; }
        public Type ConcreteType { get; private set; }

        public HermesServiceBind(Type interfaceType, Type concreteType)
        {
            InterfaceType = interfaceType;
            ConcreteType = concreteType;
        }
    }
}