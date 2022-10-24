$(document).ready(function () {
    $("#dataTableGetSubmissionAdmin").dataTable({
        "ajax": {
            url: "/Submission/GetSubmissionFinance",
            type: "GET",
            dataSrc: "",
            dataType: "JSON"
        },
        "columns": [
            {
                "data": "",
                "render": function (data, type, row) {
          
                    return `${row.employees.firstName}` + " " + `${row.employees.lastName}`;
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

                    return `${row.assetValue}`;
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

                     <button type="button" class="btn btn-danger" data-toggle="modal" data-placement="top" title="Reject"  onclick="Reject('${row['assetCode']}')"><i class="bi-clipboard-x"></i></button>

                     <button type="button" class="btn btn-success" data-toggle="modal" data-placement="top" title="Approve"  onclick="Approve('${row['assetCode']}','${row['yearsOfSubmission']}')" ><i class="bi-check-square"></i></button>`;
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
                    <label for="inputState">Employee : <span id="total"> ${result.employees.firstName} ${result.employees.lastName}</span>  </label>
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

function Reject(id) {
    Swal.fire({
        title: "Do you want to Reject this ??",
        text: "You can't revert this!!",
        type: "info",
        showCancelButton: true,
        closeOnConfirm: false,
        animation: "slide-from-top",
        inputPlaceholder: "Write something"
    }).then((result) => {
        console.log(result)
        if (result.value) {
            $.ajax({
                url: "/Submission/Get/" + id,
                type: "Get",
                success: function (data) {
                    console.log(data);
                    let obj = new Object();
                    obj.id = id;
                    
                    obj.assetCode = data.assetCode;
                    obj.assetName = data.assetName;
                    obj.volume = data.volume;
                    obj.prize = data.prize;
                    obj.assetValue = data.assetValue;
                    obj.goodAsset = data.goodAsset;
                    obj.brokenAsset = data.brokenAsset;
                    obj.employee_Id = data.employee_Id;
                    obj.assetCategory_Id = data.assetCategory_Id;
                    obj.assetLocation_Id = data.assetLocation_Id;
                    obj.yearsOfSubmission = data.yearsOfSubmission;
                    obj.status = 8;
                    console.log(obj)
                    $.ajax({
                        url: "/Submission/Put",
                        type: "PUT",
                        data: obj
                    }).done((result) => {
                        console.log(result);
                        $('#dataTableGetSubmissionAdmin').DataTable().ajax.reload();
                       
                    }).fail((error) => {
                        console.log(error);
                    })
                },
                error: function (error) {
                    console.log(error)
                }
            })


        }

    })
}

function Approve(id,yid) {
    Swal.fire({
        title: "Do you want to approvee this ??",
        text: "You can't revert this!!",
        type: "info",
        showCancelButton: true,
        closeOnConfirm: false,
        animation: "slide-from-top",
        inputPlaceholder: "Write something"
    }).then((result) => {
        console.log(result)
        if (result.value) {
            $.ajax({
                url: "/Submission/Get/" + id,
                type: "Get",
                success: function (data) {
                    console.log(data);
                    let obj = new Object();
                    obj.assetcode = id;
                    obj.yearsid = yid;
                    obj.assetCode = data.assetCode;
                    obj.assetName = data.assetName;
                    obj.volume = data.volume;
                    obj.prize = data.prize;
                    obj.assetValue = data.assetValue;
                    obj.goodAsset = data.goodAsset;
                    obj.brokenAsset = data.brokenAsset;
                    obj.employee_Id = data.employee_Id;
                    obj.assetCategory_Id = data.assetCategory_Id;
                    obj.assetLocation_Id = data.assetLocation_Id;
                    obj.yearsOfSubmission = data.yearsOfSubmission;
                    obj.status = 2;
                    console.log(obj)
                    $.ajax({
                        url: "/Submission/ApproveFinance",
                        type: "PUT",
                        data: obj
                    }).done((result) => {
                        console.log(result);
                        $('#dataTableGetSubmissionAdmin').DataTable().ajax.reload();
                      /*  window.location.href = "/Submission/GetFinance"*/
                    }).fail((error) => {
                        console.log(error);
                    })
                },
                error: function (error) {
                    console.log(error)
                }
            })


        }

    })
}