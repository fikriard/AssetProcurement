$(document).ready(function () {
    console.log("test")
    $.ajax({
        type: "GET",
        url: "/Department/GetAll",
        dataType: 'json',
        dataSrc: "",
        success: function (result) {
            console.log(result);
            $.each(result, function () {
                $("#Department_Id").append($("<option />").val(this.id).text(`${this.name}`));
            });
        }
    })
    $.ajax({
        type: "GET",
        url: "/Jobs/GetAll",
        dataType: 'json',
        dataSrc: "",
        success: function (result) {
            console.log(result);
            $.each(result, function () {
                $("#Job_Id").append($("<option />").val(this.id).text(`${this.title}`));
            });
        }
    })
    let btn = document.getElementById("buttonAdd");
    btn.addEventListener("click", function (e) {
        e.preventDefault();
        let obj = new Object();
        obj.nik = $("#NIK").val();
        obj.firstName = $("#FirstName").val();
        obj.lastName = $("#LastName").val();
        obj.email = $("#Email").val();
        obj.phoneNumber = $("#PhoneNumber").val();
        obj.gender = $("#Gender").val();
        obj.username = $("#UserName").val();
        obj.password = $("#Password").val();
        obj.job_Id = $("#Job_Id").val();
        obj.department_Id = $("#Department_Id").val();
        $.ajax({
            url: "/Auth/Register",
            type: "POST",
            data: obj
        }).done((result) => {
            console.log(result);
            if (result == 200) {
                Swal.fire({
                    title: 'Good Job!',
                    text: 'Your data has been saved.',
                    icon: 'success',
                }).then((result) => {
                    if (result.isConfirmed) {
                        window.location.href = "/Home/Register"
                    }
                });
                
            }
            else if (result == 400) {
                Swal.fire(
                    'Watch Out!',
                    'Duplicate Data!',
                    'error'
                )
            }

        }
        ).fail((error) => {
            console.log(error);
        })
    })
});