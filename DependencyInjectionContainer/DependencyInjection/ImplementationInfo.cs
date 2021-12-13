using System;

namespace DependencyInjection
{
    public enum LifeTime
    {
        Singleton, /*на все запросы зависимостей возвращается один экземпляр объекта*/

        Instance   /*каждый новый запрос зависимости из контейнера приводит к созданию нового объекта*/
    }

    public class ImplementationInfo
    {
        internal Type ImplementationType;
        internal LifeTime LifeTime;

        public ImplementationInfo(Type _implementationType, LifeTime _lifeTime)
        {
            ImplementationType = _implementationType;
            LifeTime = _lifeTime;
        }
    }
}
