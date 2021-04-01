
$(document).ready(function () {
    var $LoginToggle = $("#LoginToggle");
    var $popForm = $(".popup-form");

    $LoginToggle.on("click", function () {
        $popForm.toggle(1000);
    });

});