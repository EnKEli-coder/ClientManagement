let productItems = document.querySelector(".product-item");

const formatter = new Intl.NumberFormat('es-MX', {
    style: 'currency',
    currency: 'MXN',
});



function itemFocus(e) {
    let item = e.currentTarget.closest(".product-item")
    if (item != null) {
        let inputs = item.querySelectorAll(".product-input")
        inputs.forEach(input => {
            input.disabled = false
        })
        item.classList.add("focus")
    }
}

function itemBlur(e) {
    if (!e.currentTarget.contains(e.relatedTarget) || e.relatedTarget === null) {
        let item = e.currentTarget
        if (item != null) {
            let inputs = item.querySelectorAll(".product-input")
            let price = item.querySelector("#price-input")

            price.value = formatter.format(parseInt(price.value))
            inputs.forEach(input => {
                input.disabled = true
            })
            item.classList.remove("focus")

            
        }
    }
}

async function addProductItem() {
    let container = document.querySelector(".products-list")
    try {
        let response = await axios.post("/Orders/AddNewProduct")
        container.insertAdjacentHTML("afterbegin", response.data)
    } catch (error) {
        console.log(error)
    }
}