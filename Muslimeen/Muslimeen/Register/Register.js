function CheckPassword()
{
    var password1 = document.getElementById("txtPassword");
    var password2 = document.getElementById("txtRetypePass");

    if (password1.type === "password") {

        password1.type = "text";
        password2.type = "text";
    }
    else {
        password1.type = "password"
        password2.type = "password"
    }

}

function AddDateChars() {
    val = document.getElementById("txtDOB").value;
    var key = event.which || event.keyCode || event.charCode;

    if (key != 8) {
        if (val.length === 2 || val.length === 5) {
            document.getElementById("txtDOB").value += "/";
        }
    }
}

function EmailValidation() {
    val = document.getElementById("txtUserEmail").value;

    if (val.indexOf("@") === -1) {
        document.getElementById("lblErrorPass").innerText = "Invalid Email Address";
        document.getElementById("txtUserEmail").style.borderColor = "Red";
        document.getElementById("btnRegister").disabled = true;
    }
    else if (val.indexOf(".") === -1) {
        document.getElementById("lblErrorPass").innerText = "Invalid Email Address";
        document.getElementById("txtUserEmail").style.borderColor = "Red";
        document.getElementById("btnRegister").disabled = true;
    }
    else {
        document.getElementById("lblErrorPass").innerText = "";
        document.getElementById("txtUserEmail").style.borderColor = "";
        document.getElementById("btnRegister").disabled = false;
    }
}

