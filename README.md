# E-Commerce REST API

A scalable and secure E-Commerce REST API built using ASP.NET Core and SQL Server following Clean Architecture principles.

---

## Features

- User Authentication & Authorization using JWT
- Product Management
- Orders Management
- Basket/Cart Functionality
- Address Management
- Pagination, Filtering, and Sorting
- Entity Framework Core Integration
- SQL Server Database
- Redis Caching
- Swagger API Documentation
- Global Exception Handling
- Clean Architecture & Repository Pattern

---

## Technologies Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- Redis
- JWT Authentication
- Swagger / OpenAPI
- LINQ
- Repository Pattern
- Unit Of Work Pattern

---

## Project Structure

```bash
E-Commerce
│
├── E-Commerce.web
├── E-Commerce.Service
├── E-Commerce.Infrastructure
├── E-Commerce.Domain
├── E-Commerce.Presistence
```

---

## API Endpoints

### Authentication
- Register User
- Login User
- Check Email Availability

### Products
- Get All Products
- Get Product By Id
- Get Product Brands
- Get Product Types

### Orders
- Create Order
- Get Orders
- Get Order By Id
- Delivery Methods

### Basket
- Create Basket
- Get Basket
- Delete Basket

### Users
- Get Current User
- Get User Address
- Update Address

---

## Authentication

This API uses JWT Bearer Authentication.

Example:

```bash
Bearer YOUR_TOKEN_HERE
```



## Future Improvements

- Payment Gateway Integration
- Admin Dashboard
- Docker Support
- Refresh Tokens
- Unit Testing
- CI/CD Pipeline

---

## Author

### Abdallah Amin

GitHub:
https://github.com/abdoamen040466-dev
