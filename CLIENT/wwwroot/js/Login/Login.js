
function Login() {
        email = $("#email").val()
        password = $("#password").val()

        $.ajax({
            type: "POST",
            url: "/auth/Auth",
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
}