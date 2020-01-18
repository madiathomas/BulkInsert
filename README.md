# BulkInsert Library
Let's admit it, inserting bulk data row by row is painfully slow and chokes database servers. This library helps you to insert bulk data faster. You simply pass it a generic list of an object which mirrors the database table, and it will do the rest. If you already have your data in a **DataTable**, you can pass it and it will save your data even faster. Check out the sample on how to use it. It uses **SQLBulkCopy**[2] in the background. **BulkInsert** is a free and open source .NET Standard library for inserting data to a SQL Server database in bulk. Inserting data in bulk is faster
that inserting one by one. It uses **SQLBulkCopy**[1] in the background. You can pass it a **DataTable**[2] or a generic List of objects. When you pass it a generic list of objects, a datatable is created for you. If you don't set DestinationTableName, it uses the name of the object on the generic List.

This library is also downloadable as a Nuget package.

To install it, simply run this nuget command on **Install-Package Recurso.BulkInsert**.

[1] https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlbulkcopy?view=netstandard-2.1

[2] https://docs.microsoft.com/en-us/dotnet/api/system.data.datatable?view=netstandard-2.1

