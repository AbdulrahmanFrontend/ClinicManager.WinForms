# 🏥 Clinic Manager System (WinForms)

A **clinic management desktop application** built using **C# WinForms** and **SQL Server**, following a clean **layered architecture**.  
The system focuses on real-world clinic workflows such as appointments, patients, doctors, and payments.

---

## 📌 Features

- Doctors and Patients management (CRUD)
- Appointment scheduling and daily appointments tracking
- Appointment status handling (Scheduled, Completed, No Show, etc.)
- Payment processing for completed appointments
- Transaction handling for critical operations
- Advanced filtering and search
- Centralized logging

---

## 🧱 Architecture

The solution follows a **layered architecture**:

Presentation Layer  
↓  
Business Layer  
↓  
Data Access Layer  
↓  
SQL Server Database  

**Responsibilities:**
- Presentation Layer: UI and user interactions
- Business Layer: Business rules and workflows
- Data Access Layer: Database operations using ADO.NET
- Logging Layer: Error and event logging

---

## 🛠️ Technologies Used

| Technology | Purpose |
|---------|---------|
| C# WinForms | Desktop UI |
| ADO.NET | Database access |
| SQL Server | Relational database |
| Git & GitHub | Version control |
| Layered Architecture | Maintainability |

---

## 📥 Getting Started

### Prerequisites
- Visual Studio 2019 or later
- SQL Server (Express or higher)
- Git

### Setup
1. Clone the repository:
```bash
git clone https://github.com/AbdulrahmanFrontend/ClinicManager.WinForms
```
# 🏥 Clinic Manager System (WinForms)

A **clinic management desktop application** built using **C# WinForms** and **SQL Server**, following a clean **layered architecture**.  
The system focuses on real-world clinic workflows such as appointments, patients, doctors, and payments.

---

## 📌 Features

- Doctors and Patients management (CRUD)
- Appointment scheduling and daily appointments tracking
- Appointment status handling (Scheduled, Completed, No Show, etc.)
- Payment processing for completed appointments
- Transaction handling for critical operations
- Advanced filtering and search
- Centralized logging

---

## 🧱 Architecture

The solution follows a **layered architecture**:

Presentation Layer  
↓  
Business Layer  
↓  
Data Access Layer  
↓  
SQL Server Database  

**Responsibilities:**
- Presentation Layer: UI and user interactions
- Business Layer: Business rules and workflows
- Data Access Layer: Database operations using ADO.NET
- Logging Layer: Error and event logging

---

## 🛠️ Technologies Used

| Technology | Purpose |
|---------|---------|
| C# WinForms | Desktop UI |
| ADO.NET | Database access |
| SQL Server | Relational database |
| Git & GitHub | Version control |
| Layered Architecture | Maintainability |

---

## 📥 Getting Started

### Prerequisites
- Visual Studio 2019 or later
- SQL Server (Express or higher)
- Git

### Setup
1. Clone the repository:
```bash
git clone https://github.com/AbdulrahmanFrontend/ClinicManager.WinForms
```
2. Open ClinicManager.slnx in Visual Studio.
3. Restore the database using the provided backup file.
4. Update the connection string in the configuration file.
5. Build and run the application.

---

## 🗄️ Database

The database backup is available in the /Database folder.
- ClinicDB.bak: SQL Server database backup
- README.md: Database structure overview

---

## 📸 Screenshots

| Feature | Preview |
|-------|---------|
| Today Appointments | ![](Screenshots/today-appointments.png) |
| Doctors Management | ![](Screenshots/doctors-management.png) |
| Patients Management | ![](Screenshots/patients-management.png) |
| Appointment Completion | ![](Screenshots/appointment-completion.png) |

---

## 🧭 Future Enhancements (Roadmap)

- Automatic conversion of past uncompleted appointments to No Show
- Reports export (PDF / Excel)
- Role-based authentication
- UI/UX enhancements
- Unit testing for business logic

## 📄 License

This project is intended for educational and demonstration purposes.
