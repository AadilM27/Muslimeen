window.onscroll = function () { myFunction() };

// Get the navbar
var navbar = document.getElementById("navbar");
var content = document.getElementById("content");
// Get the offset position of the navbar
var sticky = navbar.offsetTop;

// Add the sticky class to the navbar when you reach its scroll position. Remove "sticky" when you leave the scroll position
function myFunction() {
    if (window.pageYOffset >= sticky) {
        navbar.classList.add("sticky")
        content.classList.add("contentPad");
    } else {
        navbar.classList.remove("sticky");
        content.classList.remove("contentPad");
    }
}

function AddDateChars() {
    val = document.getElementById("txtDOB").value;
    if (val.length === 2 || val.length === 5) {
        document.getElementById("txtDOB").value += "/";
    }
}

function flashDiv(div)
{
    document.getElementById(div).style.backgroundColor = "lightgreen";

    setTimeout(function Flash1()
    {
        document.getElementById(div).style.backgroundColor = "";

        setTimeout(function Flash2() {
            document.getElementById(div).style.backgroundColor = "lightgreen";

            setTimeout(function Flash3() {
                document.getElementById(div).style.backgroundColor = "";
            }, 500)
        }, 500)
    }, 500)
}
    