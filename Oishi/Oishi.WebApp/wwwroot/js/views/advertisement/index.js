function ToggleFavorite(id) {
    $.ajax({
        url: window.location.origin + '/Favorite/Toggle/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            if (data == true) {
                $('#advertisement' + id + 'favicon').removeClass('far').addClass('fa-solid')
            } else {
                $('#advertisement' + id + 'favicon').removeClass('fa-solid').addClass('far')
            }
        },
        error: function (request, error) {
            alert("Request: " + JSON.stringify(request));
        }
    });
}


$(document).ready(function () {
    $('.submenu').slideToggle('fast');
    $('.menu').click(function () {
        $(this).siblings('.submenu').slideToggle('fast');
    });
});