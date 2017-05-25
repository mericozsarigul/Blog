$(document).ready(function () {
    if ($(window).width() <= 1000) {
        $('#myInfo').removeClass('in');
    }
else
{
        $('#myInfo').addClass('in');
}
});

$(window).resize(function () {
    if ($(window).width() >= 1000) {
        $('#myInfo').addClass('in');
    }
    if ($(window).width() <= 1000) {
        $('#myInfo').removeClass('in');
    }
});