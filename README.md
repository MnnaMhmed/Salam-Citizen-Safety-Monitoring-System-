
# 🛡️ Salam — Safety & Emergency Response API

**Salam** is a safety-focused RESTful API designed to provide users with essential emergency and safety services through a secure and scalable backend system.

The platform supports **emergency reporting, safety devices, notifications, emergency contacts, emergency numbers, user profiles, support, ratings, subscriptions, and payments**, with real-time communication powered by **SignalR**.

The project is built with **ASP.NET Core 8** and follows **Clean Architecture** principles to provide a maintainable, testable, and scalable backend.

---

## 📌 Project Overview

Salam provides a centralized backend for managing safety-related services and user emergency information.

The system allows authenticated users to:

- Register and log in securely.
- Create and manage emergency reports.
- Manage registered safety devices.
- Manage emergency contacts.
- Receive and manage notifications.
- Access emergency numbers and safety information.
- Manage their profile.
- Submit support requests and ratings.
- Browse subscription plans.
- Subscribe to available plans.
- Manage subscription-related payments.

The system also provides administrative capabilities through **role-based authorization**.

---

## 🚀 Main Features

### 🔐 Authentication & Authorization

- User Registration
- User Login
- JWT Bearer Authentication
- Role-Based Authorization
- Protected API endpoints
- Admin-only operations
- User ownership validation

### 🚨 Emergency Reports

- Create emergency reports
- Retrieve reports
- View report history
- Track report status
- Mark reports as resolved

### 📱 Devices Management

- Register safety devices
- View user devices
- Manage registered devices
- Associate devices with authenticated users

### 🔔 Notifications

- Create notifications
- Retrieve user notifications
- Mark notifications as read
- Delete notifications
- Real-time notification delivery using SignalR

### 👥 Emergency Contacts

- Add emergency contacts
- Retrieve emergency contacts
- Delete emergency contacts
- Associate contacts with users

### 📞 Emergency Numbers

- Retrieve emergency numbers
- Access important emergency contact information
- Manage emergency numbers through authorized operations

### 👤 User Profile

- View profile
- Update profile information
- Manage user-related information

### ⭐ Support & Rating

- Submit support requests
- Track support request status
- Submit ratings and comments

### 💳 Plans & Subscriptions

- Retrieve available subscription plans
- Subscribe to a plan
- Manage user subscriptions
- Track subscription status
- Handle subscription duration

### 💰 Payments

- Create payment records
- Associate payments with subscriptions
- Track payment status
- Store transaction information
- Support different payment methods

### 📡 Real-Time Communication

- SignalR integration
- Real-time notifications
- Server-to-client communication
- Reduced dependency on continuous polling

---

# 🏗️ Architecture

Salam follows **Clean Architecture** and is divided into four main layers:

```text
┌─────────────────────────────────────────────┐
│                 Salam API                   │
│                                             │
│ Controllers • SignalR Hubs • Authentication │
│ Authorization • Swagger • DI • Middleware   │
└──────────────────────┬──────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────┐
│             Salam Application               │
│                                             │
│ DTOs • Services • Interfaces • Business     │
│ Logic • Validation                          │
└──────────────────────┬──────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────┐
│               Salam Domain                  │
│                                             │
│ Entities • Domain Interfaces • Contracts    │
└──────────────────────▲──────────────────────┘
                       │
                       │
┌──────────────────────┴──────────────────────┐
│           Salam Infrastructure              │
│                                             │
│ EF Core • DbContext • Repositories          │
│ Unit of Work • Configurations • Database    │
└─────────────────────────────────────────────┘
````

### Salam API

Responsible for:

* Controllers
* HTTP endpoints
* JWT Authentication
* Role-Based Authorization
* SignalR Hubs
* Swagger / OpenAPI
* Dependency Injection
* API configuration

### Salam Application

Responsible for:

* DTOs
* Service Interfaces
* Application Services
* Business Logic
* Application-level validation

### Salam Domain

Contains the core business layer:

* Entities
* Repository Interfaces
* Domain Contracts
* Core abstractions

### Salam Infrastructure

Responsible for external and database-related concerns:

* Entity Framework Core
* DbContext
* Repository Implementations
* Generic Repository
* Unit of Work
* Entity Configurations
* SQL Server integration

---

# 🗄️ Database

Salam uses:

* **Microsoft SQL Server**
* **Entity Framework Core 8**
* **Code First**
* **EF Core Migrations**

### Main Entities

```text
Users
 ├── Devices
 ├── Reports
 ├── Notifications
 ├── EmergencyContacts
 ├── Ratings
 ├── Supports
 ├── Subscriptions
 │      └── Payments
 └── Payments

