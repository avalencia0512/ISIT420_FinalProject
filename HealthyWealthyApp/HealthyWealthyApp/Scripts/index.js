function getMarkups() {
    $.getJSON(apiUrl + "/topCDCounts")
        .done(function (data) {
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: "City: " + item.CityName + ", Count: " + item.RowsCount })
                    .appendTo($('#ans1'));
            });
        }).fail(function (err) {
            $("#ans1Err").text("ERROR: Unexpected error occured.");
        });
}

function getWealthyHealthy() {
    $.ajax({
        type: 'GET',
        url: 'api/Values',
        dataTypes: 'json',
        success: function (data) {
            var happyTable = $('#happyTable');
            var tr;
            // Empty table
            $("#happyTableBody").children().remove()

            $.each(data, function (index, val) {
                tr = $('<tr/>');
                tr.append("<td>" + val.CityName + "</td>");
                tr.append("<td>" + val.RowsCount + "</td>");
                happyTable.append(tr);
            });
        }
    }); // ajax
}