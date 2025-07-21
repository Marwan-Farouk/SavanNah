# SavanNah 🛍️

A modern, full-featured E-commerce Website built with .NET Core. SavanNah provides a robust and scalable platform for online retail, featuring a clean user interface for customers and a powerful administrative dashboard for store managers.

## About The Project

SavanNah is a showcase of modern web development practices using the .NET ecosystem. The project is built using a clean, layered architecture to ensure separation of concerns, maintainability, and scalability. It aims to provide a seamless shopping experience for users and an intuitive management system for administrators.

This project serves as a practical example of building a real-world application with `ASP.NET Core` for the backend logic, `Entity Framework Core` for data access, and `ASP.NET Core Identity` for secure user management.

### Key Features

**For Customers:**
* **Product Catalog:** Browse products by category, search with filters, and view detailed product pages.
* **Shopping Cart:** Add/remove items and update quantities dynamically.
* **User Authentication:** Secure registration and login for a personalized experience.
* **Order Management:** View order history and track order status.
* **Responsive Design:** A clean and modern UI that works on all devices, from desktops to mobile phones.
* **Secure Checkout Process:** A straightforward, multi-step checkout process.

**For Administrators:**
* **Admin Dashboard:** An overview of sales, new orders, and key metrics.
* **Product Management:** Full CRUD (Create, Read, Update, Delete) operations for products.
* **Category Management:** Organize products into categories and subcategories.
* **Order Processing:** View and manage customer orders.
* **User Management:** View and manage registered customer accounts.

---

## Technology Stack

This project is built with a modern set of technologies:

* **Backend:**
    * **.NET 8 (or 7/6):** The core framework for building the application.
    * **ASP.NET Core MVC:** For building the web application following the Model-View-Controller pattern.
    * **Entity Framework Core:** As the Object-Relational Mapper (ORM) to interact with the database.
    * **ASP.NET Core Identity:** For handling user authentication and authorization.
* **Database:**
    * **SQL Server:** The primary database for storing all application data.
    * (Can be configured to work with other databases like `PostgreSQL` or `SQLite`).
* **Frontend:**
    * **Razor Pages/Views:** For server-side rendering of HTML.
    * **Bootstrap 5:** For a responsive and mobile-first layout.
    * **JavaScript & jQuery:** For client-side interactivity.

---

## Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download) (Version 8.0 or later recommended)
* [Visual Studio 2022](https://visualstudio.microsoft.com/) or another code editor like [VS Code](https://code.visualstudio.com/)
* [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or another SQL Server instance.

### Installation

1.  **Clone the repository**
    ```sh
    git clone [https://github.com/Marwan-Farouk/SavanNah.git](https://github.com/Marwan-Farouk/SavanNah.git)
    ```
2.  **Navigate to the project directory**
    ```sh
    cd SavanNah
    ```
3.  **Configure Database Connection**
    * Open `appsettings.json` in the main web project folder.
    * Update the `ConnectionStrings` value to point to your local SQL Server instance.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=SavanNahDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
    }
    ```
4.  **Apply Database Migrations**
    * Open a terminal in the root of the web project.
    * Run the following command to create the database and apply the schema.
    ```sh
    dotnet ef database update
    ```
5.  **Run the application**
    * You can run the project from Visual Studio by pressing `F5` or by using the .NET CLI:
    ```sh
    dotnet run
    ```
6.  **Navigate to the site**
    * Open your browser and go to `https://localhost:7123` or `http://localhost:5123` (the port may vary; check the console output).

---

## Future Enhancements (Roadmap)

* [ ] Integrate a payment gateway (e.g., Stripe, PayPal).
* [ ] Implement a product review and rating system.
* [ ] Add more advanced product search and filtering capabilities.
* [ ] Develop a RESTful API for potential mobile client consumption.
* [ ] Containerize the application using Docker.

---
