
$("#formlogin").on("submit", () => {
    email = $("#email").val()
    password = $("#password").val()
    $.ajax({
        type: "POST",
        url: "/Login/Auth",
        dataType: 'json',
        data: {
            'email': email,
            'password': password
        },
        success: function (result) {
            console.log(result)
            window.location.href = result;

        },
        error: function (error) {
            console.log(error)
            Swal.fire({
                type: "error",
                title: 'Oops...',
                text: 'login Fail!'
            })
        }

    })
    $.LoadingOverlay("show", {
        image: "",
        fontawesome: "fa fa-cog fa-spin"
    });

    // Hide it after 3 seconds
    setTimeout(function () {
        $.LoadingOverlay("hide");
    }, 12000);
});
function Login() {
        email = $("#email").val()
        password = $("#password").val()

        $.ajax({
            type: "POST",
            url: "/Login/Auth",
            dataType: 'json',
            data: {
                'email': email,
                'password': password
            },
            success: function (result) {
                console.log(result)
                window.location.href = result;

            },
            error: function (error) {
                console.log(error)
                Swal.fire({
                    type: "error",
                    title: 'Oops...',
                    text: 'login Fail!'
                })
            }

        })
    $.LoadingOverlay("show", {
        image: "",
        fontawesome: "fa fa-cog fa-spin"
    });

    // Hide it after 3 seconds
         setTimeout(function () {
        $.LoadingOverlay("hide");
        }, 12000);
}