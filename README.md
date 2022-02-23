# Assignment-2-Create-and-Write-Database

Foobar is a Python library for dealing with word pluralization.

# Appendix A: SQL scripts to create database

## Description
Appendix A contains several scripts which can be run to create a database, setup some tables in the databsase, add relationships to the tables, and then populate the tables with data.

## Installation

Install SQL Server Management Studio (SSMS) from the website https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15.


## Usage
Execute the .sql files one by on in SSMS to create the SuperheroDb database, add entries to the database and execute some basic CRUD operations on the database.

# Appendix B: Reading data with SQL Client

## Description
Application which manipulates SQL Server data in Visual Studio using the library SQL Client. 

## Installation
Install Visual Studio 2019.
Open the project in Visual Studio via the .sln file.
Change the Datasource for the ConnectionStringBuillding on line 15 in the ConnectionStringBuilder class.
``
connectionStringBuilder.DataSource = "YourDataSource";
``

## Usage


## License
[MIT](https://choosealicense.com/licenses/mit/)