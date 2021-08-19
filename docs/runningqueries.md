[Back...](../README.md)

## Running Queries

Running a query is pretty simple.

#### If you're passing runtime parameters into the query:

1. Have an EFQ object (either created with EFQBuilder, or passed into Web API endpoint, or retrieved from a database, or something):
```
    var query = EFQBuilder.Equals("Name", "{{CONTEXT:searchName}}");
```

2. Construct a parameters dictionary:
```
    var paramDict = new Dictionary<string, EFQ.Constant> {
        {"searchName", new EFQ.Constant("The name we're searching for")}
    };
```

3. Construct a predicate object, using the type of the entity you're searching on, passing the parameter dictionary:
```
    var predicate = efq.ConstructPredicate<Track>(paramDict);
```

4.. Pass the predicate to Entity Framework's `IQueryable<T>.Where()`:
```
    var tracklList = dbContext.Tracks
        .Where(predicate)
        .ToList();
```

#### Or if you're not passing runtime parameters:

1. Have an EFQ object (either created with EFQBuilder, or passed into Web API endpoint, or retrieved from a database, or something):
```
    var query = EFQBuilder.Equals("Name", "The name we're searching for");
```

2. Construct a predicate object, using the type of the entity you're searching on, passing the parameter dictionary:
```
    var predicate = efq.ConstructPredicate<Track>();
```

3.. Pass the predicate to Entity Framework's `IQueryable<T>.Where()`:
```
    var tracklList = dbContext.Tracks
        .Where(predicate)
        .ToList();
```
