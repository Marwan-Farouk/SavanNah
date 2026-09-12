var table;
$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    table = new DataTable("#paymentTable", {
        ajax: { url: "/admin/payment/GetPaymentsData", dataSrc: "" },
        columns: [
            { data: "Id", width: "25%" },
            { data: "User.UserName", width: "10%" },
            { data: "OrderId", width: "25%" },
            { data: "PaymentDate", width: "25%" }
        ]
    });
}
