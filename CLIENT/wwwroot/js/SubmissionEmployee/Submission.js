$(document).ready(function () {
    $("#dataTableGetSubmissionEmployee").dataTable({
        "ajax": {
            url: "/Submission/GetSubmission",
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
                    let status
                    switch (row.status) {
                        case 0:
                           status = "Draft";
                            break;
                        case 1:
                            status = "Posted";
                            break;
                        case 2:
                            status = "Approved";
                            break;
                        case 3:
                            status = "Rejected";
                            break;
                        case 4:
                            status = "Canceled";
                            break;
                        case 5:
                            status = "Approved By Admin";
                            break;
                        case 6:
                            status = "Approved By Finance";
                            break;
                        case 7:
                            status = "Rejected By Admin";
                            break;
                        case 8:
                            status = "Rejected By Finance";
                            break;
                    }
                    return `${status}`;
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
                       `;
                }
            }

        ]
    });

});



function Create() {
    $("#AssetCode").val("");
    $("#AssetName").val("");
    $("#Volume").val("");
    $("#Prize").val("");
   
    console.log("test")
    $.ajax({
        type: "GET",
        url: "/AssetCategory/GetAll",
        dataType: 'json',
        dataSrc: "",
        success: function (result) {
            console.log(result);
            $.each(result, function () {
                $("#AssetCategoryoption").append($("<option />").val(this.id).text(`${this.name}`));
            });
        }
    })
    $.ajax({
        type: "GET",
        url: "/AssetLocation/GetAll",
        dataType: 'json',
        dataSrc: "",
        success: function (result) {
            console.log(result);
            $.each(result, function () {
                $("#AssetLocation").append($("<option />").val(this.id).text(`${this.name}`));
            });
        }
    })
    $.ajax({
        type: "GET",
        url: "/YearsProcurement/GetAll",
        dataType: 'json',
        dataSrc: "",
        success: function (result) {
            console.log(result);
            $.each(result, function () {
                $("#Years").append($("<option />").val(this.id).text(`${this.years}`));
            });
        }
    })
    let btn = document.getElementById("buttonAdd");
    btn.addEventListener("click", function (e) {
        e.preventDefault();
        let obj = new Object();
        obj.assetCode = $("#AssetCode").val();
        obj.assetName = $("#AssetName").val();
        obj.volume = $("#Volume").val();
        obj.prize = $("#Prize").val();
        obj.assetCategory_Id = $("#AssetCategoryoption").val();
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
                Swal.fire({
                    title: 'Good Job!',
                    text: 'Your data has been saved.',
                    icon: 'success',
                }).then((result) => {
                    if (result.isConfirmed) {

                        $("#exampleModal").hide();
                        /*  $('#dataTableGetSubmissionEmployee').DataTable().ajax.reload();*/
                        window.location.href = "/Submission/GetEmployee"
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

$(".close").click(function () {
     $('#AssetCategoryoption').find('option').remove()
    $('#AssetLocation').find('option').remove()
    $('#Years').find('option').remove()
})
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


