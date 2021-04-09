// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function() {
    const searchtext = $("#search").val().trim();
    query.searchname = searchtext;
    // post request the necessary data
    $.post("/collection/search", query, data => {
        // update the robotlist
        robotList = data;
    });
}