$(document).ready(function () {
    
    $("#login-form").submit(function (a) {

        a.preventDefault();
        var form = $(this);

        $.ajax({

            url: "https://localhost:44325/api/login",
            method: "post",
            data: form.serialize(),
            success: function (response) {
                localStorage.setItem("token", response);
                console.log(response);
            },
            error: function (error) {
                console.log(error);}
         
        });

    });
    $("#logout").click(function () {

        $.ajax({

            url: "https://localhost:44325/api/logout",
            method: "get",
            headers: { "token": localStorage.getItem("token") },
            success: function (response) {

                console.log(response);
            },
            error: function (error) {
                console.log(error);
            }

        });

    });

});

