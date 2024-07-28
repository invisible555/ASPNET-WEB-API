## Wymagane pakiety NuGet

Aby uruchomić aplikację, upewnij się, że masz zainstalowane następujące pakiety NuGet:

1. **Microsoft.AspNetCore.App**: Podstawowe biblioteki ASP.NET Core.
2. **Microsoft.EntityFrameworkCore**: ORM dla ASP.NET Core (jeśli używasz EF Core).
3. **Microsoft.EntityFrameworkCore.SqlServer**: Dostawca bazy danych SQL Server dla EF Core (lub inny dostawca w zależności od używanej bazy danych).
4. **Swashbuckle.AspNetCore**: Integracja Swaggera z API.

## Instrukcja uruchomienia API

Aby uruchomić aplikację ASP.NET Core Web API, wykonaj poniższe kroki:

1. **Otwórz PowerShell**:
   - Otwórz PowerShell na swoim komputerze.

2. **Przejdź do katalogu projektu**:
   - Przejdź do katalogu, w którym znajduje się projekt Backend:

     ```powershell
     cd /sciezka/do/folderu/Backend
     ```

3. **Uruchom aplikację**:
   - W katalogu `Projekt` wpisz polecenie, aby uruchomić aplikację:

     ```powershell
     dotnet run
     ```

4. **Otwórz przeglądarkę**:
   - Po uruchomieniu aplikacji otwórz przeglądarkę internetową i przejdź do adresu:

     ```
     https://localhost:7150/swagger/index.html
     ```

   - Powinieneś zobaczyć interfejs Swagger, który pozwala na interakcję z Twoim API.
  
  **FrontEnd** w przygotowaniu 
