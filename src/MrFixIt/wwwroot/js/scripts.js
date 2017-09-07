var test = "it works";


$(document).ready(function () {
    $('.claim').submit(function () {
        event.preventDefault();
        $.ajax({
            type: 'POST',
            url: 'Jobs/Details/Claim',
            dataType: 'html',
            data: { thisJob },
            success: function (result) {
                    $('#claim-status').html(result);
            }
        });
    });
    $('.pending').click(function () {
        $.ajax({
            type: 'POST',
            url: 'Jobs/Details/Pending',
            dataType: 'html',
            data: { thisJob },
            success: function (result) {
                $('#job-pending').html(result);
            }
        });
    });
    $('.complete').click(function () {
        $.ajax({
            type: 'POST',
            url: 'Jobs/Details/Complete',
            dataType: 'html',
            data: { thisJob },
            success: function (result) {
                $('#job-status').html(result);
            }
        });
    });
});