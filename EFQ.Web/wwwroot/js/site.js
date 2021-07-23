
DropdownService = {

    getArtists: function (callback)
    {
        var url = "api/Artist/GetDropdown";

        var settings = {
            type: "GET",
            dataType: "json",
            contentType: "application/json"
        };

        $.ajax(url, settings)
            .done(function (result, status, jqXHR)
            {
                callback({ success: true, data: result });
            })
            .fail(function (jqXHR, textStatus, errorThrown)
            {
                callback({ success: false, error: errorThrown });
            });
    },

    getCustomers: function (callback)
    {
        var url = "api/Customer/GetDropdown";

        var settings = {
            type: "GET",
            dataType: "json",
            contentType: "application/json"
        };

        $.ajax(url, settings)
            .done(function (result, status, jqXHR)
            {
                callback({ success: true, data: result });
            })
            .fail(function (jqXHR, textStatus, errorThrown)
            {
                callback({ success: false, error: errorThrown });
            });
    }

    // getClientQueries: function (callback)
    // {
    //     var url = "api/Clients/queries";
    //     var settings = {
    //         type: "POST",
    //         dataType: "json",
    //         contentType: "application/json"
    //     };

    //     $.ajax(url, settings)
    //         .done(function (result, status, jqXHR)
    //         {
    //             callback({ success: true, data: result });
    //         })
    //         .fail(function (jqXHR, textStatus, errorThrown)
    //         {
    //             callback({ success: false, error: errorThrown });
    //         });
    // },

    // getWorkers: function (callback)
    // {
    //     var url = "api/Workers";
    //     var settings = {
    //         type: "POST",
    //         dataType: "json",
    //         contentType: "application/json"
    //     };

    //     $.ajax(url, settings)
    //         .done(function (result, status, jqXHR)
    //         {
    //             callback({ success: true, data: result });
    //         })
    //         .fail(function (jqXHR, textStatus, errorThrown)
    //         {
    //             callback({ success: false, error: errorThrown });
    //         });
    // },

    // getWorkerQueries: function (callback)
    // {
    //     var url = "api/Workers/queries";
    //     var settings = {
    //         type: "POST",
    //         dataType: "json",
    //         contentType: "application/json"
    //     };

    //     $.ajax(url, settings)
    //         .done(function (result, status, jqXHR)
    //         {
    //             callback({ success: true, data: result });
    //         })
    //         .fail(function (jqXHR, textStatus, errorThrown)
    //         {
    //             callback({ success: false, error: errorThrown });
    //         });
    // }
};

TrackQueryService = {
    getTracks: function (artistId, customerId, callback)
    {
        var url = "api/Track";
        var data = { artistId: artistId, customerId: customerId };
        var settings = {
            type: "GET",
            dataType: "json",
            contentType: "application/json",
            data: data
        };

        $.ajax(url, settings)
            .done(function (result, status, jqXHR)
            {
                callback({ success: true, data: result });
            })
            .fail(function (jqXHR, textStatus, errorThrown)
            {
                callback({ success: false, error: errorThrown });
            });
    }
    // ,
    // getTasks2: function(efQuery, callback) {
    // 	var url = "api/Tasks2";
    // 	var data = { efQuery: efQuery };
    // 	var settings = {
    // 		type: "POST",
    // 		dataType: "json",
    // 		contentType: "application/json",
    // 		data: JSON.stringify(data)
    // 	};

    // 	$.ajax(url, settings)
    // 		.done(function(result, status, jqXHR) {
    // 			callback({ success: true, data: result });
    // 		})
    // 		.fail(function(jqXHR, textStatus, errorThrown) {
    // 			callback({ success: false, error: errorThrown });
    // 		});
    // }
};