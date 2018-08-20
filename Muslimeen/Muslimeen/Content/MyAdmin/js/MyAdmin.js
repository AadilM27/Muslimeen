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
        document.getElementById("lblError").innerText = "Invalid Email Address, a correct E-mail is needed";
        document.getElementById("lblError").style.color = "Red";
        document.getElementById("txtUserEmail").style.borderColor = "Red";
        document.getElementById("btnRegMosque").disabled = true;
    }
    else if (val.indexOf(".") === -1) {
        document.getElementById("lblError").innerText = "Invalid Email Address, a correct E-mail is needed";
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

function EmailValidationMod() {
    val = document.getElementById("txtModEmail").value;

    if (val.indexOf("@") === -1 || val.length <= 8) {
        document.getElementById("lblModError").innerText = "Invalid Email Address, a correct E-mail is needed ";
        document.getElementById("lblModError").style.color = "Red";
        document.getElementById("txtModEmail").style.borderColor = "Red";
        document.getElementById("btnRegModerater").disabled = true;
    }
    else if (val.indexOf(".") === -1) {
        document.getElementById("lblModError").innerText = "Invalid Email Address, a correct E-mail is needed";
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
        document.getElementById("lblError").innerText = "Contact number is invalid";
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
        document.getElementById("lblOrgError").innerText = "Contact number is invalid";
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