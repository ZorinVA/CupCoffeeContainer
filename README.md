# CupCoffeeContainer

## Usage
### Initialization
```csharp
public class ApplicationContext : MonoBehaviour
{
    private static CupCoffeeContainer _container;

    private void Awake()
    {
        _container = new CupCoffeeContainer(new StaticServiceLocator());
    }
	
    //Use Awake or Start
    private void Start()
    {
        _container.Bind<ISomeInterface>().AsSingleton(new SomeClass());
    }
    
    public static T Resolve<T>()
    {
        return _container.Resolve<T>();
    }
}
```

### Resolve
```csharp
public class ResolveExample : MonoBehaviour
{
    private ISomeInterface _someInterface;

    private void Awake()
    {
        _someInterface = ApplicationContext.Resolve<ISomeInterface>();
    }
}
```

### Singleton binding
```csharp
_container.Bind<ISomeInterface>().AsSingleton(new SomeClass());
_container.Bind<ISomeInterface>().AsSingleton<SomeClass>();
```

### Transient binding
```csharp
_container.Bind<ISomeInterface>().AsTransient(() => new SomeClass());
_container.Bind<ISomeInterface>().AsTransient<SomeClass>();
```
	
### Lazy Singleton binding
```csharp
_container.Bind<ISomeInterface>().AsLazySingleton(() => new SomeClass());
_container.Bind<ISomeInterface>().AsLazySingleton<SomeClass>();
```

### MonoBehaviour binding
```csharp
_container.Bind<ISomeInterface>().AsSingleton(instanceReference);
_container.Bind<ISomeInterface>().AsTransient(() => Instantiate(prefabReference));
_container.Bind<ISomeInterface>().AsLazySingleton(() => Instantiate(prefabReference));
```