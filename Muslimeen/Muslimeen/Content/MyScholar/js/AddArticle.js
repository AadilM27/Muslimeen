function heading() {
    val = document.getElementById("txtHeading").value;

    if (val.indexOf("@")) === -1) {
        document.getElementById("txtHeading").style.borderColor = "Red";
        document.getElementById("btnSave").disabled = true;
    }
}

function Popup() {
    var divpop = document.getElementById("divAlertPopup");
    setTimeout(function Flash3() {
        divpop.style.display = "none";
    }, 800)
}
