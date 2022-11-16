$(document).ready(function () {
    $("#dataTableGetSubmissionAdmin").dataTable({
        "ajax": {
            url: "/Submission/GetSubmissionAdminAll",
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
                "render": function (data, type, row) {
                    return `${row.assetName}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {

                    return `${row.volume}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {

                    return `${row.goodAsset}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {

                    return `${row.brokenAsset}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {

                    return `${row.assetLocation.name}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {

                    return `${row.yearsProcurement.years}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row, meta) {

                    return `<button type="button" class="btn btn-info" data-toggle="modal" data-placement="top" title="Detail" data-target="#DetailModal" onclick="getsubmission('${row['assetCode']}')"><i class="bi-info-square-fill"></i></button>

                     <button type="button" class="btn btn-danger" data-toggle="modal" data-placement="top" title="Delete"
                        onclick="Delete('${row['assetCode']}')"><i class="bi-trash3-fill"></i></button>

                     <button type="button" class="btn btn-primary" data-toggle="modal" data-placement="top" title="Edit"
                        data-target="#EditModal" onclick="Edit('${row['assetCode']}')"><i class="bi-pencil-square"></i></button>`;
                }
            }
        ]
    });

});

function getsubmission(id) {
    $.ajax({
        url: "/Submission/Get/" + id,
        data: "",
        success: function (result) {
            console.log(result)
            $("#Detail").html(
                `<div class="form-group col-xl-6 col-sm-6">
                    <label for="inputState">Asset Code : <span id="assetCode"> ${result.assetCode} </span>  </label>
                </div>
                <div class="form-group col-xl-6 col-sm-6">
                    <label for="inputState">Asset Name : <span id="total"> ${result.assetName} </span>  </label>
                </div>
                <div class="form-group col-xl-6 col-sm-6">
                    <label for="inputState">Asset Volume : <span id="assetCode"> ${result.volume} </span>  </label>
                </div>
                <div class="form-group col-xl-6 col-sm-6">
                    <label for="inputState">Prize/pcs : Rp.<span id="total"> ${result.prize} </span>  </label>
                </div>
                <div class="form-group col-xl-6 col-sm-6">
                    <label for="inputState">Asset Value : Rp.<span id="assetCode"> ${result.assetValue} </span>  </label>
                </div>
                <div class="form-group col-xl-6 col-sm-6">
                    <label for="inputState">Good Asset : <span id="total"> ${result.goodAsset} </span>  </label>
                </div>
                <div class="form-group col-xl-6 col-sm-6">
                    <label for="inputState">Broken Asset : <span id="assetCode"> ${result.brokenAsset} </span>  </label>
                </div>
                <div class="form-group col-xl-6 col-sm-6">
                    <label for="inputState">Asset Category : <span id="total"> ${result.assetCategory.name} </span>  </label>
                </div>
                <div class="form-group col-xl-6 col-sm-6">
                    <label for="inputState">Asset Location : <span id="assetCode"> ${result.assetLocation.name} </span>  </label>
                </div>
                <div class="form-group col-xl-6 col-sm-6">
                    <label for="inputState">Years Procurement : <span id="total"> ${result.yearsProcurement.years} </span>  </label>
                </div>
                `)
        },
        error: function (error) {
            console.log(error)
        }
    })
}

function Edit(id) {
    $.ajax({
        url: "/Submission/Get/" + id,
        type: "GET"
    }).done((data) => {
        console.log(data);
        $("#AssetName").val(data.assetName);
        $("#GoodAsset").val(data.goodAsset);
        $("#BrokenAsset").val(data.brokenAsset);
        $("#AssetCategory").val(data.assetCategory_Id);
        $("#AssetLocation").val(data.assetLocation_Id);
        $("#Years").val(data.yearsOfSubmission);
        let btn = document.getElementById("buttonEdit");
        btn.addEventListener("click", function (e) {
            e.preventDefault();
            let obj = new Object();
            obj.id = id;
            obj.assetCode = data.assetCode;
            obj.assetName = $("#AssetName").val();
            obj.volume = data.volume;
            obj.prize = data.prize;
            obj.assetValue = data.assetValue;
            obj.status = 2;
            obj.goodAsset = $("#GoodAsset").val();
            obj.brokenAsset = $("#BrokenAsset").val();
            obj.employee_Id = data.employee_Id;
            obj.assetCategory_Id = $("#AssetCategory").val();
            obj.assetLocation_Id = $("#AssetLocation").val();
            obj.yearsOfSubmission = $("#Years").val();
            console.log(obj);
            $.ajax({
                url: "/Submission/Put",
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
                            window.location.href = "/Submission/GetAdminAll"
                        }
                    });
                    /*$("#EditModal").modal("toggle");
                    $('#dataTableGetSubmissionAdmin').DataTable().ajax.reload();*/
                    
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
                url: `/Submission/DeleteEntity/` + id,
                type: "DELETE"
            }).done((result) => {
                if (result == 200) {
                    Swal.fire(
                        'Deleted!',
                        'Your file has been deleted.',
                        'success'
                    )
                    $('#dataTableGetSubmissionAdmin').DataTable().ajax.reload();
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
  