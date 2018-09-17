function heading() {
    val = document.getElementById("txtComment").value;

    if (val.indexOf("@")) === -1) {
        document.getElementById("txtComment").style.borderColor = "Red";
        document.getElementById("btn_Submit").disabled = true;
    }
}