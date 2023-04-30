
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
