# CleanArchitectureApi

Ett ASP.NET Core Web API byggt med Clean Architecture, CQRS, MediatR, Repository Pattern och Entity Framework Core.

## Projektstruktur

Lösningen är uppdelad i fyra lager:

- `CleanArchitectureApi` - API-lager med controllers och programkonfiguration
- `CleanArchitectureApi.Application` - application-lager med queries, handlers och affärslogik
- `CleanArchitectureApi.Domain` - domain-lager med entiteter och interfaces
- `CleanArchitectureApi.Infrastructure` - infrastructure-lager med DbContext, repositories och migrations

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

Relation:
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

Projektet använder CQRS med MediatR i application-lagret.

Exempel:
- Queries används för att hämta produkter
- MediatR används i controllers för att skicka requests till handlers

## Repository Pattern

Repository Pattern används för `Product`.

- Interface finns i `Domain`
- Implementation finns i `Infrastructure`

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
3. Kontrollera att databasen och connection string i `appsettings.json` stämmer
4. Kör projektet
5. Öppna Swagger i webbläsaren
