
var GigsController = function (attendanceService, followService) {

    var button;

    var init = function (container) {
        $(container).on("click", ".js-toggle-attendance", toggleAttendance);
        $(container).on("click", ".js-toggle-follow", toggleFollow);
    }

    // Attendance Code
    var toggleAttendance = function (e) {
        button = $(e.target);

        var gigId = button.attr("data-gig-id");

        if (button.hasClass("btn-default"))
            attendanceService.createAttendance(gigId, doneAttendance, failAttendance);
        else
            attendanceService.deleteAttendance(gigId, doneAttendance, failAttendance);

    }

    var doneAttendance = function () {
        //alert("-" + button.text() + "-" + (String(button.text()) == "Going"));
        var text = (button.text() == "Going") ? "Going?" : "Going";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
        //alert("Button changed to: " + button.text());
    };

    var failAttendance = function () {
        alert("Failed to modify attendance");
    };
    // End Attendance Code

    // Follow Code
    var toggleFollow = function (e) {
        button = $(e.target);

        var userId = button.attr("data-user-id");

        if (button.text() == "Follow")
            followService.follow(userId, doneFollow, failFollow);
        else
            followService.unfollow(userId, doneFollow, failFollow);

    }

    var doneFollow = function () {
        location.reload(true);
        //var text = (button.text() == "Following") ? "Follow" : "Following";
        //button.text(text); //.toggleClass("btn-info").toggleClass("btn-default")
    };

    var failFollow = function () {
        alert("Failed to modify following");
    };
    // End Follow Code

    return {
        init: init
    }
}(AttendanceService, FollowService);