var chk = document.getElementById("chkRememberMe");
var txt = document.getElementById("txtUserName").outerHTML;


if (txt.includes('value=""') == true) {
    chk.checked = false;
}


function ShowPass() {
    var password1 = document.getElementById(event.target.id); //gets the control that triggered the function.

    if (password1.type === "password") {

        password1.type = "text";
    }

    setTimeout(function Rollback() {
        if (password1.type === "text") {

            password1.type = "password";
        }
    }, 500)

}