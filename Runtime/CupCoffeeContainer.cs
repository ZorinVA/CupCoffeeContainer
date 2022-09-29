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

        public BindContext<T> Bind<T>()
        {
            return new BindContext<T>(_container);
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}