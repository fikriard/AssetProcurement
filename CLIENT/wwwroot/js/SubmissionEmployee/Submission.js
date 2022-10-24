$(document).ready(function () {
    $("#dataTableGetSubmissionEmployee").dataTable({
        "ajax": {
            url: "/Submission/GetSubmission",
            type: "GET",
            dataSrc: "",
            dataType: "JSON"
        },
        "columns": [
            {
                "data": "",
                "render": function (data, type, row) {
                    return `${row.assetCode}`;
                }
            },
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
                    return `${row.status}`;
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
                       `;
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
        obj.assetCode = $("#AssetCode").val();
        obj.assetName = $("#AssetName").val();
        obj.volume = $("#Volume").val();
        obj.prize = $("#Prize").val();
        obj.assetCategory_Id = $("#AssetCategory").val();
        obj.assetLocation_Id = $("#AssetLocation").val();
        obj.yearsOfSubmission = $("#Years").val();
        obj.status = 1;
        $.ajax({
            url: "/Submission/SubmissionInsert",
            type: "POST",
            data: obj
        }).done((result) => {
            console.log(result);
            if (result == 200) {
                Swal.fire(
                    'Good Job!',
                    'Your data has been saved.',
                    'success'
                )
                $("#exampleModal").modal("toggle");
                $('#dataTableGetSubmissionEmployee').DataTable().ajax.reload();
                window.location.href = "/Submission/GetEmployee"
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
}

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
                    $('#dataTableGetSubmissionEmployee').DataTable().ajax.reload();
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


