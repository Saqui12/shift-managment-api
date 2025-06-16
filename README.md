#  Management API - Entertainment Center

This RESTful API was developed to manage an entertainment center (such as sports courts, recreational halls, or game centers). It focuses on backend best practices using modern .NET technologies and clean architecture.
## Key Features
- **Resource Management**: Manage resources, availability, and bookings efficiently.
- **Authentication & Authorization**: Secure access using JWT-based authentication.
- **Error Handling**: Centralized exception handling.
- **Logging**: Logging for debugging and monitoring.
- **Azure**: Depoyed in Azure.


## 🛠 Technologies & Tools


#### Backend Framework
- **ASP.NET Core 8.0**: Provides the foundation for building the web API, including dependency injection, middleware, and routing.
#### Database
- **Entity Framework Core 8.0**: Used for database access and management
- **PostgreSQL (Supabase)**: The primary relational database for production.
#### Authentication & Authorization
- **JWT (JSON Web Tokens)**: Secures API endpoints using bearer tokens for authentication.
- **ASP.NET Core Identity**: Manages user authentication and roles.
#### Dependency Injection
- **Custom DI Extensions**: The application uses custom dependency injection methods to register services and middleware.
#### Logging
- **Serilog**: Provides structured logging with sinks for console and file outputs.
#### Testing
- **xUnit**: A testing framework used for integration tests.
- **WebApplicationFactory**: Creates an in-memory test server for API testing.
#### Middleware
- **Custom Error Handling Middleware**: Captures and logs unhandled exceptions, returning standardized error responses.
#### Code Quality
- **FluentValidation**: Validates input models to ensure data integrity.
- **Mapster**: Simplifies object mapping between DTOs and entities.
#### Deployment
- **Azure**: The current api is deployed in App Service , the front-end in a Static Web App.
#### Project Structure
- **AppGestionPeloteros**: Main application project.
- **Application**: Contains business logic and service interfaces.
- **Dominio**: Defines core entities and domain models.
- **Infrastructure**: Implements data access and middleware.

## Try it !

Go to : https://blue-plant-09cf3ff03.6.azurestaticapps.net/

User : admin@gmail.com

Password: Admin1234!

or 

User : employee@gmail.com

Password: Employee1234!


## 📚 Status & Future Improvements

- In current development
  
- Employees Managment
- Google Calendar export/import
- Settings
- Test


### Author

Manuel Nunez

LinkedIn https://www.linkedin.com/in/manuel-nunez12/
