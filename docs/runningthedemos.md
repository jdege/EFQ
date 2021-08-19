[Back...](../README.md)

## Running the demos

The EFQ solution contains four projects:

1. **EFQ** - The EFQ library itself
2. **EFQ.test** - An Xunit unit test assembly
3. **EFQ.dbtest** - An Xunit integration test assembly
4. **EFQ.Web** - An ASPNET Core web application containing demonstrations and examples on how to use EFQ.

**EFQ** and **EFQ.test** are stand-alone, they contain no external dependencies.

Because **EFQ** is essentially a database interface, it doesn't have much behaviour that can be meaningfully tested in the absence of a database. **EFQ.test** contains tests around the serialization and deserialization functionality, but not much more.

### EFQ.dbtest database connectivity

The real functionality is tested in **EFQ.dbtest**, which needs a real database in order to run. In this case, the test database is a **SqlLite** database named "Test.db", which is automatically created on startup. And as **SqlLite** will run on every platform on which .NET 5.0 will run, this should work everyplace. (I've tested on Linux Mint and Windows 10. I've not tested on other flavors of Linux or on the Mac.)

### EFQ.Web database connectivity

**EFQ.Web** also relies upon a database. In it's case it uses **Sql Server**, which is _not_ available on Linux. In order to be able to develop EFQ on Linux, **EFQ.Web** includes a `docker-compose.yml` file that will start an instance of **Sql Server 2019** in a **Docker** container, mapping the standard **Sql Server** ports to the instance in the container.

The instance of **Sql Server** in the container has it's SA password set to `Password1`, and the connection string in **EFQ.Web**'s `appsettings.json` is connecting to localhost, on the standard port, using `User ID=SA;Password=Password1`,

If you're running on Linux, you can start this container with:
```
    $ docker-compose -f EFQ.Web/docker.compose.yml up -d
```

If you're running on Windows, you'd use:
```
    $ docker-compose -f EFQ.Web\docker.compose.yml up -d
```

Except that if you already have **Sql Server** running, it will fail with port conflicts. You have the choice between modifying `docker-compose.yml` to map to a different port, then modifying the connection string in `appsettings.json` to connect to that port, or to not use the docker container at all, and to use your existing instance of **Sql Server**. If you choose the latter you'll probably need to change the password in `appsettings.json`. (I certainly hope that you're not using the password `Password1` in a non-throw-away database).

### EFQ.Web database

No matter which instance of **Sql Server** **EFQ.Web** connects to, on startup it will run a set of database migrations that will create a database named **Chinook**, and will then populate that with a set of sample data copied from the [Chinook Database Project](https://github.com/lerocha/chinook-database).

Because the date fields in **Chinook** data set are in a range from 2009 to 2013, **EFQ.Web** adjusts those dates so the range extends up to the current date. This is necessary in order to make queries like "find all invoices with invoice dates in the last 30 days" return meaningful data.
