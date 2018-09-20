$(function () {
    $(document).keyup(function (e) {
        var key = (e.keyCode ? e.keyCode : e.charCode);
        switch (key) {
            case 112:
                navigateUrl($('a[id$=lnk1]'));
                break;
            default: ;
        }
    });
    function navigateUrl(jObj) {
        window.location.href = $(jObj).attr("href");
    }
});