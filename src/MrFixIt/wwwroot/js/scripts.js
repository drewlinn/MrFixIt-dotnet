var test = "it works";


$(document).ready(function () {
    $('.claim').click(function () {
        event.preventDefault();
        $.ajax({
            type: 'POST',
            url: '@Url.Action("Claim")',
            success: function (result) {
                $('#claim-status').html(result);
            }
        });
    });
    $('.pending').click(function () {
        $.ajax({
            type: 'POST',
            url: '@Url.Action("Pending")',
            success: function (result) {
                $('#job-pending').html(result);
            }
        });
    });
    $('.complete').click(function () {
        $.ajax({
            type: 'POST',
            url: '@Url.Action("Complete")',
            success: function (result) {
                $('#job-status').html(result);
            }
        });
    });
});