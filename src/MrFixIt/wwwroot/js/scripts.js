var test = "it works";


$(document).ready(function () {
    $('claim').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '@Url.Action("Claim")',
            type: 'POST',
            //rewrite this line
            data: { (form#ClaimJob.thisJob).val() },
            dataType: 'json',
            success: function () {
                console.log(JobId);
                $('#claim-${JobId}').html("This job has been claimed by " + Job.Worker.FirstName + " " + Job.Worker.LastName + ".");
            }
        });
    });
});