# E Book Web API

This project is a sample application for managing books and categories using ASP.NET Core Web API.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

* Visual Studio
* .NET Core 5.0 or later
* SQL Server

### Installing

1. Clone the repository
```
git clone https://github.com/BerkayMehmetSert/nArchitecture-eBook-api.git
```

2. Open the solution file `nArchitecture.eBook.sln` in Visual Studio or running `dotnet run` in a terminal window

3. Use a tool like [Postman](https://www.postman.com/) to interact with the API endpoints


## API Endpoints

The following endpoints are available:

### Books

- `GET /api/books` - Retrieves a list of all books with pagination support

- `GET /api/books/get-by-id`: Retrieves a book by its ID

- `POST /api/books`: Creates a new book

- `PUT /api/books`: Updates an existing book

- `DELETE /api/books`: Deletes a book by its ID

### Categories

- `GET /api/categories` - Retrieves a list of all categories with pagination support

- `GET /api/categories/get-by-id`: Retrieves a category by its ID

- `POST /api/categories`: Creates a new category

- `PUT /api/categories`: Updates an existing category

- `DELETE /api/categories`: Deletes a category by its ID

## Built With

* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-5.0) - The web framework used
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - The ORM used
* [AutoMapper](https://automapper.org/) - The object-object mapper used
* [FluentValidation](https://fluentvalidation.net/) - The validation library used
* [MediatR](https://github.com/jbogard/MediatR) - The mediator pattern implementation used
* [Swager](https://swagger.io/) - The API documentation tool used

