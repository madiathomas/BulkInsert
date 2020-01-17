# BulkInsert
**BulkInsert** is an open source .NET Standard library for inserting data to a SQL Server database in bulk. Inserting data in bulk is faster
that inserting one by one. It uses SQLBulkCopy[1] in the background. You can pass it a DataTable[2] or a generic List of objects. When you pass it a generic list of objects, a datatable is created for you. If you don't set DestinationTableName, it uses the name of the object on the generic List.

This library is also downloadable as a Nuget package.

To install it, simply run this nuget command on **Install-Package Recurso.BulkInsertLibrary**.

[1] https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlbulkcopy?view=netstandard-2.1

[2] https://docs.microsoft.com/en-us/dotnet/api/system.data.datatable?view=netstandard-2.1

