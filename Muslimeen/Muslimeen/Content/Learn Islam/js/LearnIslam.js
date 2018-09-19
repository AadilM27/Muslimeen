function RemoveView() {
    var viewstate = document.getElementById("__VIEWSTATE").value;
    if (!empty(viewstate)) {
        document.getElementById("__VIEWSTATE").value = "";
    }
}
function heading() {
    val = document.getElementById("txtComment").value;

    if (val.indexOf("@")) === -1) {
        document.getElementById("txtComment").style.borderColor = "Red";
        document.getElementById("btn_Submit").disabled = true;
    }
}