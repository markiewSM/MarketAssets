$(function () {


    function DisplayResult1(call, data) {

        $('#result').append("<strong>" + call + "<strong>" + "<br/>");

        $.each(data, function (i, item) {

            $('#result').append(JSON.stringify(item));
            $('#result').append("<br/>");
        });
    };

    function DisplayResult2(call, data) {

        $('#result').append("<strong>" + call + "<strong>" + "<br/>");

        $('#result').append(JSON.stringify(data));
        $('#result').append("<br/>");

    };

    function LoadAssets(data) {
        //alert("Hello");
        $.each(data, function (i, item) {
            var tableRow = '<tr>' +
                '<td>' + item.assetId + '</td>' +
                '<td>' + item.Property + '</td>' +
                '<td>' + item.Value + '</td>' +
                '<td>' + item.Timestamp + '</td>' +
                '</tr>';
            $('#AssetsTable').append(tableRow);
        });
    };



    //url and port number of web api/ postman
    var serviceUrl = 'https://localhost:44370/api';
    $('#GetAll').on('click', function () {
        $.ajax({
            url: serviceUrl + '/assets',
            method: 'GET',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                LoadAssets(data);
            }
        });
    });


    $('#AddFile').on('click', function () {
        //form encoded data
        //var dataType = 'application/x-www-form-urlencoded; charset=utf-8';
        var inputData = $('input').serialize();
        //alert(inputData);
        $.ajax({
            url: serviceUrl + '/assets',
            method: 'POST',
            //contentType: dataType,
            data: JSON.stringify(inputData),
            success: function (data) {
                DisplayResult2("Add file", data);
            }
        });
    });


    $('#GetById').on('click', function () {
        var inputData = $('input').serialize();
        //var value = $('#value').val();
       
        $.ajax({
            url: serviceUrl + '/assets/' + inputData,
            method: 'GET',
            //data: inputData,
            success: function (data) {
                DisplayResult2("Get By Asset Id:", data);
            }
        });
    });
   
});
