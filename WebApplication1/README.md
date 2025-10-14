Enterprise-Grade School Management System - ASP.NET Core MVC
📖 About The Project
This project is an enterprise-level web application engineered with ASP.NET Core MVC. It provides a robust, secure, and scalable platform for managing the core operations of an educational institution. The system is built upon an N-tier architecture, emphasizing a clean separation of concerns to enhance maintainability and testability.

At its core, the application leverages the Repository Pattern to abstract the data access layer, promoting SOLID principles and decoupling the business logic from the underlying data store (Entity Framework Core).

✨ Technical Implementation
Secure Role-Based Authorization via ASP.NET Core Identity: The application implements a granular, role-based security model with four distinct roles (Admin, HR, Instructor, Student). Authorization attributes ([Authorize(Roles = "...")]) are used to protect controller actions, ensuring users can only perform operations permitted for their role.

Decoupled & Testable Architecture: The use of the Repository Pattern with Dependency Injection allows for a loosely coupled architecture. Interfaces (IRepository, IStudentRepository, etc.) define the contracts for data operations, and their concrete implementations are injected into the controllers at runtime.

Optimized Data Retrieval with Server-Side Operations: To ensure high performance with large datasets, all Index views implement server-side filtering and pagination. LINQ queries are dynamically built based on user input, and Entity Framework Core translates these into efficient SQL queries, minimizing the data transferred from the database.

Data Integrity and Concurrency Control: The application enforces data integrity through a combination of model-level validation using Data Annotations, custom validation logic (IValidatableObject), and robust exception handling. The delete functionality includes confirmation modals and try-catch blocks to gracefully handle potential DbUpdateException errors, preventing data corruption.

Database Schema Management with EF Core Migrations: The entire database schema is managed through code-first migrations. The ApplicationDbContext defines the entity relationships, including composite keys for many-to-many join tables, and migrations are used to apply changes to the database in a controlled and versioned manner.

🛠️ Technology Stack
Backend Framework: ASP.NET Core MVC

Primary Language: C#

Database: Microsoft SQL Server

ORM: Entity Framework Core

Authentication & Authorization: ASP.NET Core Identity

Architectural Patterns: MVC, Repository Pattern, Dependency Injection

Frontend: Razor Pages, Bootstrap, HTML/CSS, JavaScript

🚀 Getting Started
To get a local copy up and running, follow these simple steps.

Prerequisites
.NET SDK

Microsoft SQL Server (Express or Developer edition)

An IDE like Visual Studio or VS Code

Installation & Setup
Clone the repository:

git clone [YOUR_REPOSITORY_URL]

Configure appsettings.json:

Update the DefaultConnection string with your local SQL Server credentials.

Apply EF Core Migrations:

Open the Package Manager Console in Visual Studio.

Run Update-Database to generate the schema.

Run the application:

Press F5 in Visual Studio. The application will seed the user roles on the first run. The first registered user should be manually assigned the 'Admin' role directly in the database for full initial access.

📝 Usage
Once running, you can register users with different roles. The application's UI and available actions in the navigation bar will dynamically adapt based on the logged-in user's role, providing a secure and context-aware experience.
