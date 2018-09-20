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

function EmailValidation() {
    val = document.getElementById("txtUserEmail").value;

    if (val.indexOf("@") === -1) {
        document.getElementById("lblErrorPass").innerText = "Invalid Email Address format";
        document.getElementById("txtUserEmail").style.borderColor = "Red";
        document.getElementById("btnRegister").disabled = true;
    }
    else if (val.indexOf(".") === -1) {
        document.getElementById("lblErrorPass").innerText = "Invalid Email Address format";
        document.getElementById("txtUserEmail").style.borderColor = "Red";
        document.getElementById("btnRegister").disabled = true;
    }
    else {
        document.getElementById("lblErrorPass").innerText = "";
        document.getElementById("txtUserEmail").style.borderColor = "";
        document.getElementById("btnRegister").disabled = false;
    }
}

function AddDateChars() {
    val = document.getElementById(event.target.id).value;
    var key = event.which || event.keyCode || event.charCode;
    if (key != 8) {

        if (val.length === 2 || val.length === 5) {
            document.getElementById(event.target.id).value += "/";
        }
    }
}

function NumbersOnly() {
    val = document.getElementById("txtContactNum").value;
    if (!(/^[0-9]+$/.test(val)) && !(val === "")) {
        document.getElementById("lblErrorPass").innerText = "Contact number format incorrect";
        document.getElementById("lblErrorPass").style.color = "Red";
        document.getElementById("txtContactNum").style.borderColor = "Red"
        document.getElementById("btnRegister").disabled = true;
    }
    else if (Number.isNaN(val) === false) {
        document.getElementById("lblErrorPass").innerText = "";
        document.getElementById("lblErrorPass").style.color = "";
        document.getElementById("txtContactNum").style.borderColor = "";
        document.getElementById("btnRegister").disabled = false;
    }
}

function VarifyPassword(btn, errorLbl) {
    var password = document.getElementById(event.target.id); //gets the control that triggered the function.

    var regExp = /^(?=.*\d)(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z]).{8,}$/;

    var result = regExp.test(password.value);

    if (result === false || result === 0) {
        document.getElementById(btn).disabled = true;
        document.getElementById(errorLbl).style.color = "Red";
        document.getElementById(password.id).style.borderColor = "Red";
        document.getElementById(errorLbl).innerText = "Password must contain a minimum of 8 letters, with at least a symbol, upper and lower case letters and a number.";
    }
    else {
        document.getElementById(btn).disabled = false;
        document.getElementById(errorLbl).style.color = "";
        document.getElementById(password.id).style.borderColor = null;
        document.getElementById(errorLbl).innerText = "";
    }
}

