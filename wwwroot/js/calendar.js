$(document).ready(function () {
    // page is now ready, initialize the calendar...
    // options and github  - http://fullcalendar.io/
    var calendarFeed = document.getElementById("calendarData").innerText;
    alert(calendarFeed);
    $("#calendar").fullCalendar({
        events: [
            { "title": "Genofefa z trójmiasteczka", "start": "2017-03-02T00:00:00", "end": "2017-03-15T00:00:00" }, { "title": "Zbychu", "start": "2017-03-16T00:00:00", "end": "2017-03-21T00:00:00" },
        ]
    });

});