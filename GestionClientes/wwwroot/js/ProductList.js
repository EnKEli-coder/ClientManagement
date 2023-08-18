let productItems = document.querySelector(".product-item");

const formatter = new Intl.NumberFormat('es-MX', {
    style: 'currency',
    currency: 'MXN',
});

async function addProductItem() {
    let container = document.querySelector(".products-list")
    try {
        let response = await axios.post("/Orders/AddNewProduct")
        container.insertAdjacentHTML("afterbegin", response.data)
    } catch (error) {
        console.log(error)
    }

    toggleSaveButton()
}

