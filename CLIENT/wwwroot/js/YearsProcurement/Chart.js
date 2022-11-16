
$.ajax({
    type: "GET",
    url: "/YearsProcurement/GetAll",
    dataType: 'json',
    dataSrc: "",
    success: function (result) {
        console.log(result);
        $.each(result, function () {
            $("#YearsOption").append($("<option />").val(this.id).text(`${this.years}`));

        });
        // Get Select List
        var yearsbutton = document.getElementById("YearsButtton");
        var yearsoption = document.getElementById("YearsOption");
        console.log(yearsoption)
        let ctx = document.getElementById('myChart').getContext('2d');
        let labels = ['remaining funds', 'used funds'];
        let colorHex = ['#FB3640', '#EFCA08'];
        let myChart = new Chart(ctx, {
            type: 'pie',
            data: {
                datasets: [{
                    data: [0, 0],
                    /*data: [result.maxfund - result.total, result.total],*/
                    backgroundColor: colorHex
                }],
                labels: labels
            },
            options: {
                responsive: true,
                legend: {
                    position: 'bottom'
                },
                plugins: {
                    datalabels: {
                        color: '#fff',
                        anchor: 'end',
                        align: 'start',
                        offset: -10,
                        borderWidth: 2,
                        borderColor: '#fff',
                        borderRadius: 25,
                        backgroundColor: (context) => {
                            return context.dataset.backgroundColor;
                        },
                        font: {
                            weight: 'bold',
                            size: '10'
                        },
                        formatter: (value) => {
                            return value + ' %';
                        }

                    }
                }
            }
        })
        // Add event Listener for any change in the selection
        yearsbutton.addEventListener("click", function () {
            $('#dataTableGetYears').DataTable().clear().destroy().draw();
            $("#myChart").show();
           let tahunGet = yearsoption.value
            if (yearsoption != undefined) {
                $.ajax({
                    type: "GET",
                    url: "/YearsProcurement/Get",
                    data: { "id": yearsoption.value},
                    dataType: 'json',
                    dataSrc: "",
                    success: function (result) {
                        myChart.data.datasets[0].data = [((result.maxfund - result.total) / result.maxfund) * 100 , (result.total / result.maxfund)*100 ];
                        myChart.update();
                        console.log(tahunGet)
                        $("#dataTableGetYears").dataTable({
                            "ajax": {
                                type: "GET",
                                url: "/Submission/GetYears",
                                data: { "id": tahunGet },
                                dataType: "JSON",
                                dataSrc: ""
                            },
                            fixedHeader: true, /*{
                                header: false,
                                footer: false
                            },*/
                            "columnDefs": [
                                { "className": "dt-center", "targets": "_all" }
                            ],
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

                                        return `<button type="button" class="btn btn-info" data-toggle="modal" data-placement="top" title="Detail" data-target="#DetailModal" onclick="getsubmission('${row['assetCode']}')"><i class="bi-info-square-fill"></i></button>`;
                                    }
                                }
                            ]
                        });
                    }
                });
                
            }


        });
    },
    error: function (error) {
        console.log(error)
    }

})

/*$("#close").click(function () {
    $("#myChart").hide();
    *//*var table = $("#dataTableGetYears").dataTable();
    table.clear();*//*
    
    *//*$('#dataTableGetYears').DataTable().destroy();*//*
   
    *//*$('#dataTableGetYears').dataTable().fnClearTable();*//*
    *//*if ($.fn.dataTable.isDataTable('#dataTableGetYears')) {
        $('#dataTableGetYears').DataTable().destroy();
        $('#dataTableGetYears').empty();
       
    }*//*
})*/
/*function close() {
    
    
}*/

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