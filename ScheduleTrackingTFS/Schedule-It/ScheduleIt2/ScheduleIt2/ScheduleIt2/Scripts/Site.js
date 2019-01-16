// Displays the calendar
$(function () {
    $('#calendar').fullCalendar({
        // put your options and callbacks here
        dayClick: function (date, jsEvent, view) {

            $('.modal').show();

        }
    })
});

// Displays calendar for TempSchedule
$(function () {
    $('#calendarTempSchedule').fullCalendar({
        // put your options and callbacks here
        dayClick: function (date, jsEvent, view) {

            $('.modal').show();

        },
        defaultView: 'agendaWeek'
    })
});

//// Displays calendar for ScheduleTemplate
//$(function () {
//    $('#calendarScheduleTemplate').fullCalendar({
//        // put your options and callbacks here
//        //dayClick: function (date, jsEvent, view) {

//        //    $('.modal').show();

//        //},
//        defaultView: 'agendaWeek',
//        selectable: true,
//        selectHelper: true,
//        editable: true,
//        eventLimit: true,
//        contentHeight: 600,
//        defaultDate: new Date(),
//        timeFormat: 'h(:mm)a',
//        eventLimit: true,
//        eventColor: '#378006',
//        events: events,
//        select: function (start, end) {
//            $.getScript('/events/new)', function () {
//                $('#event_date_range').val(moment(start).format("MM/DD/YYYY HH:mm") + ' - ' + moment(end).format("MM/DD/YYYY HH:mm"));
//                date_range_picker();
//                $('.start_hidden').val(moment(start).format("MM/DD/YYYY HH:mm"));
//                $('.end_hidden').val(moment(end).format("MM/DD/YYYY HH:mm"));
//            });
//        }


//        //select: function (start, end, callback) {
//        //    var event = [];
//        //    event.push({
//        //        title: 'Garten',
//        //        start: '2013-06-10T00:00:00',
//        //        allday: true
//        //    });

//        //    callback(event);
//        //}
//            //$('#remove_container').html('<%= j render "new" %>');
//            //$('new_event').modal('show');


//    })
//});


//Shift/Index calendar 
$(function () {
    //render calendar in view
    $('#shiftCalendar').fullCalendar({
        displayEventEnd: true
    })
    //title is dummied up with "user" string until model is updated to provide that data. 
    let viewList = []
    let queryList = JSON.parse($('#shiftData').val());
    for (let x of queryList) {
        viewList.push({
            title: "User",//change when model supports userId
            start: moment(x["StartTime"]),
            end: moment(x["EndTime"]), 
        });
    }
    $('#shiftCalendar').fullCalendar('renderEvents', viewList);
})

//==================================================================
//Modal utility
//==================================================================
// Close the modal once the close button is clicked
$(function () {
    $('.closeModal').click(function () {
        $('.modal').hide();
    });
});

// Show the model with the message content
// It gets the hidden html for the content to display in the modal,
// gets the Id to send to the server to update the date read property,
// and receives the date read timestamp to display live for the user
$(function () {
    $('.message-title').click(function () {
        $('#modalTitle').html(this.innerHTML);
        $('#modalContent').html($(this).closest('tr').children('.messageContent').text());
        //$('#modalFrom').html($(this).closest('tr').children('.modelSender').text());
        var messageId = $(this).closest('tr').children('.messageId').text();
        var that = $(this).closest('tr').children('.readDate');
        var readDate = that.text();
        if (readDate.trim().length === 0) {
            $.ajax({
                url: 'MarkAsRead',
                type: 'post',
                data: { id: messageId }
            }).done(function (data) {
                that.html(data);
            });
        }
        $('.modal').show();
    })
})



//
$(function () {
    $('.done').click(function () {
        $('input[Name=StartTime]').attr("value","");
    });
});