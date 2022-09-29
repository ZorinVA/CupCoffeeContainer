using System;
using ServiceLocator;

namespace CupCoffee
{
    public readonly struct BindContext<T>
    {
        private readonly IServiceLocator _container;

        internal BindContext(IServiceLocator container)
        {
            _container = container;
        }
        
        public void AsTransient(Func<T> resolver)
        {
            _container.RegisterTransient<T>(resolver);
        }
        
        public void AsTransient<TClass>() where TClass : T, new()
        {
            AsTransient(() => new TClass());
        }
        
        public void AsSingleton(T singleton)
        {
            _container.RegisterSingleton<T>(singleton);
        }
        
        public void AsSingleton<TClass>() where TClass : T, new()
        {
            AsSingleton(new TClass());
        }
        
        public void AsLazySingleton(Func<T> resolver)
        {
            _container.RegisterLazySingleton<T>(resolver);
        }
        
        public void AsLazySingleton<TClass>() where TClass : T, new()
        {
            AsLazySingleton(() => new TClass());
        }
    }
}