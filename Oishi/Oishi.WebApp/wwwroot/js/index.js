
function HideSubCategories(current_id) {
    $('.sub-category-list-item').not('.' + current_id).hide();
}

function ToggleSubCategory(item) {
    HideSubCategories(item.id);
    $('.' + item.id).toggle();
}

$(document).ready(function () {
    HideSubCategories('all')
});
