# Inventory Management System

A professional web-based **Inventory Management System** built with **ASP.NET Core MVC, Entity Framework Core, SQL Server, and ASP.NET Core Identity**.

The system provides a centralized platform for managing products, categories, suppliers, inventory transactions, users, roles, and inventory analytics through a responsive and user-friendly dashboard.

---

## 📌 Project Overview

The Inventory Management System is designed to simplify inventory operations and provide better control over stock levels, suppliers, products, and transactions.

The application follows a layered architecture using:

```text
Controller
    ↓
Service
    ↓
Repository
    ↓
Entity Framework Core
    ↓
SQL Server
```

The system also uses **ASP.NET Core Identity** for authentication, role management, and authorization.

---

## ✨ Features

### 📦 Product Management

* Create products
* Edit products
* Delete products using soft deletion
* View products
* Assign products to categories
* SKU management
* Purchase price management
* Selling price management
* Current stock tracking
* Minimum stock level
* Product validation
* Duplicate SKU prevention

---

### 🏷️ Category Management

* Create categories
* Edit categories
* Soft delete categories
* View categories
* Duplicate category name prevention
* Category descriptions
* Validation and error messages

---

### 🚚 Supplier Management

* Create suppliers
* Edit suppliers
* Soft delete suppliers
* View suppliers
* Supplier address and city management
* Product-supplier relationships

---

### 🔄 Inventory Transactions

The system supports multiple inventory transaction types:

* Purchase
* Sale
* Return
* Adjustment Increase
* Adjustment Decrease

Transactions are treated as **historical records**.

Instead of modifying or deleting historical transactions, corrections can be represented using appropriate adjustment or return transactions.

Each transaction contains:

* Product
* Quantity
* Transaction Type
* Date
* Optional Supplier

---

## 📊 Dashboard

The dashboard provides an overview of the inventory system through multiple analytical sections.

### Key Performance Indicators

* Total Products
* Total Suppliers
* Total Categories
* Total Stock Value

### Analytics

* Transactions Over Time
* Stock Status
* Top Moving Products
* Top Suppliers
* Low Stock Products
* Recent Transactions
* Products by Category

The dashboard is designed to provide a quick overview of inventory activity and stock health.

---

# 🔐 Authentication & Authorization

The application uses **ASP.NET Core Identity** for authentication and authorization.

Users can log in and log out securely, while access to system features is controlled using roles.

## User Roles

### SuperAdmin

Full access to the system.

Permissions include:

* Dashboard
* Products
* Categories
* Suppliers
* Inventory Transactions
* Reports
* User Management
* Role management
* Create/Edit/Delete operations where applicable

---

### InventoryManager

Responsible for day-to-day inventory operations.

Permissions include:

* Dashboard
* View Products
* Create/Edit Products
* Categories
* Suppliers
* Inventory Transactions
* Reports
* Export Reports

Cannot manage system users or roles.

---

### Viewer

Read-only access.

Permissions include:

* Dashboard
* View Products
* View Categories
* View Suppliers
* View Inventory Transactions
* View Reports

Viewers cannot modify inventory data.

---

## 👥 User Management

SuperAdmins can manage system users.

Available operations:

* View users
* Create users
* Edit users
* Change user roles
* Disable users
* Enable users

Users are **disabled using ASP.NET Identity lockout functionality** rather than being physically deleted from the database.

---

# 🏗️ Architecture

The application follows a layered architecture to separate responsibilities.

```text
                    ┌─────────────────────┐
                    │       Browser       │
                    └──────────┬──────────┘
                               │
                               ▼
                    ┌─────────────────────┐
                    │     Controllers     │
                    └──────────┬──────────┘
                               │
                               ▼
                    ┌─────────────────────┐
                    │      Services       │
                    │   Business Logic    │
                    └──────────┬──────────┘
                               │
                               ▼
                    ┌─────────────────────┐
                    │    Repositories     │
                    │   Data Access       │
                    └──────────┬──────────┘
                               │
                               ▼
                    ┌─────────────────────┐
                    │ Entity Framework    │
                    │       Core          │
                    └──────────┬──────────┘
                               │
                               ▼
                    ┌─────────────────────┐
                    │     SQL Server      │
                    └─────────────────────┘
```

