$(document).ready(function () {
    $("#dataTable").dataTable({
        "ajax": {
            url: "/YearsProcurement/GetAll",
            type: "GET",
            dataSrc: "",
            dataType: "JSON"
        },
        "columnDefs": [
            { "className": "dt-center", "targets": "_all" }
        ],
        "columns": [
            {
                "data": "",
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {

                    return `${row.years}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {

                    return `${row.maxfund}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {

                    return `${row.total}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {

                    return `<button type="button" class="btn btn-danger" data-toggle="modal" data-placement="top" title="Delete"
                        onclick="Delete('${row['id']}')"><i class="bi-trash3-fill"></i></button>

                     <button type="button" class="btn btn-primary" data-toggle="modal" data-placement="top" title="Edit"
                        data-target="#editYear" onclick="Edit('${row['id']}')"><i class="bi-pencil-square"></i></button>`;
                }
            }
        ]
    });

});

function Create() {
    console.log("test")
    let btn = document.getElementById("buttonAdd");
    btn.addEventListener("click", function (e) {
        e.preventDefault();
        let obj = new Object();
        obj.years = $("#addyears").val();
        obj.maxfund = $("#addmaxfund").val();
        obj.total = 0;
        $.ajax({
            url: "/YearsProcurement/Post",
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
                        window.location.href = "/YearsProcurement/Manage"
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
        }).fail((error) => {
            console.log(error);
        })
    })
}

function Edit(id) {
    $.ajax({
        url: `/YearsProcurement/Get/${id}`,
        type: "GET"
    }).done((data) => {
        console.log(data);
        $("#editYears").val(data.years);
        $("#editMaxfund").val(data.maxfund);
        $("#edittotal").val(data.total);

        let btn = document.getElementById("buttonEdit");
        btn.addEventListener("click", function (e) {
            e.preventDefault();
            let obj = new Object();
            obj.id = id;
            obj.years = $("#editYears").val();
            obj.maxfund = $("#editMaxfund").val();
            obj.total = $("#edittotal").val();
           
            $.ajax({
                url: "/YearsProcurement/Put",
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
                            window.location.href = "/YearsProcurement/Manage"
                        }
                    });
                    /*$("#editYear").modal("toggle");
                    $('#dataTable').DataTable().ajax.reload();*/
                }
                else if (result == 400) {
                    Swal.fire(
                        'Watch Out!',
                        'Duplicate Data!',
                        'error'
                    )
                }
            }).fail((error) => {
                console.log(error);
            })
        })
    }).fail((error) => {
        console.log(error);
    })
}

function Delete(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: `/YearsProcurement/DeleteEntity/${id}`,
                type: "DELETE"
            }).done((result) => {
                if (result == 200) {
                    Swal.fire(
                        'Deleted!',
                        'Your file has been deleted.',
                        'success'
                    )
                    $('#dataTable').DataTable().ajax.reload();
                }
                else if (result == 400) {
                    Swal.fire(
                        'Error!',
                        'Your data failed to delete',
                        'error'
                    )
                }
            }).fail((error) => {
                console.log(error);
            })
        }
    })
}