var chk = document.getElementById("chkRememberMe");
var txt = document.getElementById("txtUserName").outerHTML;


if (txt.includes('value=""') == true) {
    chk.checked = false;
}