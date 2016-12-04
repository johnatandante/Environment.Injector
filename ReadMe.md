# Model Service
## A simple DotNet Core Lib Dependency Injector tool

### How it works
Customize your environment with a simple environment.
Just add it into your project and Set Up your code.

'var env = ModelService.Instance.Map<TInterface, TClass>();'
'TClass objcet = env.GetNew<TInterface>();'

### No more "new" statement
Avoid "new" statement with 'GetNew<T>' method: it supports every public constructor with any argument.
Try if you do not trust it!

### Map every environment
Customize your Test Context with any environment, but remember: types doesn't share context;

'var env1 = new ModelService().Map<TInterface, TClass1>();'
'var env2 = ModelService.Instance.Map<TInterface, TClass2>();'
'var env3 = new ModelService().Map<TInterface, TClass3>();'




