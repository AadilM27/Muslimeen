function RemoveView() {
    var viewstate = document.getElementById("__VIEWSTATE").value;
    if (!empty(viewstate)) {
        document.getElementById("__VIEWSTATE").value = "";
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

function EmailValidation() {
    val = document.getElementById("txtUserEmail").value;

    if (val.indexOf("@") === -1 || val.length <= 8) {
        document.getElementById("lblError").innerText = "Invalid Email Address Format";
        document.getElementById("lblError").style.color = "Red";
        document.getElementById("txtUserEmail").style.borderColor = "Red";
        document.getElementById("btnRegMosque").disabled = true;
    }
    else if (val.indexOf(".") === -1) {
        document.getElementById("lblError").innerText = "Invalid Email Address Format";
        document.getElementById("lblError").style.color = "Red";
        document.getElementById("txtUserEmail").style.borderColor = "Red";
        document.getElementById("btnRegMosque").disabled = true;
    }
    else {
        document.getElementById("lblError").innerText = "";
        document.getElementById("lblError").style.color = "";
        document.getElementById("txtUserEmail").style.borderColor = "";
        document.getElementById("btnRegMosque").disabled = false;
    }
}

function EmailValidationAdmin() {
    val = document.getElementById("txtAdminEmail").value;

    if (val.indexOf("@") === -1 || val.length <= 8) {
        document.getElementById("lblAdminError").innerText = "Invalid Email Address Format";
        document.getElementById("lblAdminError").style.color = "Red";
        document.getElementById("txtAdminEmail").style.borderColor = "Red";
        document.getElementById("btnRegAdmin").disabled = true;
    }
    else if (val.indexOf(".") === -1) {
        document.getElementById("lblAdminError").innerText = "Invalid Email Address Format";
        document.getElementById("lblAdminError").style.color = "Red";
        document.getElementById("txtAdminEmail").style.borderColor = "Red";
        document.getElementById("btnRegAdmin").disabled = true;
    }
    else {
        document.getElementById("lblAdminError").innerText = "";
        document.getElementById("lblAdminError").style.color = "";
        document.getElementById("txtAdminEmail").style.borderColor = "";
        document.getElementById("btnRegAdmin").disabled = false;
    }
}

function EmailValidationMod() {
    val = document.getElementById("txtModEmail").value;

    if (val.indexOf("@") === -1 || val.length <= 8) {
        document.getElementById("lblModError").innerText = "Invalid Email Address Format";
        document.getElementById("lblModError").style.color = "Red";
        document.getElementById("txtModEmail").style.borderColor = "Red";
        document.getElementById("btnRegModerater").disabled = true;
    }
    else if (val.indexOf(".") === -1) {
        document.getElementById("lblModError").innerText = "Invalid Email Address Format";
        document.getElementById("lblModError").style.color = "Red";
        document.getElementById("txtModEmail").style.borderColor = "Red";
        document.getElementById("btnRegModerater").disabled = true;
    }
    else {
        document.getElementById("lblModError").innerText = "";
        document.getElementById("lblModError").style.color = "";
        document.getElementById("txtModEmail").style.borderColor = "";
        document.getElementById("btnRegModerater").disabled = false;
    }
}

function NumbersOnlyRep() {
    val = document.getElementById("txtContactNum").value;
    if (!(/^[0-9]+$/.test(val)) && !(val === "")) {
        document.getElementById("lblError").innerText = "Contact number format incorrect";
        document.getElementById("lblError").style.color = "Red";
        document.getElementById("txtContactNum").style.borderColor = "Red"
        document.getElementById("btnRegMosque").disabled = true;
    }
    else if (Number.isNaN(val) === false) {
        document.getElementById("lblError").innerText = "";
        document.getElementById("lblError").style.color = "";
        document.getElementById("txtContactNum").style.borderColor = "";
        document.getElementById("btnRegMosque").disabled = false;
    }
}

function NumbersOnlyOrg() {
    val = document.getElementById("txtOrgContactNo").value;
    if (!(/^[0-9]+$/.test(val)) && !(val === "")) {
        document.getElementById("lblOrgError").innerText = "Contact number format incorrect";
        document.getElementById("lblOrgError").style.color = "Red";
        document.getElementById("txtOrgContactNo").style.borderColor = "Red"
        document.getElementById("btnAddUpdateOrg").disabled = true;
    }
    else if (Number.isNaN(val) === false) {
        document.getElementById("lblOrgError").innerText = "";
        document.getElementById("lblOrgError").style.color = "";
        document.getElementById("txtOrgContactNo").style.borderColor = "";
        document.getElementById("btnAddUpdateOrg").disabled = false;
    }
}

function NumbersOnlyMod() {
    val = document.getElementById("txtModContactNo").value;
    if (!(/^[0-9]+$/.test(val)) && !(val === "")) {
        document.getElementById("lblModError").innerText = "Contact number format incorrect";
        document.getElementById("lblModError").style.color = "Red";
        document.getElementById("txtModContactNo").style.borderColor = "Red"
        document.getElementById("btnRegModerater").disabled = true;
    }
    else if (Number.isNaN(val) === false) {
        document.getElementById("lblModError").innerText = "";
        document.getElementById("lblModError").style.color = "";
        document.getElementById("txtModContactNo").style.borderColor = "";
        document.getElementById("btnRegModerater").disabled = false;
    }
}

function NumbersOnlyAdmin() {
    val = document.getElementById("txtAdminContactNo").value;
    if (!(/^[0-9]+$/.test(val)) && !(val === "")) {
        document.getElementById("lblAdminError").innerText = "Contact number format incorrect";
        document.getElementById("lblAdminError").style.color = "Red";
        document.getElementById("txtAdminContactNo").style.borderColor = "Red"
        document.getElementById("btnRegAdmin").disabled = true;
    }
    else if (Number.isNaN(val) === false) {
        document.getElementById("lblAdminError").innerText = "";
        document.getElementById("lblAdminError").style.color = "";
        document.getElementById("txtAdminContactNo").style.borderColor = "";
        document.getElementById("btnRegAdmin").disabled = false;
    }
}

//function can be used on any textbox password control.
function ShowPass() {
    var password1 = document.getElementById(event.target.id); //gets the control that triggered the function.

    if (password1.type === "password" ) {

        password1.type = "text";
    } 

    setTimeout(function Rollback() {
        if (password1.type === "text") {

            password1.type = "password";
        }
    },500)

}

// Must contain minimum 8 letters, with at least a symbol, upper and lower case letters and a number.
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
    else{
        document.getElementById(btn).disabled = false;
        document.getElementById(errorLbl).style.color = "";
        document.getElementById(password.id).style.borderColor = null;
        document.getElementById(errorLbl).innerText = "";
    }
}

function DropDown(div) {
    
    var divButtons = document.getElementById(div);

    if (divButtons.classList.contains("collapsing")) {
        divButtons.classList.remove("collapsing");
        document.getElementById('isClicked').value = divButtons;
    } else if (!divButtons.classList.contains("collapsing")) {
        divButtons.classList.add("collapsing");
        document.getElementById('isClicked').value = "";
    }
}

var isClicked = document.getElementById('isClicked').value;
if (!isClicked.isEmpty) {
    //add all div tags that you wish to keep displayed in left nav bar on load. 
    var div1 = document.getElementById(isClicked);
    div1.classList.remove("collapsing");
}

function Popup(divpop1) {
    var divpop = document.getElementById(divpop1);
    setTimeout(function Flash3() {
        divpop.style.display = "none";
        }, 1000)
}
