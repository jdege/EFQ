[Back...](../README.md)

## Running queries


Running a query is pretty simple.

1. Have an EFQ object (either created with EFQBuilder, or passed into Web API endpoint, or retrieved from a database, or something):

```
    var query = EFQBuilder.Equals("Name", ""{{CONTEXT:searchName}});

```

2. If you're passing run-time parameters into the query, construct a parameters dictionary:

```
    var paramDict = new Dictionary<string, EFQ.Constant> {
        {"searchName", new EFQ.Constant("The Name We're Searching for")}
    };

```

3. Construct a predicate object, using the type of the entity you're searching on:

```
    var predicate = efq.ConstructPredicate<Track>(paramDict);

```

4. Pass the predicate to Entity Framework's `IQueryable<T>.Where()`:

```
    var tracklList = dbContext.Tracks
        .Where(predicate)
        .ToList();
```

