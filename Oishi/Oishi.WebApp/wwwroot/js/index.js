
function HideSubCategories(id) {
    $('.sub-category').not('.' + id).hide();
}

function ToggleSubCategory(id) {
    HideSubCategories(id);
    $('.' + id).show();

    $('html, body').animate({
        scrollTop: $("#sub-categories").offset().top
    }, 500);
}

$(document).ready(function () {
    HideSubCategories('all')
});

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
