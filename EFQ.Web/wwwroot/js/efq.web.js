DropdownService = {

    getDropdown: function (url, options, callback)
    {
        var settings = {
            type: "GET",
            dataType: "json",
            data: { includeQueries: options.includeQueries },
            contentType: "application/json"
        };

        $.ajax(url, settings)
            .done((result, status, jqXHR) =>
            {
                callback({ success: true, data: result });
            })
            .fail((jqXHR, textStatus, errorThrown) =>
            {
                callback({ success: false, error: errorThrown });
            });
    },

    getArtists: function (options, callback)
    {
        var url = "/api/Artist/GetDropdown";

        var settings = {
            type: "GET",
            dataType: "json",
            data: { includeQueries: options.includeQueries },
            contentType: "application/json"
        };

        $.ajax(url, settings)
            .done((result, status, jqXHR) =>
            {
                callback({ success: true, data: result });
            })
            .fail((jqXHR, textStatus, errorThrown) =>
            {
                callback({ success: false, error: errorThrown });
            });
    },

    getCustomers: function (options, callback)
    {
        var url = "/api/Customer/GetDropdown";

        var settings = {
            type: "GET",
            dataType: "json",
            data: { includeQueries: options.includeQueries },
            contentType: "application/json"
        };

        $.ajax(url, settings)
            .done((result, status, jqXHR) =>
            {
                callback({ success: true, data: result });
            })
            .fail((jqXHR, textStatus, errorThrown) =>
            {
                callback({ success: false, error: errorThrown });
            });
    },

    getMediaTypes: function (options, callback)
    {
        var url = "/api/MediaType/GetDropdown";

        var settings = {
            type: "GET",
            dataType: "json",
            data: { includeQueries: options.includeQueries },
            contentType: "application/json"
        };

        $.ajax(url, settings)
            .done((result, status, jqXHR) =>
            {
                callback({ success: true, data: result });
            })
            .fail((jqXHR, textStatus, errorThrown) =>
            {
                callback({ success: false, error: errorThrown });
            });
    }
};

TrackQueryService = {
    getTracks: function (artistId, customerId, callback)
    {
        var url = "/api/Track";
        var data = { artistId: artistId, customerId: customerId };
        var settings = {
            type: "GET",
            dataType: "json",
            contentType: "application/json",
            data: data
        };

        $.ajax(url, settings)
            .done((result, status, jqXHR) =>
            {
                callback({ success: true, data: result });
            })
            .fail((jqXHR, textStatus, errorThrown) =>
            {
                callback({ success: false, error: errorThrown });
            });
    },
    queryTracks: function (efq, callback)
    {
        var url = "/api/Track/Query";
        var data = JSON.stringify(efq);
        var settings = {
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            data: data
        };

        $.ajax(url, settings)
            .done((result, status, jqXHR) =>
            {
                callback({ success: true, data: result });
            })
            .fail((jqXHR, textStatus, errorThrown) =>
            {
                callback({ success: false, error: errorThrown });
            });
    },
    storedQuery: function (id, context, callback)
    {
        var url = "/api/Track/StoredQuery/" + id;
        var data = context ? JSON.stringify(context) : "{}";
        var settings = {
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            data: data
        };

        $.ajax(url, settings)
            .done((result, status, jqXHR) =>
            {
                callback({ success: true, data: result });
            })
            .fail((jqXHR, textStatus, errorThrown) =>
            {
                callback({ success: false, error: errorThrown });
            });
    }
};

InvoiceQueryService = {
    storedQuery: function (id, context, callback)
    {
        var url = "/api/Invoice/StoredQuery/" + id;
        var data = context ? JSON.stringify(context) : "{}";
        var settings = {
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            data: data
        };

        $.ajax(url, settings)
            .done((result, status, jqXHR) =>
            {
                callback({ success: true, data: result });
            })
            .fail((jqXHR, textStatus, errorThrown) =>
            {
                callback({ success: false, error: errorThrown });
            });
    }
};