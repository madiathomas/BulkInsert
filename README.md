# Recurso.BulkInsertLibrary
BulkInsertLibrary is an open source .NET Standard library for inserting data to a SQL Server database in bulk. Inserting data in bulk is faster
that inserting one by one. It uses SQLBulkCopy in the background. You can pass it a DataTable or a generic List of objects. When you pass it 
a generic list of objects, a datatable is created for you.

This ibrary also downloadable as a Nuget package.

To install it, simply run this nuget command on **Install-Package Recurso.BulkSMS**.
