function AddDateChars() {
    val = document.getElementById("txtCounterEndDate").value;
    var key = event.which || event.keyCode || event.charCode;

    if (key != 8) {

        if (val.length === 2 || val.length === 5) {
            document.getElementById("txtCounterEndDate").value += "/";
        }
    }
}
