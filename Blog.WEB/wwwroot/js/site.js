$(document).ready(function () {
    if ($(window).width() <= 600) {
        $('#myInfo').removeClass('in');
    }
else
{
        $('#myInfo').addClass('in');
}
});

$(window).resize(function () {
    if ($(window).width() >= 600) {
        $('#myInfo').addClass('in');
    }
    if ($(window).width() <= 600) {
        $('#myInfo').removeClass('in');
    }
});