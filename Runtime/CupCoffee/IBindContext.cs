using System;

namespace CupCoffee
{
    public interface IBindContext<in TKey>
    {
        void AsTransient(Func<TKey> resolver);
        void AsTransient<TClass>() where TClass : TKey, new();
        void AsSingleton(TKey singleton);
        void AsSingleton<TClass>() where TClass : TKey, new();
        void AsLazySingleton(Func<TKey> resolver);
        void AsLazySingleton<TClass>() where TClass : TKey, new();
    }
}