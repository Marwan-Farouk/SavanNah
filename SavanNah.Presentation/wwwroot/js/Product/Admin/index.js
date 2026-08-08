var table;
$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    table = new DataTable("#myTable", {
        ajax: { url: "/admin/product/GetAll", dataSrc: "" },
        columns: [
            { data: "Name", width: "15%" },
            { data: "Price", width: "10%" },
            { data: "Discount", width: "10%" },
            { data: "Brand.Name", width: "10%" },
            {
                data: "CategoryProducts",
                width: "10%",
                render: function (data) {
                    if (data && data.length > 0) {
                        return data.map((cp) => cp.Category.Name).join(",");
                    }
                    return "";
                },
            },
            {
                data: "Id",
                width: "10%",
                render: function (data) {
                    return `<div class="d-flex gap-2">
                            <a onClick="Details('${data}')" class="btn btn-outline-info btn-sm">Details</a>
                            <a href="/admin/product/Edit/${data}" class="btn btn-outline-warning btn-sm">Edit</a>
                            <a onClick="Delete('/admin/product/Delete/${data}')" class="btn btn-danger btn-sm del-btn">Delete</a>
                        </div>`;
                },
            },
        ],
    });
}

async function Details(id) {
    const response = await fetch(`/admin/product/GetProductPartial/${id}`, {
        method: "GET",
    });

    const result = await response.text();

    document.querySelector(".partial-container").innerHTML = result;
}
function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!",
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    table.ajax.reload();
                    Swal.fire({
                        title: "Deleted!",
                        text: data.message,
                        icon: "success",
                    });
                },
            });
        }
    });
}
