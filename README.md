#  Management API - Entertainment Center

This RESTful API was developed as a personal project to manage an entertainment center (such as sports courts, recreational halls, or game centers). It focuses on backend best practices using modern .NET technologies and clean architecture.
## Key Features
- **Resource Management**: Manage resources, availability, and bookings efficiently.
- **Authentication & Authorization**: Secure access using JWT-based authentication.
- **Error Handling**: Robust middleware for centralized exception handling.
- **Logging**: Comprehensive logging for debugging and monitoring.
- **API Documentation**: Interactive Swagger UI for exploring and testing API endpoints.
- **Testing**: Ensures reliability and correctness of API functionality.

## 🛠 Technologies & Tools


#### Backend Framework
- **ASP.NET Core 8.0**: Provides the foundation for building the web API, including dependency injection, middleware, and routing.
#### Database
- **Entity Framework Core 8.0**: Used for database access and management, supporting both relational (SQL Server) and in-memory databases for testing.
- **SQL Server**: The primary relational database for production.
#### Authentication & Authorization
- **JWT (JSON Web Tokens)**: Secures API endpoints using bearer tokens for authentication.
- **ASP.NET Core Identity**: Manages user authentication and roles.
#### Dependency Injection
- **Custom DI Extensions**: The application uses custom dependency injection methods to register services and middleware.
#### Logging
- **Serilog**: Provides structured logging with sinks for console and file outputs.
#### API Documentation
- **Swashbuckle (Swagger)**: Generates interactive API documentation, including support for JWT authentication.
#### Testing
- **xUnit**: A testing framework used for integration tests.
- **WebApplicationFactory**: Creates an in-memory test server for API testing.
#### Middleware
- **Custom Error Handling Middleware**: Captures and logs unhandled exceptions, returning standardized error responses.
#### Code Quality
- **FluentValidation**: Validates input models to ensure data integrity.
- **Mapster**: Simplifies object mapping between DTOs and entities.
#### Deployment
- **Docker**: Supports containerized deployment with Linux as the default target OS.
#### Project Structure
- **AppGestionPeloteros**: Main application project.
- **Application**: Contains business logic and service interfaces.
- **Dominio**: Defines core entities and domain models.
- **Infrastructure**: Implements data access, authentication, and middleware.
- **Test**: Contains integration and unit tests.


## Getting Started

1. Clone the repository.
2. Build the solution using Visual Studio 2022 or the .NET CLI.
3. Run the application using `dotnet run` or the Visual Studio debugger.
4. Access the Swagger UI at `https://localhost:<port>/swagger`.


## 📚 Status & Future Improvements

- Employees Managment.
- Frontend.
- Deployment.

### Author

 Junior .NET Developer | Electromechanical Engineer

 LinkedIn https://www.linkedin.com/in/manuel-nunez12/
