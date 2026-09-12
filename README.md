# SavanNah 🛍️

A modern, full-featured E-Commerce web application built with **.NET 10 (ASP.NET Core MVC)** following Clean Layered Architecture principles. **SavanNah** delivers a seamless online shopping experience for customers and a powerful management dashboard for store administrators.

---

## 🚀 Recent Updates & Enhancements

- 🎨 **Savannah Design System & UI Overhaul:** Upgraded user interface with modern styling, brand resources, responsive layouts, and dynamic micro-interactions.
- 💳 **Stripe Payment Gateway Integration:** Seamless checkout experience powered by `Stripe.net` for secure online payments and order processing.
- 🛒 **Dynamic Shopping Cart:** AJAX-powered cart operations (add, remove, quantity update) with real-time total calculations and 7-day persistent sessions.
- 📦 **Admin Order Management & DataTables:** Interactive order administration featuring DataTables integration (search, pagination, sorting) and order status workflow.
- 👥 **Identity & Role Management:** Custom ASP.NET Core Identity implementation featuring role assignments, user management, admin user creation, and access controls.

---

## 🏗️ Architecture & Project Structure

The solution is built using a **Clean N-Tier Layered Architecture** to ensure separation of concerns, testability, and scalability:

```
SavanNah/
├── SavanNah.Presentation/    # ASP.NET Core MVC Presentation Layer (User & Admin Areas, Razor Views, Controllers)
├── SavanNah.Business/        # Business Logic Layer (Managers, Services, Domain Business Logic)
├── SavanNah.DataAccess/      # Data Access Layer (EF Core, AppDbContext, Repositories, EF Migrations)
└── SavanNah.Models/          # Core Domain Layer (Entities, DTOs, ViewModels, ActionRequests)
```

---

## ✨ Features

### 🛒 Customer Experience (User Area)
- **Product Catalog:** Browse products by category and brand with search capabilities and detailed product pages.
- **Dynamic Cart & Checkout:** AJAX-driven quantity updates, item removals, persistent shopping cart sessions, and streamlined multi-step checkout.
- **Stripe Online Payments:** Secure checkout powered by Stripe API with automated order state updates.
- **Order History & Tracking:** View personal order details, track payment statuses, and review order summaries.
- **Account Management:** User registration, secure login, and profile management.

### 🛡️ Store Administration (Admin Area)
- **Admin Dashboard:** Central overview with key metrics and store navigation.
- **Product Management:** Full CRUD operations for products including image management and category/brand associations.
- **Category & Brand Management:** Complete CRUD management for store categories and brands.
- **Order Processing & DataTables:** Interactive order table with DataTables integration (search, pagination, sorting), status updates, and payment details.
- **User & Role Management:** Role management, permission control, admin user creation, and customer account oversight.

---

## 💻 Tech Stack

- **Framework:** .NET 10.0 (ASP.NET Core MVC)
- **Database & ORM:** SQL Server with Entity Framework Core 10.0
- **Authentication & Authorization:** ASP.NET Core Identity (Custom `User` and `Role` models)
- **Payment Processing:** Stripe API (`Stripe.net` v52.4.1)
- **Frontend & UI:** Razor Views, Bootstrap 5, Custom CSS Savannah Design System, JavaScript/jQuery (AJAX), DataTables, Toastr & SweetAlert

---

## ⚙️ Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express or Developer Edition)
- Visual Studio 2022 / VS Code / Rider

### Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Marwan-Farouk/SavanNah.git
   cd SavanNah
   ```

2. **Configure Connection String & Stripe Keys:**
   Open `SavanNah.Presentation/appsettings.Development.json` (or `appsettings.json`) and configure your local SQL Server connection string and Stripe API keys:
   ```json
   {
     "ConnectionStrings": {
       "Savanah": "Server=YOUR_SERVER_NAME;Database=Savanah_DB;Trusted_Connection=True;TrustServerCertificate=True;"
     },
     "Stripe": {
       "SecretKey": "YOUR_STRIPE_SECRET_KEY",
       "Publishablekey": "YOUR_STRIPE_PUBLISHABLE_KEY"
     }
   }
   ```

3. **Apply Database Migrations:**
   Run the following command from the repository root to create the database schema:
   ```bash
   dotnet ef database update --project SavanNah.DataAccess --startup-project SavanNah.Presentation
   ```

4. **Run the Application:**
   ```bash
   dotnet run --project SavanNah.Presentation
   ```
   Open your browser and navigate to `https://localhost:7123` (or the URL displayed in the CLI output).

---

## 🗺️ Roadmap

- [x] Integrate Stripe Payment Gateway
- [x] Modernize UI with Savannah Design System & Branding
- [x] Implement Admin Order Management with DataTables
- [x] Implement Dynamic Shopping Cart with Session Persistence
- [ ] Product Reviews and Rating System
- [ ] Advanced Product Search and Multi-Filter Facets
- [ ] RESTful API endpoints for mobile integration
- [ ] Containerize application with Docker

