
// DropdownService.getArtists(function(result) {
//     fillSelect($artistSelect, result);
// });

// DropdownService.getCustomers(function(result) {


DropdownService = {

    getArtists: function (callback)
    {
        var url = "api/Artists/GetDropdown";

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
        var url = "api/Customers/GetDropdown";

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
