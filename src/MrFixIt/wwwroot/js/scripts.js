var test = "it works";


$(document).ready(function () {
    $('.claim').click(function () {
        console.log($(this).Job.JobId);
        console.log($(this).Job.JobId);
        console.log($(this).Job.JobId);
        console.log($(this).Job.JobId);
        console.log($(this).Job.JobId);
        console.log($(this).Job.JobId);
        $.ajax({
            data: { id: $(this).Job.JobId },
            url: '/Jobs/Claim',
            type: 'POST',
            success: function (result) {
                    $('#claim-status').html(result);
            }
        });
    });
    $('.pending').submit(function (event) {
        event.preventDefault();
        $.ajax({
            data: $(this).JobId,
            url: 'Jobs/Details/{JobId}/Pending',
            type: 'POST',
            success: function (result) {
                $('#job-pending').html(result);
            }
        });
    });
    $('.complete').submit(function (event) {
        event.preventDefault();
        $.ajax({
            data: $(this).JobId,
            url: 'Jobs/Details//{JobId}Complete',
            type: 'POST',
            success: function (result) {
                $('#job-status').html(result);
            }
        });
    });
});