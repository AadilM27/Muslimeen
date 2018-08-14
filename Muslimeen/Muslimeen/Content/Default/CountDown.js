
    // Set the date we're counting down to 2018/05/17 24:00:00"
var countdownDate = new Date(document.getElementById("hdfCounterDate").value).getTime('yyyy,mm,dd HH:MM:SS');
var countdownFinishTitle = document.getElementById("hdfCounterFinishTitle").value;
    // Update the count down every 1 second
    var x = setInterval(function () {

        // Get todays date and time
        var now = new Date().getTime();

        // Find the distance between now an the count down date
        var distance = countdownDate - now;

        // Time calculations for days, hours, minutes and seconds
        var days = Math.floor(distance / (1000 * 60 * 60 * 24));
        var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        var seconds = Math.floor((distance % (1000 * 60)) / 1000);

       //Display the result in the element with id="title"
        document.getElementById("spDays").innerHTML = days;
        document.getElementById("spHours").innerHTML = hours;
        document.getElementById("spMinutes").innerHTML = minutes;
        document.getElementById("spSeconds").innerHTML = seconds;

        // If the count down is finished, write some text
        if (distance < 0) {
            clearInterval(x);
            document.getElementById("title").innerHTML = countdownFinishTitle;
            document.getElementById("spDays").innerHTML = 0;
            document.getElementById("spHours").innerHTML = 0;
            document.getElementById("spMinutes").innerHTML = 0;
            document.getElementById("spSeconds").innerHTML = 0;
        }
    }, 1000);
