const cartItems = document.querySelectorAll(".cart-item");
const removeEndpoint = "";

function syncUpdateButton(cartItem) {
    const countInput = cartItem.querySelector(".cart-count-input");
    const updateButton = cartItem.querySelector(".update-cart-btn");
    const originalCount = Number(countInput.dataset.originalCount);
    const count = Number(countInput.value);
    const isValid = Number.isInteger(count) && count >= 1;
    const isChanged = count !== originalCount;

    const isHidden = !isChanged;
    updateButton.classList.toggle("is-hidden", isHidden);
    updateButton.setAttribute("aria-hidden", String(isHidden));
    updateButton.disabled = !isChanged || !isValid;
}

async function updateCartItem(cartItem) {
    const countInput = cartItem.querySelector(".cart-count-input");
    const updateButton = cartItem.querySelector(".update-cart-btn");
    const count = Number(countInput.value);
    const updateEndpoint = cartItem.dataset.updateUrl;

    if (!Number.isInteger(count) || count < 1 || !updateEndpoint) {
        return;
    }

    const updateUrl = new URL(updateEndpoint, window.location.origin);
    updateUrl.searchParams.set("id", cartItem.dataset.productId);
    updateUrl.searchParams.set("newCount", count);
    updateButton.disabled = true;

    try {
        const response = await fetch(updateUrl, {
            method: "POST",
            credentials: "same-origin",
            headers: {
                Accept: "application/json"
            }
        });

        if (!response.ok || response.redirected) {
            throw new Error(`Update failed with status ${response.status}.`);
        }

        countInput.dataset.originalCount = String(count);
        syncUpdateButton(cartItem);
        window.location.reload();
    } catch (error) {
        console.error(error);
        syncUpdateButton(cartItem);
        window.alert("The cart item could not be updated.");
    }
}

async function removeCartItem(cartItem) {
    if (!removeEndpoint) {
        console.warn("The cart remove endpoint has not been configured yet.");
        return;
    }

    const removeUrl = new URL(removeEndpoint, window.location.origin);
    removeUrl.searchParams.set("id", cartItem.dataset.productId);

    try {
        const response = await fetch(removeUrl, {
            method: "DELETE",
            credentials: "same-origin",
            headers: {
                Accept: "application/json"
            }
        });

        if (!response.ok || response.redirected) {
            throw new Error(`Remove failed with status ${response.status}.`);
        }

        window.location.reload();
    } catch (error) {
        console.error(error);
        window.alert("The cart item could not be removed.");
    }
}

cartItems.forEach(function (cartItem) {
    const countInput = cartItem.querySelector(".cart-count-input");
    const updateButton = cartItem.querySelector(".update-cart-btn");
    const removeButton = cartItem.querySelector(".remove-cart-btn");

    syncUpdateButton(cartItem);

    countInput.addEventListener("input", function () {
        syncUpdateButton(cartItem);
    });

    updateButton.addEventListener("click", function () {
        updateCartItem(cartItem);
    });

    removeButton.addEventListener("click", function () {
        removeCartItem(cartItem);
    });
});