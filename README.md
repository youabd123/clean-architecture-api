# CleanArchitectureApi

Ett ASP.NET Core Web API byggt med Clean Architecture, CQRS, MediatR, Repository Pattern och Entity Framework Core.

## Projektstruktur

Lösningen är uppdelad i fyra lager:

- `CleanArchitectureApi` - API-lager med controllers och programkonfiguration
- `CleanArchitectureApi.Application` - Application-lager med commands, queries, handlers och affärslogik
- `CleanArchitectureApi.Domain` - Domain-lager med entiteter och interfaces
- `CleanArchitectureApi.Infrastructure` - Infrastructure-lager med DbContext, repositories och migrations

## Tekniker

Projektet använder följande tekniker:

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / LocalDB
- MediatR
- Swagger

## Entiteter

Projektet innehåller två modeller:

- `Product`
- `Category`

### Relation

- En `Category` kan ha många `Products`

## Funktionalitet

### Product
- Hämta alla produkter
- Hämta produkt med id
- Skapa produkt
- Uppdatera produkt
- Ta bort produkt

### Category
- Hämta alla kategorier
- Skapa kategori

## CQRS och MediatR

Projektet använder CQRS med MediatR i Application-lagret.

- Queries används för att hämta data
- Commands används för att skapa, uppdatera och ta bort data
- Handlers hanterar logiken för varje command och query

Exempel:
- `GetAllProductsQuery`
- `GetProductByIdQuery`
- `CreateProductCommand`
- `UpdateProductCommand`
- `DeleteProductCommand`
- `GetAllCategoriesQuery`
- `CreateCategoryCommand`

## Repository Pattern

Repository Pattern används för att separera databaskoden från resten av applikationen.

- Interfaces finns i `Domain`
- Implementationer finns i `Infrastructure`

Repositories i projektet:
- `IProductRepository` / `ProductRepository`
- `ICategoryRepository` / `CategoryRepository`

## Databas

Projektet använder Entity Framework Core med SQL Server LocalDB.

Connection string finns i:

- `appsettings.json`

Migrationer finns i:

- `CleanArchitectureApi.Infrastructure/Migrations`

## Dokumentation

Swagger är aktiverat i projektet och kan användas för att testa alla endpoints när applikationen körs.

## Så kör du projektet

1. Klona repot
2. Öppna lösningen i Visual Studio
3. Kontrollera connection string i `appsettings.json`
4. Kör projektet
5. Öppna Swagger i webbläsaren för att testa endpoints
