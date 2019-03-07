
var AttendanceService = function () {
    var createAttendance = function (gigId, done, fail) {
        $.post("/api/attendances", { GigId: gigId })
            //$.ajax({
            //    url: "/api/attendances/" + { GigId: button.attr("data-gig-id") },
            //    method: "POST"
            //})
            .done(done)
            .fail(fail);
    };

    var deleteAttendance = function (gigId, done, fail) {
        $.ajax({
            url: "/api/attendances/" + gigId,
            method: "DELETE",
        })
            .done(done)
            .fail(fail);
        //$.ajax({
        //    method: 'DELETE',
        //    url: '/api/attendances/' + button.attr("data-gig-id"),
        //    success: function (data) {
        //        button
        //            .removeClass("btn-info")
        //            .addClass("btn-default")
        //            .text("Going?");
        //    },
        //    error: function () {
        //        alert("Something went wrong");
        //    }
        //})
    };

    return {
        createAttendance: createAttendance,
        deleteAttendance: deleteAttendance
    }
}();