using System;
using ServiceLocator;

namespace CupCoffee.Core
{
    internal readonly struct BindContext<TKey> : IBindContext<TKey>
    {
        private readonly IServiceLocator _container;

        internal BindContext(IServiceLocator container)
        {
            _container = container;
        }
        
        public void AsTransient(Func<TKey> resolver)
        {
            _container.RegisterTransient(resolver);
        }
        
        public void AsTransient<TClass>() where TClass : TKey, new()
        {
            _container.RegisterTransient<TKey>(() => new TClass());
        }
        
        public void AsSingleton(TKey singleton)
        {
            _container.RegisterSingleton(singleton);
        }
        
        public void AsSingleton<TClass>() where TClass : TKey, new()
        {
            _container.RegisterSingleton<TKey>(new TClass());
        }
        
        public void AsLazySingleton(Func<TKey> resolver)
        {
            _container.RegisterLazySingleton(resolver);
        }
        
        public void AsLazySingleton<TClass>() where TClass : TKey, new()
        {
            _container.RegisterLazySingleton<TKey>(() => new TClass());
        }
    }
}