# .NET Task Management API

This project is a task management API built with .NET 8.0. It provides full CRUD (Create, Read, Update, Delete) operations for managing to-do tasks. The API uses SQLite for data persistence and includes OpenAPI specifications for documentation, accessible via Swagger UI.

## Features

*   **RESTful API:** Implements standard HTTP methods for task management.
*   **CRUD Operations:** Supports creating, retrieving, updating, and deleting to-do tasks.
*   **Data Persistence:** Utilizes SQLite for a lightweight and file-based database.
*   **API Documentation:** Auto-generated API documentation using Swagger/OpenAPI.
*   **Layered Architecture:** Follows a clean architecture with separate layers for API, Core, and Infrastructure.

## Table of Contents

*   [Features](#features)
*   [Table of Contents](#table-of-contents)
*   [Project Structure](#project-structure)
*   [Getting Started](#getting-started)
*   [API Endpoints](#api-endpoints)
*   [Models](#models)
*   [Contributing](#contributing)
*   [License](#license)

## Project Structure

The project is organized into the following main modules:

*   **`TaskManagementApi.Api`**: The entry point of the application, containing controllers and program configuration.
*   **`TaskManagementApi.Core`**: Contains the core domain logic, including models, DTOs, and interfaces.
*   **`TaskManagementApi.Infrastructure`**: Handles data access, including the database context and repositories.
*   **`TaskManagementApi.Services`**: Implements the business logic for task management.

## Getting Started

### Prerequisites

*   .NET 8.0 SDK
*   An IDE like Visual Studio or VS Code

### Installation

1.  **Clone the repository:**
    ```bash
    git clone <repository-url>
    cd TaskManagementApi
    ```

2.  **Restore NuGet packages:**
    ```bash
    dotnet restore
    ```

3.  **Run the application:**
    ```bash
    dotnet run --project TaskManagementApi.Api/TaskManagementApi.Api.csproj
    ```

The application will start, and the Swagger UI will be available at `https://localhost:<port>/swagger`.

## API Endpoints

The API provides the following endpoints for managing to-do tasks:

| HTTP Method | Endpoint            | Description                       | Request Body        | Response Body         |
| :---------- | :------------------ | :-------------------------------- | :------------------ | :-------------------- |
| `GET`       | `/api/TodoTasks`    | Retrieves all to-do tasks.        | None                | `IEnumerable<TodoTaskDto>` |
| `GET`       | `/api/TodoTasks/{id}` | Retrieves a specific task by ID.  | None                | `TodoTaskDto`         |
| `POST`      | `/api/TodoTasks`    | Creates a new to-do task.         | `TodoTaskDto`       | `TodoTaskDto`         |
| `PUT`       | `/api/TodoTasks/{id}` | Updates an existing task.         | `TodoTaskDto`       | None (`204 No Content`) |
| `DELETE`    | `/api/TodoTasks/{id}` | Deletes a task by its ID.         | None                | None (`204 No Content`) |

## Models

### `TodoTask` (Entity)

Represents the structure of a to-do task in the database.

| Property        | Type  | Description                                 |
| :-------------- | :---- | :------------------------------------------ |
| `Id`            | `int` | Unique identifier of the to-do task (Primary Key). |
| `Title`         | `string` | The title of the to-do task.                |
| `Description`   | `string` | A detailed description of the to-do task.   |
| `IsCompleted`   | `bool` | A flag indicating whether the task is completed (defaults to `false`). |

### `TodoTaskDto` (Data Transfer Object)

Used for transferring to-do task data between layers.

| Property        | Type  | Description                                 |
| :-------------- | :---- | :------------------------------------------ |
| `Id`            | `int` | Unique identifier of the to-do task.        |
| `Title`         | `string` | The title of the to-do task.                |
| `Description`   | `string` | A detailed description of the to-do task.   |
| `IsCompleted`   | `bool` | A flag indicating whether the task is completed. |

## Contributing

Contributions are welcome! Please refer to the [CONTRIBUTING.md](CONTRIBUTING.md) file for guidelines.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
