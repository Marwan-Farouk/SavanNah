// SavanNah — Admin JavaScript

window.addEventListener('DOMContentLoaded', function () {
    // Sidebar toggle for mobile
    var sidebarToggle = document.getElementById('sidebarToggle');
    var sidebar = document.getElementById('adminSidebar');

    if (sidebarToggle && sidebar) {
        sidebarToggle.addEventListener('click', function (e) {
            e.preventDefault();
            sidebar.classList.toggle('show');
        });

        // Close sidebar when clicking outside on mobile
        document.addEventListener('click', function (e) {
            if (window.innerWidth < 992 && sidebar.classList.contains('show')) {
                if (!sidebar.contains(e.target) && !sidebarToggle.contains(e.target)) {
                    sidebar.classList.remove('show');
                }
            }
        });
    }

    // Notification toast animation (admin uses same system)
    var toast = document.getElementById("sv-toast");
    if (toast) {
        requestAnimationFrame(function () {
            toast.classList.add("show");
        });
        setTimeout(function () {
            toast.classList.remove("show");
        }, 3000);
    }

    // Delete confirmation
    var delBtns = document.querySelectorAll(".del-btn");
    delBtns.forEach(function (delBtn) {
        delBtn.addEventListener("click", function (e) {
            e.preventDefault();
            if (confirm("Are you sure you want to delete this item?")) {
                this.closest("form").submit();
            }
        });
    });
});
