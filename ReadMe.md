# Model Service
## A simple DotNet Core Lib Dependency Injector tool

### How it works
Customize your environment with a simple environment.
Just add it into your project and Set Up your code.

```
var singletonEnv = ModelService.Instance;
singletonEnv.Map<TInterface, TClass>();

TClass objcet = singletonEnv.GetNew<TInterface>();
```

### No more new statement
Avoid **new** statement with `GetNew<T>` method: it supports every public constructor with any argument.
Try if you do not trust it!

```
string args = new string[] {"arg1", "arg2"};
var env = ModelService.Instance
                    .Map<TInterface, TClassWithArgs>();
TClass objcet = env.GetNew<TInterface>(args);
```
con 
```
class TClassWithArgs{
  public TClassWithArgs(string[] args) { 
    //... 
  }
}

```

### Map every environment
Customize your Test Context with any environment, but remember: *types doesn't share context*;

```
var env1 = new ModelService().Map<TInterface, TClass1>();
var env2 = ModelService.Instance.Map<TInterface, TClass2>();
var env3 = new ModelService().Map<TInterface, TClass3>();
```

Every Environment owns their mapping to `TInterface`

```
TClass1 objectClass1 = env1.GetNew<TInterface>();
TClass2 objectClass2 = env2.GetNew<TInterface>();
TClass3 objectClass3 = env3.GetNew<TInterface>();

```