Plans
 └── Subscriptions

EmergencyNumbers
```

### Main Relationships

| Relationship              | Type        |
| ------------------------- | ----------- |
| Users → Devices           | One-to-Many |
| Users → Reports           | One-to-Many |
| Users → Notifications     | One-to-Many |
| Users → EmergencyContacts | One-to-Many |
| Users → Ratings           | One-to-Many |
| Users → Supports          | One-to-Many |
| Users → Subscriptions     | One-to-Many |
| Plans → Subscriptions     | One-to-Many |
| Subscriptions → Payments  | One-to-Many |
| Users → Payments          | One-to-Many |

### Database ERD

![Salam Database ERD](docs/database/Salam_Database_ERD.png)

> `__EFMigrationsHistory` is an Entity Framework internal table and is not considered part of the application's business domain.

---

# 🔐 Authentication & Authorization

Salam uses **JWT Bearer Authentication** to secure protected API endpoints.

After successful authentication, the client receives a JWT access token.

The token must be included in requests to protected endpoints:

```http
Authorization: Bearer <JWT_TOKEN>
```

## Authentication Flow

```text
Client
   │
   │ Register / Login
   ▼
Salam API
   │
   │ Validate Credentials
   ▼
JWT Token
   │
   │ Authorization: Bearer <Token>
   ▼
Protected Endpoints
```

### Protected Endpoints

Protected endpoints use:

```csharp
[Authorize]
```

Only authenticated users can access them.

### Admin Endpoints

Administrative operations use:

```csharp
[Authorize(Roles = "Admin")]
```

Therefore:

* Anonymous users → Public endpoints only
* Authenticated users → Regular protected endpoints
* Admin users → Regular + Admin endpoints

Registration and Login remain publicly accessible because users must be able to obtain their authentication credentials.

---

# 🔑 Swagger Authorization

The API includes **Swagger / OpenAPI** documentation.

To test protected endpoints:

1. Run the application.
2. Open Swagger.
3. Click the **Authorize 🔒** button.
4. Enter:

```text
Bearer <JWT_TOKEN>
```

5. Click **Authorize**.
6. Execute protected endpoints.

Swagger will automatically include the JWT token in authorized requests.

---

# 📋 API Modules

The API is organized into several functional modules.

| Module             | Controller                   | Description                 |
| ------------------ | ---------------------------- | --------------------------- |
| Authentication     | `AuthController`             | Registration & Login        |
| Users              | `UserController`             | User management             |
| Profile            | `ProfileController`          | User profile management     |
| Reports            | `ReportController`           | Emergency reports & history |
| Devices            | `DeviceController`           | Safety device management    |
| Emergency Contacts | `EmergencyContactController` | User emergency contacts     |
| Emergency Numbers  | `EmergencyNumberController`  | Emergency phone numbers     |
| Notifications      | `NotificationController`     | User notifications          |
| Plans              | `PlanController`             | Subscription plans          |
| Subscriptions      | `SubscriptionController`     | User subscriptions          |
| Payments           | `PaymentController`          | Payment management          |
| Support            | `SupportController`          | Support requests            |
| Rating             | `RatingController`           | User ratings & comments     |

> **Note:** Authentication and authorization requirements depend on the endpoint implementation.

---

# 📡 SignalR

Salam uses **ASP.NET Core SignalR** to provide real-time communication.

SignalR allows the server to push notifications to connected clients without requiring continuous polling.

### Example Flow

```text
                    ┌──────────────┐
                    │    Client    │
                    └──────┬───────┘
                           │
                    SignalR Connection
                           │
                           ▼
                    ┌──────────────┐
                    │  Salam Hub   │
                    └──────┬───────┘
                           │
                           ▼
                    Real-Time Event
                           │
                           ▼
                    ┌──────────────┐
                    │    Client    │
                    │ Notification │
                    └──────────────┘
