
# C# Web Form Application with CRUD Operations and User Management

This project demonstrates the development of a C# web form application that implements user login, registration, data management (CRUD), and secure password storage.

## Key Features:
User Management: Login and registration functionality Rijndael encryption/decryption for password security User authentication verification Session management (consider using Session instead of cookies for better security)

## Data Access:
ADO.Net for database connectivity Master-detail tables in SQL Server with primary and foreign key relationships Stored procedures for CRUD operations (Create, Read, Update, Delete)

## Data Binding and Display:
 DataReader, DataSet, and DataTable usage examples (demonstrate scenarios for each)

 ## Front-End:
Html , Css and Core or Plain JavaScript manipulation in view pages for dynamic interactions

# Project Structure:

## Global.asax: 
Configures the application's startup page (Login.aspx)

## Login.aspx: 
Handles Login and Registration functionalities Login form Registration form (with password encryption) User authentication logic Redirect to Dashboard.aspx upon successful login Consider using sessions instead of cookies for improved security.

## Dashboard.aspx:
Displays user information retrieved from database.

## Logout.aspx:
Logout the user and clear the session.

## DalStoreProcedure.cs:
To store the stored procedure call in various function.

## EncryptionDecryptionKey.cs:
Provides the key for encryption and decyption.

## EncryptionDecryptionProvider.cs:
Implements the RijndaelEncDec.

## RijndaelEncDec.cs:
Provides the encyprtion and decyption.

# Technologies Used:
C# ASP.NET Web Forms ADO.Net SQL Server JavaScript

# Prerequisites:
1. Visual Studio (any edition supporting Web Forms development)
2. SQL Server (or compatible database)
3. Configure Database Connection: Update connection strings in web.config to point to your SQL Server instance.
4. Run the Application: Open the project in Visual Studio and start without debugging. The application should launch, directing you to the Login page.




