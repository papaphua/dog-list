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

## Features
1. **Filtering**
- The FilteringQuery record allows users to specify:
  - **Attribute**:
    - This optional parameter lets users select which attribute of the dog data (e.g., name, color, tail length, weight) they want to use as a basis for sorting. If not specified, the data will default to being sorted by name.
   - **Order**:
     - Defaults to "asc" (ascending) but can be set to "desc" (descending) to reverse the sorting order.
2. **Pagination**
- The PagingQuery record defines the parameters for pagination:
  - **PageNumber**:
    - Specifies which page of the dataset to retrieve.
  - **PageSize**:
    - Defines the number of items per page.
- **Behaviour**:
  -  If PagingQuery is not set API will return all data without any pagination applied and response will not include any paging information.

## Structure
- src
  - **DogList.App** — the entry point of the application.
  - **DogList.Application** — responsible for application logic.
  - **DogList.Domain** — core business logic and rules.
  - **DogList.Persistence** — responsible for managing data storage and retrieval.
  - **DogList.Presentation** — handles user interaction and API endpoints.
- tests
  - **DogList.Tests.Application** — unit tests for the Application layer.
  - **DogList.Tests.Persistence** — integration tests for the Persistence layer,

## Patterns
1. **Generic Repository** — provides a standard way to handle data access for a specific entity type.
2. **Unit of Work** — provides methods to manage transactions and persist changes to the database.
3. **Result Pattern** — encapsulates the outcome of an operation, provides predefined errors for specific entity type.
4. **Options Pattern** — provides a way to bind strongly-typed configurations.

## Third-Party Libraies
1. **Scrutor** — dependency injection enhancements allowing for automatic registration of services based on rules.
2. **Serilog.AspNetCore** — logging.
3. **Swashbuckle.AspNetCore** — documented API for testing purposes.
4. **AutoMapper** — mapping entities to DTOs.
5. **System.Linq.Dynamic.Core** — dynamic LINQ queries. Used to dynamically generate filtering for any entity.
