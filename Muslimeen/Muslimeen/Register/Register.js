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