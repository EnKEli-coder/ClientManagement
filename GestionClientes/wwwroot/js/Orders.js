
async function openNewOrder() {
    let container = document.querySelector(".container")
    try {
        let response = await axios.post("/Orders/OpenNewOrder")
        container.insertAdjacentHTML("beforeend", response.data)
    } catch (error) {
        console.log(error)
    }
}

function quantitySustract() {
    let quantity = document.querySelector("#quantity")
    let value = parseInt(quantity.innerText)

    if (value > 1) {
        quantity.innerText = value - 1;
    }

}

function quantityAdd() {
    let quantity = document.querySelector("#quantity")
    let value = parseInt(quantity.innerText)
    quantity.innerText = value + 1;
}