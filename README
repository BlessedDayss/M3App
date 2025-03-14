# M3 Management System

![M3 Management System](https://img.shields.io/badge/M3-Management-blue)
![ASP.NET Core 8.0](https://img.shields.io/badge/ASP.NET%20Core-8.0-brightgreen)
![PostgreSQL Database](https://img.shields.io/badge/PostgreSQL-Database-blue)
![License: MIT](https://img.shields.io/badge/License-MIT-yellow)

## Overview

This version is more structured and easier to read, making it suitable for a GitHub repository.
This version is more structured and easier to read, making it suitable for a GitHub repository.
M3 Management System is an API-driven application built with ASP.NET Core 8.0. It offers comprehensive management of students and teachers with robust features like OData support, Entity Framework Core integration, and PostgreSQL for reliable data storage.

## Features

- **Student Management**: CRUD operations for student records.
- **Teacher Management**: Full management of teacher profiles.
- **RESTful API**: Supports GET, POST, PUT, and DELETE methods.
- **OData Support**: Enables advanced querying capabilities.
- **Swagger Documentation**: Interactive API docs for easy testing and development.
- **PostgreSQL Database**: Reliable and scalable storage.
- **Docker Support**: Containerized deployment for streamlined setups.

## API Documentation

### Endpoints

#### Students

- **GET** `/api/students` – Retrieve all students.
- **GET** `/api/students/{id}` – Retrieve a specific student.
- **POST** `/api/students` – Create a new student.
- **PUT** `/api/students/{id}` – Update an existing student.
- **DELETE** `/api/students/{id}` – Delete a student.

#### Teachers

- **GET** `/api/teachers` – Retrieve all teachers.
- **GET** `/api/teachers/{id}` – Retrieve a specific teacher.
- **POST** `/api/teachers` – Create a new teacher.
- **PUT** `/api/teachers/{id}` – Update an existing teacher.
- **DELETE** `/api/teachers/{id}` – Delete a teacher.

## Technology Stack

- **Framework**: ASP.NET Core 8.0
- **ORM**: Entity Framework Core 8.0
- **Database**: PostgreSQL
- **API Documentation**: Swagger/OpenAPI
- **Serialization**: Newtonsoft.Json
- **Query Support**: OData
- **Containerization**: Docker

## Installation & Setup

### Prerequisites

- .NET 8.0 SDK
- PostgreSQL
- Docker (optional)

### Local Development

1. **Clone the Repository**

   ```bash
   git clone https://github.com/yourusername/M3App.git
   cd M3App
   ```

2. **Configure Database**

   Update the connection string in `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Database=m3management;Username=yourusername;Password=yourpassword"
   }
   ```

3. **Run Migrations**

   ```bash
   dotnet ef database update
   ```

4. **Run the Application**

   ```bash
   dotnet run
   ```

5. **Access Swagger UI**

   Navigate to `http://localhost:5000/swagger`.

### Docker Deployment

1. **Build the Docker Image**
   ```bash
   docker build -t m3app .
   ```

## Testing

Execute tests:

```bash
dotnet test
```

## Database Schema

### Student

- **ID** (Primary Key)
- **Name**
- **Email**
- **Enrollment Date**
- **Additional Fields**

### Teacher

- **ID** (Primary Key)
- **Name**
- **Email**
- **Specialty**
- **Additional Fields**

## Contributing

1. Fork the repository.
2. Create a feature branch:
   ```bash
   git checkout -b feature/amazing-feature
   ```
3. Commit your changes:
   ```bash
   git commit -m "Add an amazing feature"
   ```
4. Push your branch:
   ```bash
   git push origin feature/amazing-feature
   ```
5. Open a Pull Request.

## License

This project is licensed under the MIT License – see the LICENSE file for details.
