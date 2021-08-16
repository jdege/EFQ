# EFQ
##Serializable Entity Framework Queries


Serializable Entity Framework Queries

EFQ is a .NET 5.0 library to enable serializing Entity Framework queries.

When we started working with Entity Framework, there were two functionalities we had been using that EF, out of the box, did not support:

- Constructing a query dynmically on a web page and submitting it to a webservice, and
- Storing a query in the database.
- Both of these are pretty simple to do in SQL, and we wanted to be able to do something similar using Entity Framework.

There are four .NET projects, in this solution:

- EFQ - the EFQ library itself
- EFQ.test - an XUnit test suite, running unit tests that do not have any external dependencies.
- EFQ.dbtest - an XUnit test suite, running tests against a local SQLite database.
- EFQ.Web - a aspnet core website, with demonstration pages running against a SqlServer database.


[The Generated Documentation](EFQ/docs/index.md)


© 2021 - Jeffrey C. Dege - MIT License
