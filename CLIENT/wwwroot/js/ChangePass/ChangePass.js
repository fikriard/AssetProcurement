$(document).ready(function () {
    console.log("test")
   
    let btn = document.getElementById("buttonAdd");
    btn.addEventListener("click", function (e) {
        e.preventDefault();
        let obj = new Object();
        obj.oldPassword = $("#OldPass").val();
        obj.newPassword = $("#NewPass").val();
        console.log(obj);
        $.ajax({
            url: "/Auth/Changepass",
            type: "PUT",
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
                        window.location.href = "/Home/ChangePass"
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