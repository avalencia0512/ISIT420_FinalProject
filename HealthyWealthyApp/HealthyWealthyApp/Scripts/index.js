

function getWealthyHealthy(topCountryCount) {
    console.log("JQ Country Count = ", topCountryCount);
    
    $.ajax({
        type: 'GET',
        url: 'api/Values/wealthyIsHappy/' + topCountryCount,
        dataTypes: 'json',
        success: function (data) {
            console.log("Wealthy Live Happy Results: ", data);

            var wealthHappyTable = $('#q1RichHappyTable');
            var happyTable = $('#q1happyTable');
            var tr;
            // Empty table
            $("#q1RichHappyTableBody").children().remove();
            $("#q1happyTableBody").children().remove();

            var wealthColRes = data.low5IncomeCollectionResults;
            console.log("Low Income: ", wealthColRes);
            $.each(wealthColRes, function (index, val) {
                tr = $('<tr/>');
                tr.append("<td>" + val.CountryName + "</td>");
                tr.append("<td class=\"rightAlign\">" + val.AvgWealthPP.toFixed(2) + "</td>");
                tr.append("<td class=\"rightAlign\">" + val.AvgHappyScore.toFixed(3) + "</td>");
                wealthHappyTable.append(tr);
            });

            var happyColRes = data.top5IncomeCollectionResults; 
            console.log("High Income: ", happyColRes);
            $.each(happyColRes, function (index, val) {
                tr = $('<tr/>');
                tr.append("<td>" + val.CountryName + "</td>");
                tr.append("<td class=\"rightAlign\">" + val.AvgWealthPP.toFixed(2) + "</td>");
                tr.append("<td class=\"rightAlign\">" + val.AvgHappyScore.toFixed(3) + "</td>");
                happyTable.append(tr);
            });
        }
    }); // ajax
}

// Q2 - Happy Live Longer
function getHappyLongerLife(happyScore, lifeSpan) {
    //var happyScore = $('#happyMoreThan').val();
    //var countryIdSelect = $("#selectCountry").val();
    //var selectedText = $("#selectCountry").find(':selected').text();    
    //console.log("JQ Hp Score: ", happyScore, " Selected Country = ", countryIdSelect, " Name: ", selectedText);

    var dataToPass = { happinessScore: happyScore, lifeSpanParam: lifeSpan };
    
    $.get("../api/values/happyLongLife", dataToPass, function (data, status) {
        //console.log("Happy Longer Life: ", data);
        console.log("Happy Live Longer Results: ", data);

        var happyLifeTable = $('#q2happyLifeTable');
        var longLifeTable = $('#q2longLifeTable');
        var tr;
        // Empty table
        $("#q2happyLifeTableBody").children().remove();
        $("#q2longLifeTableBody").children().remove();

        var happyColRes = data.happyCollectionResults;
        $.each(happyColRes, function (index, val) {
            tr = $('<tr/>');
            tr.append("<td>" + val.CountryName + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.AvgHappyScore.toFixed(3) + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.AvgLifeSpan.toFixed(0) + "</td>");
            happyLifeTable.append(tr);
        });

        var lifeColRes = data.lifeCollectinResults;
        $.each(lifeColRes, function (index, val) {
            tr = $('<tr/>');
            tr.append("<td>" + val.CountryName + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.AvgLifeSpan.toFixed(0) + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.AvgHappyScore.toFixed(3) + "</td>");
            longLifeTable.append(tr);
        });
    });

}

// Q3 - Wealthy Live Longer
function getEstdIncomeLife(estdIncomeAmt) {

    if (!estdIncomeAmt) {
        estdIncomeAmt = 0;
    }
    console.log(" incomeAmt = ", estdIncomeAmt);

    var dataToPass = { estdIncome: estdIncomeAmt };
    
    $.get("../api/values/estdIncomeLife", dataToPass, function (data, status) {
        console.log("Wealthy Longer Life: ", data);

        var incomeLifeTable = $("#q3incomeLifeTable");
        var longLifeTable = $('#q3longLifeTable');
        var tr;
        // Empty tables
        $("#q3incomeLifeTableBody").children().remove();
        $("#q3longLifeTableBody").children().remove();

        var wealthColRes = data;    //.incomeCollectionResults;
        $.each(wealthColRes, function (index, val) {
            tr = $('<tr/>');
            tr.append("<td>" + val.CountryName + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.AvgWealthPP.toFixed(2) + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.EstdAge2021.toFixed(0) + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.EstdAge2022.toFixed(0) + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.EstdAge2023.toFixed(0) + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.EstdAge2024.toFixed(0) + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.EstdAge2025.toFixed(0) + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.EstdAge2026.toFixed(0) + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.EstdAge2027.toFixed(0) + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.EstdAge2028.toFixed(0) + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.EstdAge2029.toFixed(0) + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.EstdAge2030.toFixed(0) + "</td>");
            tr.append("<td class=\"rightAlign\">" + val.EstdAge2031.toFixed(0) + "</td>");
            incomeLifeTable.append(tr);
        });

    });

}