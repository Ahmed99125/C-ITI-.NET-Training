ASP.NET Core School Management System
📖 About The Project
This project is a comprehensive, multi-functional web application built with ASP.NET Core MVC. It serves as a management portal for an educational institution, designed to handle core entities such as Departments, Courses, Instructors, and Students.

The application is architected with a clean separation of concerns, leveraging the Repository Pattern to decouple the data access layer from the business logic. It features a robust, role-based authorization system to ensure that users can only access the data and functionalities relevant to their position.

✨ Key Features
Role-Based Access Control: Secure authentication system with four distinct user roles, each with tailored permissions:

Admin: Unrestricted access to create, read, update, and delete all data.

HR: Can manage instructor and student profiles.

Instructor: Can view course details and manage their assigned courses.

Student: Can view the course catalog and their own profile information.

Full CRUD Operations: Comprehensive management capabilities for all core entities.

Efficient Data Handling: Server-side filtering and pagination are implemented on all main list views to ensure high performance, even with large datasets.

Data Integrity: Robust model validation and safe-delete logic (with confirmation modals) to maintain database consistency and prevent accidental data loss.

Clean Architecture: Built using the Repository Pattern, ensuring a scalable and maintainable codebase.

🛠️ Technology Stack
This project was built using a modern, robust technology stack:

Backend: ASP.NET Core MVC (.NET)

Language: C#

Database: Microsoft SQL Server

ORM: Entity Framework Core

Authentication: ASP.NET Core Identity

Frontend: Razor Pages, Bootstrap, HTML, CSS, JavaScript

Architectural Pattern: MVC, Repository Pattern

🚀 Getting Started
To get a local copy up and running, follow these simple steps.

Prerequisites
.NET SDK (check the project's .csproj file for the version)

Microsoft SQL Server (Express or Developer edition)

An IDE like Visual Studio or VS Code

Installation & Setup
Clone the repository:

git clone [YOUR_REPOSITORY_URL]

Configure the database connection:

Open appsettings.json.

Modify the DefaultConnection string to point to your local SQL Server instance.

 "ConnectionStrings": {
   "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=iti_project_db;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
 }

Apply Database Migrations:

Open the Package Manager Console in Visual Studio.

Run the following command to create the database and apply the schema:

Update-Database

Run the application:

Press F5 or click the "Run" button in Visual Studio to start the application. The application will automatically seed the necessary user roles upon startup.

The first user you register will need to be assigned the Admin role to access all features. You may need to do this directly in the AspNetUserRoles table in the database initially.

usage
Once the application is running, you can register new users with different roles. The navigation bar and available actions will automatically adjust based on the role of the logged-in user, providing a tailored and secure experience for everyone.
