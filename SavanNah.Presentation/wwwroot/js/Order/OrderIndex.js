var table;
$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    table = new DataTable("#orderTable", {
        ajax: { url: "/admin/order/GetOrdersData", dataSrc: "" },
        columns: [
            { data: "Id", width: "%20" },
            { data: "User.UserName", width: "%20" },
            { data: "OrderDate", width: "%20" },
            { data: "Status", width: "%20" },
            { data: "TotalAmount", width: "%1" },
            
        ]
    })
}