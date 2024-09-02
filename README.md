# PhoneBook Application Architecture Overview

## Introduction

The PhoneBook application is a console-based contact management system designed to handle basic operations like viewing, adding, editing, and deleting contacts. Additionally, it supports sending emails to contacts. The application leverages a modular architecture, separating concerns into distinct layers such as user interface, business logic, data access, and service management. This document provides an overview of the main components and their interactions within the system.

## High-Level Architecture

The PhoneBook application is structured into several primary modules:

1. **Model**: Defines the data structure of a contact.
2. **Menu**: Manages user interactions and command execution based on user input.
3. **Commands**: Contains specific actions that can be executed, such as adding or editing a contact.
4. **Handlers**: Implements the logic for handling specific tasks like updating or deleting contacts.
5. **Services**: Provides auxiliary functionalities such as email sending and prompt handling.
6. **Repository**: Manages data persistence and retrieval operations.
7. **Database**: Configures and manages the database connection and context.
8. **Email**: Handles configuration and operations related to email functionalities.
9. **Strategies**: Implements different strategies for editing contact properties.
10. **Migrations**: Manages database migrations for maintaining the database schema.

## Diagram
![alt text](https://github.com/eddyfadeev/DrinksInfo/blob/master/PhoneBook_diagram.png?raw=true)

## Key Components

### Model
- **Contact.cs**: Represents a contact entity with properties like `FirstName`, `LastName`, `PhoneNumber`, `Email`, and `Group`.

### Menu
- **MenuEntries.cs**: Generates dynamic menu entries based on enums.
- **MenuCommandsFactory.cs**: Factory pattern implementation to create commands based on menu selections.
- **Factory/Initializers**: Contains initializers for different menus which map menu options to corresponding commands.

### Commands
- **MainMenuCommands**: Commands available in the main menu, such as viewing all contacts or managing contacts.
- **ManageMenuCommands**: Commands for managing contacts, including add, edit, and delete operations.

### Handlers
- **MenuHandler.cs**: Handles the operation of displaying and executing menu commands.
- **ContactHandlers**: Includes specific handlers like `ContactAdder`, `ContactUpdater`, `ContactDeleter`, and `ContactSelector` for operations on contacts.
- **EmailSender.cs**: Implements the functionality to send emails to contacts.

### Services
- **ValidationService.cs**: Provides methods for validating email addresses and phone numbers.
- **PromptService.cs**: Handles user prompts and input validation.
- **ContactTableConstructor.cs**: Constructs a table view for displaying contact information.
- **HelperService.cs**: Provides common utility functions like prompting the user to press any key to continue.

### Repository
- **ContactRepository.cs**: Implements the repository pattern for managing contact entities in the database.

### Database
- **DatabaseManager.cs**: Manages the database connection.
- **ContactContext.cs**: EF Core database context for the PhoneBook application.

### Email
- **EmailManager.cs**: Manages email configurations and creates instances of `SmtpClient` for sending emails.

### Strategies
- **EditStrategies**: Contains strategies for editing different fields of a contact, such as `FirstNameEditStrategy`, `LastNameEditStrategy`, etc.

### Migrations
- **InitialCreate.cs**: EF Core migration for creating the initial database schema.

## Architectural Invariants

- **Separation of Concerns**: Each module in the system is responsible for a specific aspect of the application's functionality, ensuring that changes in one module have minimal impact on others.
- **Dependency Injection**: The application heavily utilizes dependency injection for managing dependencies, which is centralized in the `DependenciesConfigurator.cs`.
- **No Circular Dependencies**: Modules are structured to avoid circular dependencies, ensuring a unidirectional flow of dependencies which simplifies maintenance and scalability.

## Conclusion

The architecture of the PhoneBook application is designed to be modular and scalable, with clear separation of concerns and robust dependency management. This structure not only facilitates easier maintenance and enhancement of the application but also promotes reusability and testability of components.
