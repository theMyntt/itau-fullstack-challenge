# Cubo Itaú Full-Stack Challenge

<p align="center">
  <img src="https://cubo.network/assets/images/cubo.svg" width="200">
</p>

## Project Description

This project is a full-stack application developed as part of the Cubo Itaú challenge. The objective of the challenge is to evaluate your skills in full-stack development, including code organization, style, best practices, API creation, and knowledge of frameworks and technologies.

### Technologies Used

- **Front-end:** Blazor
- **Back-end:** ASP.NET Core with .NET 8
- **Testing:** xUnit, Moq, EF InMemoryDb

### Project Structure

The project is divided into several layers to maintain a clean and organized architecture:

- **Adapters/Driving/Presentations:** Contains the controllers and presentation components.
- **Adapters/Driven/Infra.Ioc:** Contains the dependency injection configuration.
- **Adapters/Driven/Infra.Data:** Contains the database context and migrations.
- **Core/Application:** Contains the interfaces and DTOs used in the application.
- **Core/Domain:** Contains the domain entities and business logic.
- **Tests:** Contains the unit test projects.

### Project Configuration

To run the project, you need to create an `appsettings.{environmentName}.json` file in the root of the project, following the same format as `appsettings.json`. This file should contain the specific configurations for the environment in which the application will run.

### Challenge Details

- You can read more in [CHALLENGE file](./CHALLENGE.md)

#### Front-end

The provided layout should be developed using the libraries and frameworks you are most comfortable with. All form fields are required, and tests are welcome.

#### Back-end

The layout includes a form, a table with percentage participation information, and a pie chart representing this distribution. You need to create APIs that send and receive this information. In case of inconsistency, return the error in a structured JSON with HTTP 400 code. Tests are welcome.

## Contact

If you have any questions, send them directly to dev@cubo.network or open an issue in the repository.
