
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
    calcularTotal()

}

function quantityAdd() {
    let quantity = document.querySelector("#quantity")
    let value = parseInt(quantity.innerText)
    quantity.innerText = value + 1;
    calcularTotal()
}

async function submitOrder() {
    let inputs = document.querySelectorAll(".order-modal input")

    inputs.forEach(input => {
        input.classList.add("submitted")
    })
}

async function AddNewOrder(e) {
    e.preventDefault()
    let form = document.querySelector("#order-form")
    let folio = form.querySelector("#number-input").value
    let client = form.querySelector("#client-select").value
    let campaign = form.querySelector("#campaign-select").value
    let state = form.querySelector("#state-select").value
    let products = document.querySelectorAll(".order-modal .product-item")

    const pedido = {
        Folio: folio,
        IdClient: client,
        Campaign: Number(campaign),
        State: state,
        Products: []
    }

    products.forEach(product => {
        let clave = product.querySelector("#key-input").value
        let descripcion = product.querySelector("#description-input").value
        let cantidad = product.querySelector("#quantity").innerHTML
        let precio = product.querySelector("#price-input").value

        const item = {
            Key: clave,
            Description: descripcion,
            Quantity: Number(cantidad),
            Price: Number(precio)
        }

        pedido.Products.push(item)
    })

    try {
        let response = await axios.post("/Orders/AddNewOrder", {
            Folio: folio,
            IdClient: client,
            Campaign: Number(campaign),
            State: state,
            Products: pedido.Products
        })
        console.log(response)
    } catch (error) {
        console.log(error)
    }
}
async function showOrderDetails(id) {
    let container = document.querySelector(".container")
    try {
        let response = await axios.post("/Orders/OpenOrderDetails", {
            id
        })
        container.insertAdjacentHTML("beforeend", response.data)
    } catch (error) {
        console.log(error)
    }
}