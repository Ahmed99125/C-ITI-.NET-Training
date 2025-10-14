# Enterprise-Grade School Management System - ASP.NET Core MVC

## 📖 About The Project

This project is an enterprise-level School Management System, engineered using **ASP.NET Core MVC**. It delivers a robust, secure, and scalable platform to manage the core operations of educational institutions. The application is designed for extensibility, maintainability, and high performance, making use of modern software architecture principles and industry best practices.

At its core, the system employs the **Repository Pattern** and **Dependency Injection** to ensure a clean separation of concerns, making the codebase easily testable and adaptable to future requirements. The data access layer is abstracted, and the business logic is decoupled from underlying data sources (such as Entity Framework Core).

---

## ✨ Features & Technical Implementation

- **Role-Based Authorization**:  
  Secure, granular access control powered by **ASP.NET Core Identity** with four distinct roles:
  - Admin
  - HR
  - Instructor
  - Student  
  Authorization is enforced via role attributes and policies at both controller and action levels.

- **Decoupled, Testable Architecture**:  
  The solution uses interfaces (`IRepository`, `IStudentRepository`, etc.) and dependency injection, supporting unit testing and code reusability.

- **Optimized Data Retrieval**:  
  All Index views utilize server-side filtering, sorting, and pagination. LINQ queries are dynamically built to efficiently handle large datasets.

- **Data Integrity & Concurrency Control**:  
  Model-level validation (Data Annotations), custom validation logic (`IValidatableObject`), and optimistic concurrency with RowVersion columns are used to ensure data reliability and integrity.

- **Database Schema Management**:  
  Database schema is managed via **EF Core Migrations**. `ApplicationDbContext` configures entity relationships, including composite keys and navigation properties.

---

## 🛠️ Technology Stack

- **Backend Framework:** ASP.NET Core MVC
- **Primary Language:** C#
- **Database:** Microsoft SQL Server
- **ORM:** Entity Framework Core
- **Authentication & Authorization:** ASP.NET Core Identity
- **Architectural Patterns:** MVC, Repository Pattern, Dependency Injection
- **Frontend:** Razor Pages, Bootstrap, HTML/CSS, JavaScript

---

## 🚀 Getting Started

To run this project locally, follow these steps:

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express or Developer)
- [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation & Setup

1. **Clone the repository:**

    ```bash
    git clone https://github.com/Ahmed99125/C-ITI-.NET-Training.git
    cd C-ITI-.NET-Training/WebApplication1
    ```

2. **Configure `appsettings.json`:**

    - Update the `DefaultConnection` string with your local SQL Server credentials.

3. **Apply EF Core Migrations:**

    - Open the **Package Manager Console** in Visual Studio.
    - Run:

      ```bash
      Update-Database
      ```

    - This will create and seed the database.

4. **Run the application:**

    - Press **F5** in Visual Studio or use `dotnet run`.
    - On first run, user roles will be seeded.
    - The first registered user must be manually assigned the `Admin` role directly in the database for full initial access.

---

## 📝 Usage

- Register new users with different roles.
- The application's UI and navigation options will dynamically adapt based on the logged-in user's role, ensuring a secure and role-appropriate experience.
- Admins can manage all aspects of the system, while HR, Instructor, and Student roles have tailored access.

---

## 🤝 Contributing

Contributions are welcome! Please fork the repository, create a new branch for your feature or bugfix, and submit a pull request.

---

## 📄 License

This project is distributed under the MIT License. See `LICENSE` for more information.

---

## 📬 Contact

For questions or suggestions, open an issue or contact [Ahmed99125](https://github.com/Ahmed99125) on GitHub.
