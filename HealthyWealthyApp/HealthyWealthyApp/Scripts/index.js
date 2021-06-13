/*
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
}*/

function getWealthyHealthy() {
    $.ajax({
        type: 'GET',
        url: 'api/Values/wealthyIsHappy',
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

function getHappyLongerLife() {

    $.get("../api/values/happyLongLife", function (data, status) {
        //console.log("Happy Longer Life: ", data);

        var happyLifeTable = $('#happyLifeTable');
        var tr;
        // Empty table
        $("#happyLifeTableBody").children().remove()

        $.each(data, function (index, val) {
            tr = $('<tr/>');
            tr.append("<td>" + val.CityName + "</td>");
            tr.append("<td>" + val.RowsCount + "</td>");
            happyLifeTable.append(tr);
        });
    });

    /**
    $.ajax({
        type: 'GET',
        url: '../api/values/happyLongLife', 
        dataTypes: 'json',
        success: function (data) {
            var happyLifeTable = $('#happyLifeTable');
            var tr;
            // Empty table
            $("#happyLifeTableBody").children().remove()

            $.each(data, function (index, val) {
                tr = $('<tr/>');
                tr.append("<td>" + val.CityName + "</td>");
                tr.append("<td>" + val.RowsCount + "</td>");
                happyLifeTable.append(tr);
            });
        }
    }); // ajax
    */
}

function getEstdIncomeLife() {
    $.get("../api/values/estdIncomeLife", function (data, status) {
        //console.log("Happy Longer Life: ", data);

        var incomeLifeTable = $('#incomeLifeTable');
        var tr;
        // Empty table
        $("#incomeLifeTableBody").children().remove()

        $.each(data, function (index, val) {
            tr = $('<tr/>');
            tr.append("<td>" + val.CityName + "</td>");
            tr.append("<td>" + val.RowsCount + "</td>");
            incomeLifeTable.append(tr);
        });
    });

}