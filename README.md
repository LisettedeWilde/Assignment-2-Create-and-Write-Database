# Assignment-2-Create-and-Write-Database

![GitHub repo size](https://img.shields.io/github/repo-size/LisettedeWilde/Assignment-2-Create-and-Write-Database)

[Chinook SQL Script](https://lms.noroff.no/pluginfile.php/184704/mod_assign/introattachment/0/Chinook_SqlServer_AutoIncrementPKs.sql?forcedownload=1)

## Table of Contents

- [General Information](#general-information)
- [Technologies](#technologies)
- [Installation and Usage](#installation-and-usage)
- [Contributors](#contributors)

## General Information

Module Assignment: Data persistence and access

For the first appendix of this assignment we have created a database using SQL. For the second appendix, we created a C# application to access data from a database using a repository pattern.

The C# application uses a variety of 9 different methods which can be used to interact with the database.
The methods can be used for the following:

1. Read all customers from database.
2. Read individual customer by customer id from database.
3. Read customer with matching part of name. 
4. Read page of customers. This method returns limit value of customers, starting from offset value.
5. Create new customer to the database. Add following fields to new customer: first name, last name, country, postal code, phone number and email. 
6. Update existing user in database. Update selected customer's phone number and email address. This method returns updated customer if customer is successifully updated, or null if customer update failed.
7. Read countries with amount of customers from database. This method returns all countries with customers in it, along with amount of customers, in descending order (highest to lowest).
8. Read highest spending customers from database. This method returns highest spending customers in descending order (highest to lowest).
9. Read selected customer's most popular genre. This method returns selected customer's most popular genre. In case of tie, return both of genres.

## Technologies

The project has been made with the following technologies and languages:

- C#

- .NET 5.0

- SQL Server

## Installation and Usage

You will need SQL Server to be connected with SQL Server Management Studio. Afterwards you have to connect with the Chinook server which can be found at the top of this readme. Lasty, don't forget to change the datasource of the  ```connectionstringbuilder```  to connect with the server.

1. Clone the project repository

```sh
git clone https://github.com/LisettedeWilde/Assignment-2-Create-and-Write-Database.git
```

2. Open project with Visual Studio.

3. Navigate to *Program.cs*.

4. Add breakpoint for each *return* statement.

5. Click *Start* icon along with project name in top bar to see returned data.

## Contributors

[Lisette de Wilde (@lisettedewilde)](https://github.com/LisettedeWilde)

[Murat Sahin (@m-sahin)](https://github.com/m-sahin)
