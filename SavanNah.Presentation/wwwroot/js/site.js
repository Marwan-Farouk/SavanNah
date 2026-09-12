// SavanNah — Site JavaScript (User Layout)

// Delete confirmation
var delBtns = document.querySelectorAll(".del-btn");
delBtns.forEach(function (delBtn) {
    delBtn.addEventListener("click", function (e) {
        e.preventDefault();
        let answer = confirm("Are you sure you want to delete this item?");
        if (answer) {
            this.closest("form").submit();
        }
    });
});

// Notification toast animation
window.addEventListener("load", function () {
    var toast = document.getElementById("sv-toast");
    if (toast) {
        // Slide in
        requestAnimationFrame(function () {
            toast.classList.add("show");
        });
        // Slide out after 3s
        setTimeout(function () {
            toast.classList.remove("show");
        }, 3000);
    }
});
