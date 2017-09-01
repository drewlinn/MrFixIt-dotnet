var test = "it works";


$(document).ready(function () {
    $('.Claim').submit(function (event) {
        event.preventDefault();
        $.ajax({
            type: 'GET',
            url: '@Url.Action("Claim")',
            success: function (result) {
                $('#claim-status').html(result);
            }
        });
    });
    $('Pending').submit(function (event) {
        $.ajax({
            url: '@Url.Action("Pending")',
            type: 'GET',
            success: function () {

            }
        });
    });
    $('Complete').submit(function (event) {
        $.ajax({
            url: '@Url.Action("Complete")',
            type: 'GET',
            success: function () {

            }
        });
    });
});