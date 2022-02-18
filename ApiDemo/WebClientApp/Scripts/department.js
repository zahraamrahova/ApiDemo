$(document).ready(function () {
    console.log(localStorage.getItem("token"));
    $.ajax({

        url: "https://localhost:44325/api/department",
        method: "get",
        headers: { "token": localStorage.getItem("token") },
        success: function (response) {
            var liItems = "";
            for (var i = 0; i < response.length; i++) {
                liItems += '<li class="list-group-item">${response[i].Name}</li>';
            }

            $("#department-list").html(liItems);
            console.log(response);
        },
        error: function (error) {
            console.log(error);
        }

    });

});