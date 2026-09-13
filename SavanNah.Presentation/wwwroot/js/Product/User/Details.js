let btn = document.getElementById("cartBtn");
let productId = btn.dataset.id;
btn.addEventListener("click", async function (event) {
    let count = document.getElementById("count").value;
    const response = await fetch(`/Cart/Add?id=${productId}&count=${count}`, {
        method: "POST",
        credentials: "same-origin"
    });
    if (response.ok) {
        window.location.reload();
        
    }
})