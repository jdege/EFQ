## Getting Started

1. Install the EFQ NuGet package. (Which will be easier after I publish it to the NuGet gallery. For now, I copy JDege.EFQ.0.1.0 to ~/NuGetPackages, which is where I have my local package source configured.)

2. If you're working with EFQ objects on the browser, call the MapEFQ() extension method in Startup.Configure():

```
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // ...

        // You need to enable static files
        app.UseStaticFiles();

        // Specify whatever route you want
        app.MapEFQ("/efq");

        // ...
    }
```
3. And include the `EFQ.js` script , under whatever route you specified, in your web pages:

```
    <script src="~/efq/EFQ.js"></script>
```

