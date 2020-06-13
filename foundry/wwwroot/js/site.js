// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Searching
$('#searchCardByName').click(function () {
    var cardNameStartingWith = $('#cardName').val();

    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/api/metacard/byNameStart?substring=" + cardNameStartingWith,
        success: function (data) {
            if (data != null && data.length > 0) {
                var html = "";
                $.each(data, function (key, value) {
                    html += "<div><a href='/selectSet?cardName=" + value.name + "&metacardId=" + value.id + "'>" + value.name + "</a></div>";
                });
                $("#cardSearchResults").html("<div>" + html + "</div>");
            }
            else {
                $("#cardSearchResults").text("No results found");
            }
        },
        error: function (xhr, status) {
            console.log(status);
        }
    });
});