### Controllers

Responsible for:

* Handling HTTP requests
* Authorization
* Model binding
* Calling application services
* Returning Views

### Services

Responsible for:

* Business logic
* Validation rules
* Duplicate checks
* User management operations
* Coordinating application operations

### Repositories

Responsible for:

* Database queries
* Data retrieval
* Data persistence

### Entity Framework Core

Provides ORM functionality between the application and SQL Server.

---

# 🗄️ Main Entities

The system contains the following main entities:

```text
Category
   │
   └── Products
          │
          ├── Product Suppliers
          │
          └── Inventory Transactions
                         │
                         └── Supplier
```

### Category

Stores product categories.

### Product

Stores product information including:

* Name
* Description
* SKU
* Purchase Price
* Selling Price
* Current Stock
* Minimum Stock
* Category

### Supplier

Stores supplier information.

### ProductSuppliers

Represents the relationship between products and suppliers.

### InventoryTransaction

Stores inventory movements.

### ApplicationUser

Extends ASP.NET Core Identity user with additional user information such as:

* Full Name

---

# 🗑️ Soft Delete

The system uses **soft deletion** for entities such as:

* Products
* Categories
* Suppliers

Instead of permanently removing records from the database, the system marks them as deleted.

Entity Framework Core global query filters ensure that deleted records are automatically excluded from normal queries.

For example:

```csharp
modelBuilder.Entity<Product>()
    .HasQueryFilter(p => !p.IsDeleted);
```

This approach helps preserve historical data and relationships.

---

# 🛡️ Validation & Error Handling

The application includes both client-side and server-side validation.

Examples include:

* Required fields
* String length validation
* Email validation
* Password validation
* Password confirmation
* Numeric range validation
* Duplicate category detection
* Duplicate SKU detection
* Invalid inventory transaction data

Validation errors are displayed directly in the UI so users can understand and correct invalid input.

---

# 🎨 User Interface

The application uses a modern responsive administrative interface.

The UI includes:

* Responsive sidebar navigation
* Dashboard cards
* Responsive tables
* Forms
* Validation messages
* Status indicators
* Interactive buttons
* Hover states
* Responsive layouts
* Professional inventory-focused visual design

The visual design uses a calm Slate/Navy color palette with subtle status colors for success, warning, and danger states.

---

# 🛠️ Technologies Used

## Backend

* C#
* ASP.NET Core MVC
* .NET 8
* Entity Framework Core 8
* ASP.NET Core Identity

## Database

* Microsoft SQL Server

## Frontend

* Razor Views
* HTML5
* CSS3
* Bootstrap 5
* JavaScript
* Bootstrap Icons

## Architecture & Development

* MVC Architecture
* Repository Pattern
* Service Layer
* Dependency Injection
* Entity Framework Core
* Identity-based Authentication & Authorization
* Soft Delete
* Data Validation

---

# 📁 Project Structure