```

This can be used for real-time notification delivery and other safety-related events supported by the application.

---

# 🗃️ Repository & Unit of Work

Database access is separated from application business logic using the **Repository Pattern** and **Unit of Work Pattern**.

### Generic Repository

Provides reusable data-access operations such as:

* Get
* Get All
* Add
* Update
* Delete

### Unit of Work

Coordinates repository operations and database persistence through a single abstraction.

This separation improves:

* Maintainability
* Testability
* Separation of Concerns
* Code Reusability

---

# 🛡️ Security

The application implements several security practices:

* JWT-based authentication
* Role-based authorization
* Protected endpoints
* Admin-only operations
* User ownership validation
* DTO-based API communication
* Input validation
* Separation of business logic from controllers
* Dependency Injection
* Sensitive configuration protection

### Sensitive Configuration

Sensitive values such as:

* Database connection strings
* JWT secret keys
* Payment credentials
* External service credentials

should not be committed to the repository.

Use environment variables, User Secrets, or another secure configuration provider for local and production environments.

---

# 🧪 API Testing

The API was tested through **Swagger / OpenAPI**.

Testing covers the main application modules:

* Authentication
* Authorization
* Emergency Reports
* Devices
* Notifications
* Emergency Contacts
* Emergency Numbers
* Profile
* Support
* Rating
* Plans
* Subscriptions
* Payments
* SignalR

Protected endpoints were tested using JWT authentication.

Admin endpoints were tested using the appropriate administrator role.

---

# 📸 Project Screenshots

This section provides a visual overview of the Salam backend architecture, project structure, and API documentation.

---

## 🏗️ Architecture & Project Structure

The following screenshots show the different layers and components of the Salam backend project in Visual Studio.

### Salam Infrastructure

![Salam Infrastructure](docs/architecture/Screenshot%202026-08-25%20183533.png)

### Salam Infrastructure & Repositories

![Infrastructure Repositories](docs/architecture/Screenshot%202026-08-25%20183514.png)

### Salam Application

![Salam Application](docs/architecture/Screenshot%202026-08-25%20183459.png)

### Salam Domain

![Salam Domain](docs/architecture/Screenshot%202026-08-25%20183439.png)

### Salam API

![Salam API](docs/architecture/Screenshot%202026-08-25%20183418.png)

### Project Configuration

![Project Configuration](docs/architecture/Screenshot%202026-08-25%20183032.png)

---

## 📚 Swagger / OpenAPI

The following screenshots demonstrate the Salam RESTful API documentation and available endpoints through Swagger / OpenAPI.

### Swagger API Overview

![Swagger API Overview](docs/swagger/Screenshot%202026-08-25%20182935.png)

### Swagger API

![Swagger API](docs/swagger/Screenshot%202026-08-25%20182927.png)

### API Endpoints

![API Endpoints](docs/swagger/Screenshot%202026-08-25%20183024.png)

![API Endpoints](docs/swagger/Screenshot%202026-08-25%20183012.png)

![API Endpoints](docs/swagger/Screenshot%202026-08-25%20183004.png)

![API Endpoints](docs/swagger/Screenshot%202026-08-25%20182958.png)

![API Endpoints](docs/swagger/Screenshot%202026-08-25%20182952.png)

![API Endpoints](docs/swagger/Screenshot%202026-08-25%20182943.png)

---

# ⚙️ Getting Started

## Prerequisites

Make sure the following are installed:

* .NET 8 SDK
* Microsoft SQL Server
* SQL Server Management Studio *(optional)*
* Git

---

## 1. Clone the Repository

```bash
git clone YOUR_GITHUB_REPOSITORY_URL
cd YOUR_PROJECT_DIRECTORY
```

---

## 2. Configure the Database

Configure your SQL Server connection string in the application's local configuration.

For example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING"
  }
}
```

> Do not commit real credentials, passwords, JWT secrets, or payment credentials to GitHub.

---

## 3. Apply EF Core Migrations

Using Package Manager Console:

```powershell
Update-Database
```

