# 🚀 Simple CRUD Web API (.NET 10)

A lightweight and efficient Web API built with **ASP.NET Core 10** to demonstrate RESTful principles, Entity Framework Core integration, and modern C# development practices.

---

## 📌 1. Project Overview
The primary goal of this project is to manage a **One-to-Many relationship** between **Categories** and **Products**. It serves as a practical implementation of:
* RESTful API Architecture.
* Database management with EF Core.
* Modern C# features (Nullable Reference Types, Async/Sync patterns).

---

## 🛠️ 2. Tech Stack & Dependencies
I intentionally selected the following stack for a robust development experience:
* **Framework:** .NET 10 (ASP.NET Core).
* **ORM:** Entity Framework Core.
* **Database:** SQL Server.
* **Documentation & Testing:** * `Swashbuckle.AspNetCore` (Swagger): Manually configured for a visual testing interface.
    * `Microsoft.EntityFrameworkCore.SqlServer`: For seamless DB connectivity.
    * `Microsoft.EntityFrameworkCore.Tools`: To manage database migrations.

---

## 🏗️ 3. Data Modeling & Architectural Decisions
The system consists of two main entities: **Category** and **Product**.

### Key Decisions:
* **One-to-Many Relationship:** A Category can have multiple Products, while each Product belongs to exactly one Category.
* **Navigation Properties:** Used `ICollection<Product>` with `new List<Product>()` initialization to prevent `NullReferenceException`.
* **Nullable Reference Types:** Applied the Null-forgiving operator (`!`) on required properties to ensure the database schema marks them as `NOT NULL` while maintaining code safety.
* **Data Integrity (Fluent API):** * Configured `DeleteBehavior.Restrict` in `OnModelCreating`.
    * **Why?** To prevent accidental deletion of a Category if it still contains active Products.

---

## ⚙️ 4. The CRUD Logic & Performance
The controllers follow standard REST principles (`GET`, `POST`, `PUT`, `DELETE`).

### Performance Optimization:
* **Asynchronous (Async) GET/PUT:** Used for high-frequency operations to ensure **Scalability**, allowing the server to handle concurrent users without thread locking.
* **Synchronous (Sync) POST/DELETE:** Implemented for atomic, single-record write operations to simplify state management and debugging in this specific CRUD context.
* **Pagination:** Used `.Take(10)` in GET requests to optimize the initial data load.

---

## 🚀 5. How to Run the Project
1.  **Database Setup:** Open *Package Manager Console* and run:
    ```bash
    Update-Database
    ```
2.  **Launch:** Press `F5` in Visual Studio.
3.  **Documentation:** The application will automatically launch **Swagger UI** at `/swagger/index.html`.
4.  **Testing:** Use the "Try it out" feature in Swagger or the provided **Postman Collection** for advanced testing.

---

## 📂 6. Postman Collection
For professional manual testing, I have included a **Postman Collection** JSON file in the `/Postman` folder. It contains pre-configured requests for all endpoints with sample JSON bodies.