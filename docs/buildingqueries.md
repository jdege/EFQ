[Back...](../README.md)

## Building Queries


EFQ objects are constructed using the `EFQBuilder` static methods, which fall into a number of categories.

For the sake of discussion, assume we have these Entity Framework entities:

```
    public partial class Track
    {
        public Track()
        {
            PlaylistTracks = new HashSet<PlaylistTrack>();
        }

        public int TrackId { get; set; }
        public string Name { get; set; }
        public int? AlbumId { get; set; }

        public virtual Album Album { get; set; }
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
```

```
    public partial class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
    }
```

```
    public partial class PlaylistTrack
    {
        public int PlaylistId { get; set; }
        public int TrackId { get; set; }

        public virtual Playlist Playlist { get; set; }
        public virtual Track Track { get; set; }
    }
```

```
    public partial class Playlist
    {
        public Playlist()
        {
            PlaylistTracks = new HashSet<PlaylistTrack>();
        }

        public int PlaylistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
```

Where we're searching for `Tracks`, and there is a many-to-one relationship between `Track` and `Album`, and a many-to-many relationship between `Track` and `Playlist`.

### Comparison methods.

The prototypical comparison method is `EFQBuilder.Equal(string fieldName, object rightHandSide)`:

* **fieldName** is the name of a field. This could be:
    * **Name** - the name of a field in the searched entity, or
    * **Album.Title** - the name of a field in a navigation property

* **rightHandSide** is a constant value. This could be:
    * **12** - a constant number (int, decimal, number), or
    * **"a string"** - a constant string, or
    * **DateTime.Parse("2021-01-01 13:14:45")** - a constant DateTime, DateTimeOffset, or Timespan(), or
    * **{{NOW:DATE}}** - a placeholder for the current date at the time the query is run (NOW or UTCNOW, DATE or DATEOFFSET, or    * **{{NOW:DATE}}** - a placeholder for the current datetime (NOW or UTCNOW, DATETIME or DATETIMEOFFSET, or
    * **{{NOW:DATETIME}}** - a placeholder for the current datetime at the time the query is run (NOW or UTCNOW, DATE or DATEOFFSET, or    * **{{NOW:DATE}}** - a placeholder for the current datetime (NOW or UTCNOW, DATETIME or DATETIMEOFFSET, or
    * **{{CONTEXT:PARAMETERNAME}}** - a placeholder for a parameter that will be substituted at the time the query is run

The basic comparison methods are:

* **Equal**
* **GreaterThan**
* **GreaterThanOrEqual**
* **LessThan**
* **LessThanOrEqual**
* **NotEqual**

The string comparison methods are:

* **StartsWith**
* **EndsWith**
* **Contains**
* **Like** - Uses a SQL `LIKE` string

(The basic comparison methods also work on strings).

There are two other comparison methods:

* **Between** - this takes two arguments, and returns a comparison if the value is between them, inclusively
* **ContainedIn** - this takes a constant collection, and returns true if the value is in the collection:

```
    EFQBuilder.ContainedIn("Name", new[]
    {
        "Name 1",
        "Name 2",
        "Name 3"
    });
```

### Boolean methods.

Aside from `IsTrue`, `IsFalse`, and `Not`, the boolean methods come in two flavors:

* `Or(params JDege.EFQ.EFQ[] efqs)`
* `Or(IEnumerable<JDege.EFQ.EFQ> efqs);`

(`IsTrue` and `IsFalse` take no arguments, `Not` takes only one.)

These work the same way, except that the `params` keyword allows calling the method with multiple arguments, instead of as a single collection:

```
	EFQBuilder.Or(EFQBuilder.Equals("Name", "Name 1"), EFQBuilder.Equals("Name", "Name 2"));
```

Or:

```
	EFQBuilder.Or(new [] {
        EFQBuilder.Equals("Name", "Name 1"),
        EFQBuilder.Equals("Name", "Name 2")
    });
```


The boolean methods are:

* **IsTrue**
* **IsFalse**
* **And**
* **Nand**
* **Nor**
* **Not**
* **Or**

### The Any() method

The Any() method is something of a special case, for dealing with one-to-many and many-to-many navigation properties.

`Any(string fieldName, JDege.EFQ.EFQ innerCriteria)`

If you're searching, for example, for a `Track` that is in a `PlayList` with it's `Name` equal to `My Playlist`, you want all the `Tracks` where any of the entities in their `PlaylistTracks` collection have a `PlayList.Name` equal to `My Playlist`:

```
    EFQBuilder.Any("PlaylistTracks", 
        EFQBuilder.Equal("Playlist.Name", "My Playlist")
    )
```

The `innerCriteria` argument is executed on the navigation collection.

### The Add() method

The Add() method is another special case.

`Add(object left, object right)`

This was implemented for the specific purpose of creating date ranges from the current time.

E.g., invoices in the last thirty days:

```
    EFQBuilder.GreaterThanOrEqual(
        "InvoiceDate",
        EFQBuilder.Add(
            "{{NOW:DATE}}",
            new EFQ.Constant(TimeSpan.FromDays(-30))
        )
    )
```

This could conceivably be generalized to work with numeric types, instead of just adding timespans to dates, but so far there has been no real benefit in doing so.