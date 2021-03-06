using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DependencyInjection
{
    public class DependencyConfig
    {
        public readonly Dictionary<Type, List<ImplementationInfo>> RegisteredDependencies;

        public DependencyConfig()
        {
            RegisteredDependencies = new Dictionary<Type, List<ImplementationInfo>>();
        }

        public void Register(Type tDependency, Type tImplementation, LifeTime lifetime)
        {
            if (tDependency.IsValueType)
                throw new ArgumentException("TDependency must be a reference type");

            if (tImplementation.IsAbstract)
                throw new ArgumentException("TImplementation can't be an abstract class");

            if (!tImplementation.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Any())
                throw new ArgumentException("TImplementation doesn't have any public constructors");

            if (!tDependency.IsAssignableFrom(tImplementation) && !tDependency.IsGenericTypeDefinition)
                throw new ArgumentException("TImplementation doesn't implement TDependency interface");

            //Если в словаре нет такого интерфейса, создаем запись и список
            if (!RegisteredDependencies.ContainsKey(tDependency))
                RegisteredDependencies.Add(tDependency, new List<ImplementationInfo>());

            if (RegisteredDependencies[tDependency].Find(item => item.ImplementationType == tImplementation) != null)
                throw new ArgumentException("Such dependency is already registered");

            else
            {
                ImplementationInfo impl = new ImplementationInfo(tImplementation, lifetime);
                RegisteredDependencies[tDependency].Add(impl);
            }
        }

        public void Register<TDependency, TImplementation>(LifeTime lifetime) where TDependency : class
                                                                              where TImplementation : TDependency
        {
            Register(typeof(TDependency), typeof(TImplementation), lifetime);
        }
    }
}
