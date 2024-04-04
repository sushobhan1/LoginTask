C# Web Form Application with CRUD Operations and User Management

This project demonstrates the development of a C# web form application that implements user login, registration, data management (CRUD), and secure password storage.

Key Features:

User Management:
Login and registration functionality
Rijndael encryption/decryption for password security
User authentication verification
Session management (consider using Session instead of cookies for better security)
Data Access:
ADO.Net for database connectivity
Master-detail tables in SQL Server with primary and foreign key relationships
Stored procedures for CRUD operations (Create, Read, Update, Delete)
Data Binding and Display:
DataReader, DataSet, and DataTable usage examples (demonstrate scenarios for each)
Front-End:
Core or Plain JavaScript manipulation in view pages for dynamic interactions
Project Structure:

Global.asax: Configures the application's startup page (Login.aspx)
Login.aspx: Handles Login and Registration functionalities
Login form
Registration form (with password encryption)
User authentication logic
Redirect to Dashboard.aspx upon successful login
Consider using sessions instead of cookies for improved security
Dashboard.aspx: Displays user information retrieved from database
Retrieves user info based on session data (if using sessions)
CRUD operations (demonstrate DataReader, DataSet, and DataTable in different scenarios)
Models: Classes representing your database entities (optional)
Data Access Layer (DAL): Contains stored procedures and database interaction logic (optional)
Technologies Used:

C#
ASP.NET Web Forms
ADO.Net
SQL Server
JavaScript
Getting Started:

Prerequisites:
Visual Studio (any edition supporting Web Forms development)
SQL Server (or compatible database)
Clone or Download the Project: Obtain the project files.
Configure Database Connection: Update connection strings in web.config to point to your SQL Server instance.
Run the Application: Open the project in Visual Studio and start without debugging. The application should launch, directing you to the Login page.
