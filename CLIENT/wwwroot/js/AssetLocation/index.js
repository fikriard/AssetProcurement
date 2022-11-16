$(document).ready(function () {
    $("#dataTable").dataTable({
        "ajax": {
            url: "/AssetLocation/GetAll",
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

                    return `${row.name}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {

                    return `<button type="button" class="btn btn-danger" data-toggle="modal" data-placement="top" title="Delete"
                        onclick="Delete('${row['id']}')"><i class="bi-trash3-fill"></i></button>

                     <button type="button" class="btn btn-primary" data-toggle="modal" data-placement="top" title="Edit"
                        data-target="#editAssetLocation" onclick="Edit('${row['id']}')"><i class="bi-pencil-square"></i></button>`;
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
        obj.name = $("#addName").val();
        $.ajax({
            url: "/AssetLocation/Post",
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
                        window.location.href = "/AssetLocation/Index"
                    }
                });
               /* $("#addAssetLocation").modal("toggle");
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
}

function Edit(id) {
    $.ajax({
        url: `/AssetLocation/Get/${id}`,
        type: "GET"
    }).done((data) => {
        console.log(data);
        $("#editName").val(data.name);
        let btn = document.getElementById("buttonEdit");
        btn.addEventListener("click", function (e) {
            e.preventDefault();
            let obj = new Object();
            obj.id = id;
            obj.name = $("#editName").val();
            $.ajax({
                url: "/AssetLocation/Put",
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
                            window.location.href = "/AssetLocation/Index"
                        }
                    });
                    /*$("#editAssetLocation").modal("toggle");
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
                url: `/AssetLocation/DeleteEntity/${id}`,
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