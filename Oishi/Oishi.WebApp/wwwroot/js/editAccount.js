
$('#password, #confirmPassword').on('keyup', function () {
    if ($('#password').val() == $('#confirmPassword').val()) {
        $('#message').html('&#x2713').css('color', 'green');
    } else
        $('#message').html('&#x274C').css('color', 'red');
});

//function HideAlterPassword(current_id) {
//    $('.alter-password').not('.' + current_id).hide();
//}

//function ToggleAlterPassword(item) {
//    HideAlterPassword(item.id);
//    $('.' + item.id).toggle();
//}

//$(document).ready(function () {
//    HideAlterPassword('all')
//});




//function HideAlterProfile(current_id) {
//    $('.alter-profile').not('.' + current_id).hide();
//}

//function ToggleAlterProfile(item) {
//    HideAlterProfile(item.id);
//    $('.' + item.id).toggle();
//}

//$(document).ready(function () {
//    HideAlterProfile('all')
//});


