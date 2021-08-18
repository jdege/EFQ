# EFQ

## Serializable Entity Framework Queries

EFQ is a .NET 5.0 library to enable serializing Entity Framework queries.

When we started working with Entity Framework, there were two functionalities we had been using that EF, out of the box, did not support:

- Constructing a query dynmically on a web page and submitting it to a webservice, and
- Storing a query in the database.

Both of these are pretty simple to do in SQL, and we wanted to be able to do something similar using Entity Framework.

---

There are four .NET projects, in this solution:

* EFQ - the EFQ library itself.
* EFQ.test - an XUnit test suite, running unit tests that do not have any external dependencies.
* EFQ.dbtest - an XUnit test suite, running tests against a local SQLite database.
* EFQ.Web - a aspnet core website, with demonstration pages running against a SqlServer database.

---

#### The problem:

I initially developed this while working on a web-based work-force management application. This application centered around a number of pages by which the users could query the database and retrieve some collection of tasks that needed to be done. 

Some of these pages had a very simple UI - simply going to the page would run a specific query for the current user, returning a collection of tasks.

Some had quite complex UIs, with a dozen or more data entry fields, allowing the user to pick and choose as to what to search by.

The original application was an ASP.NET application using ADO to communicate with the database, and had code running on the server that would run some quite complicated and ugly code to build up SQL statements, based on the fields the user had selected.

We were doing a rewrite in which the page would retrieve data via HTTP Requests to a Web API webservice, and the webservice would communicate with the database using Entity Framework.

The problem was how for the browser to pass the data that the webservice needed to build a query, without creating strong coupling between the webservice and the front-end.

Our solution was wrap Pete Montgomer's [Predicate Builder](https://petemontgomery.wordpress.com/2011/02/10/a-universal-predicatebuilder/)
in a class that allowed us to construct Entity Framework expression trees in a piecemeal manner, and in a way that could be serialized and deserialized into and out of JSON, so they could be sent back and forth between the server and the front-end.

Consider, for example, a HTML &lt;select&gt; element. Our front end would call a Web API endpoint that returned a collection of DropDownModels:

```
    public class DropdownModel
    {
        public string value { get; set; }
        public string text { get; set; }
        public EFQ query { get; set; }
    }
```

The query, in each case, would be an EFQ object that would do the proper comparison if that value was selected:

```
    var dropdownModels = await dbContext.MediaTypes
        .OrderBy(c => c.Name)
        .ProjectTo<DropdownModel>(_configurationProvider)
        .ToListAsync();

    foreach (var model in dropdownModels)
    {
        model.query = EFQBuilder.Equal("MediaTypeId", Int32.Parse(model.value));
    }
```

The front-end would receive these, of course, as JSON, and would construct &lt;option&gt; elements, adding them to the &lt;select&gt; element. The received query object would be stored with each &lt;option&gt; element as a data attribute.

When the user clicks on the Submit button, the event handler would create an array of JavaScript EFQ objects, wrap them all in an EFQ.and(), and pass them off to the search endpoint:

```
    var andQueries = [EFQ.isTrue()];

    var mediaType = $mediaTypeSelect.find(':selected').data('query');
    if (mediaType)
    {
        andQueries.push(mediaType);
    }

    var query = EFQ.and(andQueries);

    TrackQueryService.queryTracks(query, function (result)
```

The Web API endpoint would receive the query as a C# EFQ object. In some cases, the endpoint would run the query as-is, in others it would need to add additional constraints:

```
    public ActionResult<IEnumerable<TaskModel>> Query(EFQ query)
    {
        // Make sure we return data only for the logged-in customer
        var andQuery = EFQBuilder.And(
            EFQBuilder.Equals("customerid", UserContext.Customerid),
            query
        );

        var predicate = andQuery.ConstructPredicate<Task>();
        using (var dbContext = _contextFactory.CreateDbContext())
        {
            var taskModelList = dbContext.Tasks.Where(predicate)
                .OrderBy(t => t.TaskDate)
                .ProjectTo<TaskModel>()
                .ToList();

            return trackModelList;
        }
    }
```

---

* [Getting Started](docs/gettingstarted.md)
* [Building Queries](docs/buildingqueries.md)
* [The Generated Documentation](EFQ/docs/index.md)


© 2021 - Jeffrey C. Dege - MIT License