```text
Inventory_Managment_System_ASPMVC
│
├── Controllers
│   ├── AccountController.cs
│   ├── CategoryController.cs
│   ├── DashboardController.cs
│   ├── HomeController.cs
│   ├── InventoryTransactionController.cs
│   ├── ProductController.cs
│   ├── SupplierController.cs
│   └── UserManagementController.cs
│
├── Models
│   ├── ApplicationContext.cs
│   ├── ApplicationUser.cs
│   ├── Category.cs
│   ├── Product.cs
│   ├── Supplier.cs
│   ├── ProductSuppliers.cs
│   └── InventoryTransaction.cs
│
├── ViewModel
│   ├── Product ViewModels
│   ├── User ViewModels
│   ├── Login ViewModel
│   └── Other ViewModels
│
├── Repositories
│   ├── CategoryRepository.cs
│   ├── ProductRepository.cs
│   ├── SupplierRepository.cs
│   ├── InventoryTransactionRepository.cs
│   └── DashboardRepository.cs
│
├── Services
│   ├── CategoryService.cs
│   ├── ProductService.cs
│   ├── SupplierService.cs
│   ├── InventoryTransactionService.cs
│   ├── DashboardService.cs
│   └── UserManagementService.cs
│
├── Views
│   ├── Account
│   ├── Category
│   ├── Dashboard
│   ├── Home
│   ├── InventoryTransaction
│   ├── Product
│   ├── Supplier
│   └── UserManagement
│
├── Data
│   └── IdentitySeeder.cs
│
└── wwwroot
    ├── css
    ├── js
    └── images
```

---

# 🚀 Getting Started

## Prerequisites

Make sure the following are installed:

* .NET 8 SDK
* SQL Server
* Visual Studio 2022 or another compatible IDE
* Git

---

## 1. Clone the Repository

```bash
git clone https://github.com/Omar22-atef/Inventory_Managment_System_ASPMVC
```

Navigate to the project:

```bash
cd Inventory_Managment_System_ASPMVC
```

---

## 2. Configure the Database

Open:

```text
appsettings.json
```

Update the connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_SQL_SERVER_CONNECTION_STRING"
  }
}
```

Use your local SQL Server configuration.

---

## 3. Apply Database Migrations

Run:

```powershell
Update-Database
```

Or using the .NET CLI:

```bash
dotnet ef database update
```

---

## 4. Run the Application

Using Visual Studio:

```text
F5
```

or:

```bash
dotnet run
```

---

# 👤 Default Admin Account

The application seeds a default SuperAdmin account when the application starts.

```text
Email: admin@inventory.com
Password: Admin@123
Role: SuperAdmin
```

> For production environments, replace the default credentials with secure credentials.

---

# 🔑 Authorization Overview

| Feature             | SuperAdmin | InventoryManager | Viewer |
| ------------------- | :--------: | :--------------: | :----: |
| Dashboard           |      ✅     |         ✅        |    ✅   |
| View Products       |      ✅     |         ✅        |    ✅   |
| Create Products     |      ✅     |         ✅        |    ❌   |
| Edit Products       |      ✅     |         ✅        |    ❌   |
| View Categories     |      ✅     |         ✅        |    ✅   |
| Manage Categories   |      ✅     |         ✅        |    ❌   |
| View Suppliers      |      ✅     |         ✅        |    ✅   |
| Manage Suppliers    |      ✅     |         ✅        |    ❌   |
| View Transactions   |      ✅     |         ✅        |    ✅   |
| Create Transactions |      ✅     |         ✅        |    ❌   |
| View Reports        |      ✅     |         ✅        |    ✅   |
| Export Reports      |      ✅     |         ✅        |    ❌   |
| User Management     |      ✅     |         ❌        |    ❌   |

---

# 📈 Future Improvements

Potential future improvements include:

* Advanced reporting and filtering
* Exporting reports to additional formats
* Barcode scanning
* Purchase order management
* Stock notifications
* Email notifications
* Audit logs
* Advanced inventory forecasting
* API integration
* Automated testing
* Cloud deployment

---

# 🎯 Learning Objectives

This project was developed to gain practical experience with:

* ASP.NET Core MVC
* C# backend development
* Entity Framework Core
* SQL Server
* Repository Pattern
* Service Layer Architecture
* Dependency Injection
* Authentication
* Authorization
* Role-Based Access Control
* Database relationships
* CRUD operations
* Soft deletion
* Data validation
* Dashboard development
* Responsive frontend development

---

# 👨‍💻 Author

**Omar Atef**

Computer Science Student
Software Development

---

## 📄 License

This project is intended for educational and portfolio purposes.
