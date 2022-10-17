$(document).ready(function () {
    $("#dataTableGetSubmissionAdmin").dataTable({
        "ajax": {
            url: "/Submission/GetSubmissionAdmin",
            type: "GET",
            dataSrc: "",
            dataType: "JSON"
        },
        "columns": [
            {
                "data": "",
                "render": function (data, type, row) {
                    console.log(row);
                    return `${row.Employee_id.FirstName}` + `${row.Employee_id.LastName}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    console.log(row);
                    return `${row.AssetName}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    console.log(row);
                    return `${row.Volume}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    console.log(row);
                    return `${row.Status}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    console.log(row);
                    return `${row.AssetValue}`;
                }
            },
            {
                "data": "",
                "render": function (data, type, row) {
                    console.log(row);
                    return `${row.AssetLocation.name}`;
                }
            }
        ]
    });

});