document.addEventListener("DOMContentLoaded", function () {
    const showProductsButtons = document.querySelectorAll(".show-products-btn");

    showProductsButtons.forEach(function (button) {
        button.addEventListener("click", function () {
            const targetId = button.getAttribute("data-target");
            const panel = document.getElementById(targetId);
            const categoryId = button.getAttribute("data-category-id");

            if (!panel) return;

            const isExpanded = button.classList.contains("active");

            if (isExpanded) {
                // Collapse
                panel.classList.remove("show");
                button.classList.remove("active", "btn-secondary");
                button.classList.add("btn-primary");
                button.querySelector(".btn-label").textContent =
                    "Show Products";
            } else {
                // Expand
                panel.classList.add("show");
                button.classList.add("active");
                button.classList.remove("btn-primary");
                button.classList.add("btn-secondary");
                button.querySelector(".btn-label").textContent =
                    "Hide Products";

                // Fetch products if not already loaded
                const contentDiv = document.getElementById(
                    "products-content-" + categoryId,
                );
                if (contentDiv && contentDiv.dataset.loaded !== "true") {
                    fetch(`/category/GetCategoryProducts/${categoryId}`)
                        .then(function (response) {
                            if (response.ok) return response.json();
                            else throw new Error("Error Loading The Product");
                        })
                        .then(function (products) {
                            contentDiv.dataset.loaded = "true";
                            if (!products || products.length === 0) {
                                contentDiv.innerHTML =
                                    '<p class="no-products-msg">No products in this category.</p>';
                                return;
                            }
                            const list = document.createElement("ul");
                            list.className = "list-unstyled mb-0";

                            products.forEach(function (product) {
                                const item = document.createElement("li");
                                item.className = "product-item";
                                item.innerHTML =
                                    '<span class="product-badge"></span>' +
                                    "<span>" +
                                    (product.name ||
                                        product.Name ||
                                        "Unnamed Product") +
                                    "</span>";
                                list.appendChild(item);
                            });

                            contentDiv.innerHTML = "";
                            contentDiv.appendChild(list);
                        })
                        .catch(function () {
                            contentDiv.innerHTML =
                                '<p class="text-danger">Failed to load products.</p>';
                        });
                }
            }
        });
    });
});
