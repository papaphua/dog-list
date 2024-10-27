# Dog List

## How to launch

1. Run the following command to create migration within src/DogList.Persistence:

```shell
dotnet ef migrations add Init --startup-project "../DogList.App"
```

2. Run the following command to apply migration within src/DogList.Persistence:

```shell
dotnet ef database update --startup-project "../DogList.App"
```