Or using the .NET CLI:

```bash
dotnet ef database update
```

---

## 4. Run the Application

```bash
dotnet run
```

---

## 5. Open Swagger

After starting the application, open the Swagger URL displayed by ASP.NET Core.

Example:

```text
https://localhost:<PORT>/swagger
```

---

# 📁 Project Structure

```text
Salam
│
├── Salam API
│   ├── Controllers
│   ├── Hubs
│   ├── Program.cs
│   └── appsettings.json
│
├── Salam Application
│   ├── DTOs
│   ├── Services
│   └── Services_Interfaces
│
├── Salam Domain
│   ├── Entities
│   └── Interfaces
│
├── Salam Infrastructure
│   ├── Database
│   ├── UnitOfWork
│   └── Repositories
│
├── docs
│   ├── database
│   │   └── Salam_Database_ERD.png
│   │
│   ├── architecture
│   │   ├── Screenshot 2026-08-25 183533.png
│   │   ├── Screenshot 2026-08-25 183514.png
│   │   ├── Screenshot 2026-08-25 183459.png
│   │   ├── Screenshot 2026-08-25 183439.png
│   │   ├── Screenshot 2026-08-25 183418.png
│   │   └── Screenshot 2026-08-25 183032.png
│   │
│   └── swagger
│       ├── Screenshot 2026-08-25 183024.png
│       ├── Screenshot 2026-08-25 183012.png
│       ├── Screenshot 2026-08-25 183004.png
│       ├── Screenshot 2026-08-25 182958.png
│       ├── Screenshot 2026-08-25 182952.png
│       ├── Screenshot 2026-08-25 182943.png
│       ├── Screenshot 2026-08-25 182935.png
│       └── Screenshot 2026-08-25 182927.png
│
├── .gitignore
├── README.md
└── ...
```

---

# 🛠️ Technologies & Tools

| Technology              | Purpose                     |
| ----------------------- | --------------------------- |
| C#                      | Programming Language        |
| ASP.NET Core 8          | Web API Framework           |
| Entity Framework Core 8 | ORM                         |
| SQL Server              | Database                    |
| LINQ                    | Data Querying               |
| JWT                     | Authentication              |
| SignalR                 | Real-Time Communication     |
| Swagger / OpenAPI       | API Documentation & Testing |
| Clean Architecture      | Application Architecture    |
| Dependency Injection    | Dependency Management       |
| DTOs                    | API Data Transfer           |
| Generic Repository      | Data Access Abstraction     |
| Unit of Work            | Repository Coordination     |

---

# 📌 Project Status

### Current Status: Backend Core Completed & Tested

The core backend functionality has been implemented and tested through Swagger.

### Implemented Features

* ✅ Authentication & Authorization
* ✅ JWT Authentication
* ✅ Role-Based Authorization
* ✅ Database Integration
* ✅ Emergency Reports
* ✅ Devices Management
* ✅ Notifications
* ✅ SignalR Integration
* ✅ Emergency Contacts
* ✅ Emergency Numbers
* ✅ Profile Management
* ✅ Support
* ✅ Rating
* ✅ Plans
* ✅ Subscriptions
* ✅ Payments
* ✅ Swagger / OpenAPI
* ✅ EF Core Migrations
* ✅ Clean Architecture
* ✅ Repository & Unit of Work

---

# 🔮 Future Improvements

Possible future enhancements include:

* Mobile application integration
* Advanced emergency alert workflows
* Location-based emergency services
* Push notifications
* Advanced admin dashboard
* Payment gateway integration
* Enhanced reporting and analytics
* Automated unit and integration tests
* Production deployment
* Docker containerization
* CI/CD pipeline
* Centralized logging and monitoring
* API rate limiting
* Refresh Token implementation
* API versioning

---

# 👩‍💻 Author

**Menna Mohamed**

.NET Backend Developer

### Technical Focus

* C#
* ASP.NET Core
* RESTful APIs
* SQL Server
* Entity Framework Core
* Clean Architecture
* LINQ
* JWT Authentication
* SignalR
* Backend Development

---

# 📄 License

This project is currently intended for educational and portfolio purposes.

If the project is released under a specific open-source license, add the appropriate license information here.

````


