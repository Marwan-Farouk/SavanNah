let btn = document.getElementById("cartBtn");
let productId = btn.dataset.id;
btn.addEventListener("click", async function (event) {
    let count = document.getElementById("count").value;
    const response = await fetch(`/Cart/Add?id=${productId}&count=${count}`, {
        method: "POST",
        credentials: "same-origin"
    });
    if (response.ok) {
        const notification = document.createElement("div");
        notification.className = "toast show align-items-center text-bg-success border-0 position-fixed top-0 end-0 m-3 z-3";
        notification.setAttribute("role", "status");
        notification.setAttribute("aria-live", "polite");
        notification.setAttribute("aria-atomic", "true");
        notification.innerHTML = `
            <div class="d-flex">
                <div class="toast-body">Product added to cart.</div>
                <button type="button" class="btn-close btn-close-white me-2 m-auto" aria-label="Close"></button>
            </div>`;

        document.body.appendChild(notification);

        const closeButton = notification.querySelector(".btn-close");
        const removeNotification = () => notification.remove();
        closeButton.addEventListener("click", removeNotification);
        setTimeout(removeNotification, 3000);
    }
})