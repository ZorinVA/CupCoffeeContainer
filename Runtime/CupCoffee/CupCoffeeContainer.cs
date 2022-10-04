using CupCoffee.Core;
using ServiceLocator;

namespace CupCoffee
{
    public sealed class CupCoffeeContainer 
    {
        private readonly IServiceLocator _container;

        public CupCoffeeContainer(IServiceLocator container)
        {
            _container = container;
        }

        public IBindContext<TKey> Bind<TKey>()
        {
            return new BindContext<TKey>(_container);
        }

        public TKey Resolve<TKey>()
        {
            return _container.Resolve<TKey>();
        }
    }
}