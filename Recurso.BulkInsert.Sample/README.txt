Run CreatePeopleDatabase.sql script to create database required for this sample.

The more records you want to bulk insert, the more BulkInsert is faster than individual inserting using stored procedure.

Spreadsheet contains 10,000 records.I am using 1000 records for this demo.

The more records you use, the more BulkInsert is noticeable faster

Adding more data only adds few milliseconds to bulk insert but way more for individual inserts

Difference between stored procedure and bulk insert was 15 seconds for 1000 records

For 10, 000 records, difference was too big.For bulk insert, it was just 2 seconds

Individual inserts took more than 149 seconds for 10,000 records