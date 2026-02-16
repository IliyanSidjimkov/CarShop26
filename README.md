# 🚗 CarShop26

**CarShop26** is a web-based car marketplace application built with **ASP.NET Core MVC**.  
The platform allows users to create accounts, publish car listings, manage their own offers, and save favorite listings.

This project is designed as a layered MVC application following good OOP practices and clean architecture principles.

---

## 🛠️ Technologies

- ASP.NET Core MVC (.NET 6+ / .NET 8)  
- Entity Framework Core  
- Microsoft SQL Server  
- ASP.NET Core Identity (Authentication & Authorization)  
- Razor Views  
- Bootstrap  
- Dependency Injection  

---

## ✨ Features

### 👤 User Accounts
- User registration  
- User login / logout  
- Authentication & authorization  

### 🚘 Car Listings
- Create car listings  
- View all car listings  
- Edit listings (only by the creator)  
- Delete listings (only by the creator)  

### ⭐ Favourites
- Add car listings to Favourites  
- Remove listings from Favourites  
- View all favourite cars  

### 🚙 My Cars
- Shows only listings created by the current user  
- Only the owner can edit or delete listings  
- Other users can only view and add to Favourites  

---

## 👨‍💻 Seeded Data

### 🔐 Default Test User
Email: admin@test.bg
Password: Test123/


- Sample car listings are seeded and associated with this user.

---

## 🧱 Project Architecture & Structure

The project is structured in layers:

- **Data Layer (Entities / Database Models)**  
- **View Models (DTOs / Form Models)**  
- **Views (UI Layer)**  
- **Services Layer (Business Logic)**  
- **Service Interfaces**  
- **Dependency Injection**

---

## ✅ Validation

- **Entity & Form Validation**  
  - Validation attributes for required fields, string length, ranges, etc.

- **Custom Password Validation**  
  - Custom password rules implemented for demonstration purposes.  
  - Password requirements are simplified for the project, but the mechanism for customization is shown.

---

## ⚙️ Installation & Setup

### 1️⃣ Clone the repository
```
git clone https://github.com/your-username/CarShop26.git
```
2️⃣ Configure database connection
In appsettings.json, update the connection string:

```
"DefaultConnection": "Server=localhost\\MSSQLSERVER01;Database=CarShop26;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False;"
```
Change only the server name to match your local SQL Server instance, for example:

localhost\SQLEXPRESS

DESKTOP-12345\SQLEXPRESS

localhost

3️⃣ Apply migrations
Update-Database
4️⃣ Run the application
Start the project from Visual Studio or Rider.

🧭 Navigation
Home

All Cars

Add Car

Favourites

My Cars

Login / Register

📄 License
This project is created for educational purposes.

👨‍💻 Author
CarShop26 – SoftUni, ASP.NET Fundamentals - January 2026 Final Project
Developed by: [Iliyan Sidzhimkov]
