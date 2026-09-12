var table;
$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    table = new DataTable("#orderTable", {
        ajax: { url: "/admin/order/GetOrdersData", dataSrc: "" },
        columns: [
            { data: "Id", width: "%30" },
            { data: "User.UserName", width: "%10" },
            { data: "OrderDate", width: "%20" },
            { data: "Status", width: "%15" },
            { data: "TotalAmount", width: "%15" },
        ],
    });
}
