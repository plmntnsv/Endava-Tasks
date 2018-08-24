$(function () {
    $("#pdf-hidden-upload-btn").on("change", function () {
        $("#pdf-selected-file-display").html($(this)[0].files[0].name);
    });
});