// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var delBtns = document.querySelectorAll(".del-btn");

delBtns.forEach(function (delBtn) {
    delBtn.addEventListener("click", function (e) {
        e.preventDefault();
        let answer = confirm("Are You sure you want to delete this Category?");
        if (answer) {
            this.closest("form").submit();
        }
    });
});

window.addEventListener("load", function () {
    let alert = document.querySelector(".alert");
    if (alert) {
        alert.style.top = "50px";
        this.setTimeout(function () {
            alert.style.top = "-1000px";
        }, 2000);
    }
});
